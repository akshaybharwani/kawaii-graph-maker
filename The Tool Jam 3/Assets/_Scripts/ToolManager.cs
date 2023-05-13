using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private int maxBarValue;
    public int MaxBarValue => maxBarValue;

    private List<Bar> bars = new();

    public void AddBar()
    {
        var barVisual = GraphManager.Instance.GetNewBarImage();
        var barInfoInput = ControlsManager.Instance.GetNewBarInfoInput();
        barInfoInput.SetBarNumber(bars.Count + 1);
        barInfoInput.BarNameInput.onValueChanged.AddListener(delegate {barVisual.ChangeName(barInfoInput.BarNameInput.text);});
        barInfoInput.BarValueInput.onValueChanged.AddListener(delegate {barVisual.ChangeValue(int.Parse(barInfoInput.BarValueInput.text), maxBarValue);});
        var newBar = new Bar(barVisual, barInfoInput);
        bars.Add(newBar);
    }

    public void RemoveBar(Bar barToRemove)
    {
        if (bars.Count > 0)
        {
            bars.Remove(barToRemove);
            GraphManager.Instance.RemoveBarImage(barToRemove.Image);
            ControlsManager.Instance.RemoveBarInfoInput(barToRemove.InfoInput);
        }
    }

    public struct Bar
    {
        public BarVisualController Image;
        public BarInfoInputController InfoInput;

        public Bar(BarVisualController image, BarInfoInputController infoInput)
        {
            this.Image = image;
            this.InfoInput = infoInput;
        }
    }
}
