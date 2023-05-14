using TMPro;
using UnityEngine;

public class NormalText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;
    
    // Start is called before the first frame update
    private void Awake()
    {
        UpdateFontAsset();
    }

    public void UpdateFontAsset()
    {
        if (ThemeManager.Instance)
        {
            tmpText.font = ThemeManager.Instance.CurrentFontAsset;
        }
    }
}
