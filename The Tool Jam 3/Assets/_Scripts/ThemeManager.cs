using System;
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
        CurrentBarColor = themeData.themes[0].barColor;
        CurrentInputFieldColor = themeData.themes[0].inputFieldColor;
    }

    [NonSerialized]
    public TMP_FontAsset CurrentFontAsset;
    
    [NonSerialized]
    public Sprite CurrentBarSprite;
    [NonSerialized]
    public Color CurrentBarColor;

    [NonSerialized]
    public Color CurrentInputFieldColor;
    
    [Header("Theme stuff")]
    [SerializeField] 
    private ThemeData themeData;

    [SerializeField] 
    private Transform themeParent;
    
    [SerializeField] 
    private GameObject iconTextButton;

    [Header("Theme objects")] 
    [SerializeField]
    private Image toolBackground;
    
    [SerializeField]
    private Image graphBackground;
    
    [SerializeField]
    private Image controlBackground;
    
    [SerializeField]
    private Image saveIcon;
    [SerializeField]
    private Image addBarIcon;
    [SerializeField]
    private Image removeBarIcon;

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
        ChangeBackgrounds(theme);
        ChangeBar(theme);
        ChangeInputField(theme);
        ChangeIcons(theme);
    }

    private void ChangeIcons(Theme theme)
    {
        if (theme.saveIcon) saveIcon.sprite = theme.saveIcon;
        if (theme.addBarIcon) addBarIcon.sprite = theme.addBarIcon;
        if (theme.removeBarIcon) removeBarIcon.sprite = theme.removeBarIcon;
    }

    private void ChangeInputField(Theme theme)
    {
        CurrentInputFieldColor = theme.inputFieldColor;
        var inputFields = FindObjectsOfType<NormalInputField>();

        foreach (var inputField in inputFields)
        {
            inputField.UpdateImage();
        }
    }

    private void ChangeBar(Theme theme)
    {
        if (theme.barSprite)
        {
            CurrentBarSprite = theme.barSprite;
        }
        CurrentBarColor = theme.barColor;
        var bars = FindObjectsOfType<BarVisualController>();

        foreach (var bar in bars)
        {
            bar.UpdateBarImage();
        }
    }

    private void ChangeBackgrounds(Theme theme)
    {
        toolBackground.color = theme.toolBackgroundColor;
        graphBackground.sprite = theme.graphBackgroundSprite;
        controlBackground.sprite = theme.controlBackgroundSprite;
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
