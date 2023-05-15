using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NormalInputField : MonoBehaviour
{
    [SerializeField]
    private Image image;
    
    // Start is called before the first frame update
    private void Awake()
    {
        UpdateImage();
    }

    public void UpdateImage()
    {
        if (ThemeManager.Instance)
        {
            var texts = GetComponentsInChildren<TextMeshProUGUI>();
            image.sprite = ThemeManager.Instance.CurrentInputFieldSprite ? ThemeManager.Instance.CurrentInputFieldSprite : ThemeManager.Instance.NormalBackgroundSprite;
            image.color = ThemeManager.Instance.CurrentInputFieldColor;
            foreach (var text in texts)
            {
                text.color = ThemeManager.Instance.CurrentInputFieldTextColor;
            }
        }
    }
}
