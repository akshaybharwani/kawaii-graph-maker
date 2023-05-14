using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager Instance;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        CurrentFontAsset = themeData.themes[0].fontAsset;
    }

    public TMP_FontAsset CurrentFontAsset;
    
    [Header("Theme stuff")]
    [SerializeField] 
    private ThemeData themeData;

    [SerializeField] 
    private Transform themeParent;
    
    [SerializeField] 
    private GameObject iconTextButton;

    private void Start()
    {
        PopulateThemes();
    }

    private void PopulateThemes()
    {
        for (var i = 0; i < themeData.themes.Count; i++)
        {
            var themeButton = Instantiate(iconTextButton, themeParent);
            themeButton.GetComponentInChildren<Button>().onClick.AddListener(delegate { ChangeTheme(i - 1); });
            themeButton.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }

    private void ChangeTheme(int themeIndex)
    {
        var theme = themeData.themes[themeIndex];
        ChangeFont(theme);
    }

    private void ChangeFont(Theme theme)
    {
        CurrentFontAsset = theme.fontAsset;
        var normalTexts = FindObjectsOfType<NormalText>();

        foreach (var normalText in normalTexts)
        {
            normalText.UpdateFontAsset();
        }
    }
}
