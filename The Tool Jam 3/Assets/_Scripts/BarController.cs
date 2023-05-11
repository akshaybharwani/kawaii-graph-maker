using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    private Image barImage;
    
    // Start is called before the first frame update
    void Start()
    {
        barImage = GetComponent<Image>();
    }

    public void ChangeSize(float size, float maxSize)
    {
        if (barImage)
        {
            var sizePercent = (size / maxSize);
            barImage.fillAmount = sizePercent;
        }
    }
}
