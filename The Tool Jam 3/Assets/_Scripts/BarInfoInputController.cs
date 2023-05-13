using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BarInfoInputController : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI barNumber;
    [SerializeField]
    private InputField barNameInput;
    [SerializeField]
    private InputField barValueInput;

    public InputField BarNameInput => barNameInput;
    public InputField BarValueInput => barValueInput;

    private void SetBarInfo(int barNumber)
    {
        this.barNumber.text = barNumber.ToString();
    }

    private void OnDisable()
    {
        barNameInput.onValueChanged.RemoveAllListeners();
        barValueInput.onValueChanged.RemoveAllListeners();
    }
}
