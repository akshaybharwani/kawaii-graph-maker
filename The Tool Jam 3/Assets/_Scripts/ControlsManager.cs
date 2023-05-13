using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
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
    private Transform barParent;

    private List<BarInfoInputController> barInfoInputs = new();
    
    public BarInfoInputController GetNewBarInfoInput()
    {
        var barInfoInput = Instantiate(barInfoInputPrefab, barParent);
        barInfoInputs.Add(barInfoInput);
        return barInfoInput;
    }

    public void RemoveBarInfoInput(BarInfoInputController barInfoToRemove)
    {
        if (barInfoToRemove && barInfoInputs.Count > 0)
        {
            barInfoInputs.Remove(barInfoToRemove);
            Destroy(barInfoToRemove);
        }
    }
}