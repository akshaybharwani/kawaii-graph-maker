using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BarVisualController : MonoBehaviour
{
    [SerializeField]
    private Image barImage;

    [SerializeField] 
    private TextMeshProUGUI barName;

    public TextMeshProUGUI BarName => barName;

    public void Setup()
    {
        // TODO: figure out a better way to set proper position for Bar Text and Image 
        // Currently this is putting the text below the Axis line and Image above
        /*var rect = GetComponent<RectTransform>().rect;
        var rectHeight = rect.height;
        rect.height = rectHeight + barName.GetComponent<RectTransform>().rect.height;*/
    }
    
    public void ChangeValue(float size, float maxSize)
    {
        if (barImage && maxSize != 0)
        {
            var sizePercent = (size / maxSize);
            barImage.fillAmount = sizePercent;
        }
    }

    public void ChangeName(string name)
    {
        barName.text = name;
    }
}
