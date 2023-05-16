using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{
    public static ControlsManager Instance;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    [SerializeField]
    private BarInfoInputController barInfoInputPrefab;
    
    [SerializeField] 
    private Transform barInfoInputParent;

    [SerializeField] 
    private ScrollRect barInfoScrollRect;

    private List<BarInfoInputController> barInfoInputs = new();
    
    public BarInfoInputController GetNewBarInfoInput()
    {
        var barInfoInput = Instantiate(barInfoInputPrefab, barInfoInputParent);
        barInfoInputs.Add(barInfoInput);
        Utilities.Instance.SnapTo(barInfoInputs.Last().GetComponent<RectTransform>(), barInfoScrollRect, barInfoInputParent.GetComponent<RectTransform>());
        return barInfoInput;
    }

    public void RemoveBarInfoInput(BarInfoInputController barInfoToRemove)
    {
        if (barInfoToRemove && barInfoInputs.Count > 0)
        {
            barInfoInputs.Remove(barInfoToRemove);
            Destroy(barInfoToRemove.gameObject);
        }
    }
}