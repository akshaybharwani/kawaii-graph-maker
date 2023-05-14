using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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

    // Input Fields
    [SerializeField] 
    private TMP_InputField maxValueInput;

    private int maxBarValue;
    public int MaxBarValue => maxBarValue;

    private List<Bar> bars = new();

    private CanvasGroup[] nonScreenshotCanvasGroups;

    private void Start()
    {
        nonScreenshotCanvasGroups = GetComponentsInChildren<CanvasGroup>();
        SetupToolInputs();
    }

    private void SetupToolInputs()
    {
        maxValueInput.onValueChanged.AddListener(delegate
        {
            maxBarValue = string.IsNullOrEmpty(maxValueInput.text) ? 0 : int.Parse(maxValueInput.text);
        });
        
        maxValueInput.onEndEdit.AddListener(delegate
        {
            foreach (var bar in bars)
            {
                var valueInput = bar.InfoInput.BarValueInput;
                var valueText = valueInput.text;
                valueInput.onValueChanged.Invoke(valueText);
            }
        });
    }

    public void AddBar()
    {
        var barVisual = GraphManager.Instance.GetNewBarImage();
        var barInfoInput = ControlsManager.Instance.GetNewBarInfoInput();
        SetupBar(barVisual, barInfoInput);
        var newBar = new Bar(barVisual, barInfoInput);
        bars.Add(newBar);
    }

    private void SetupBar(BarVisualController barVisual, BarInfoInputController barInfoInput)
    {
        barInfoInput.SetBarNumber(bars.Count + 1);
        barInfoInput.BarNameInput.onValueChanged.AddListener(delegate
        {
            if (string.IsNullOrEmpty(barInfoInput.BarNameInput.text)) return;
            barVisual.ChangeName(barInfoInput.BarNameInput.text);
        });
        barInfoInput.BarValueInput.onValueChanged.AddListener(delegate
        {
            if (string.IsNullOrEmpty(barInfoInput.BarValueInput.text)) return;
            barVisual.ChangeValue(int.Parse(barInfoInput.BarValueInput.text), maxBarValue);
        });
        barInfoInput.BarValueInput.onEndEdit.AddListener(delegate
        {
            if (!string.IsNullOrEmpty(barInfoInput.BarValueInput.text)) return;
            ClearBarValue(barInfoInput);
        });
        maxValueInput.onEndEdit.AddListener(delegate
        {
            if (string.IsNullOrEmpty(maxValueInput.text)) return;
            SetBarValueIfEmpty(barInfoInput);
        });
        if (maxBarValue != 0) {barInfoInput.BarValueInput.text = maxBarValue.ToString();}
    }
    
    private void SetBarValueIfEmpty(BarInfoInputController barInfoInput)
    {
        var barValueInput = barInfoInput.BarValueInput;
        if (string.IsNullOrEmpty(barValueInput.text))
        {
            barValueInput.text = maxBarValue.ToString();
        }
    }
    
    private void ClearBarValue(BarInfoInputController barInfoInput)
    {
        barInfoInput.BarValueInput.text = 0.ToString();
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
    
    public void RemoveLastBar()
    {
        if (bars.Count > 0)
        {
            var barToRemove = bars.Last();
            RemoveBar(barToRemove);
        }
    }

    public void TakeScreenshot()
    {
        StartCoroutine(WaitAndTakeScreenshot());
    }

    private IEnumerator WaitAndTakeScreenshot()
    {
        foreach (var nonScreenshotCanvasGroup in nonScreenshotCanvasGroups)
        {
            nonScreenshotCanvasGroup.alpha = 0;
        }
        yield return new WaitForEndOfFrame();
        Utilities.Instance.TakeScreenshot();
        foreach (var nonScreenshotCanvasGroup in nonScreenshotCanvasGroups)
        {
            nonScreenshotCanvasGroup.alpha = 1;
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
