using TMPro;
using UnityEngine;

public class BarInfoInputController : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI barNumber;
    [SerializeField]
    private TMP_InputField barNameInput;
    [SerializeField]
    private TMP_InputField barValueInput;

    public TMP_InputField BarNameInput => barNameInput;
    public TMP_InputField BarValueInput => barValueInput;

    public void SetBarNumber(int barNumber)
    {
        this.barNumber.text = barNumber.ToString();
    }

    private void OnDisable()
    {
        barNameInput.onValueChanged.RemoveAllListeners();
        barValueInput.onValueChanged.RemoveAllListeners();
    }
}
