using System;
using System.Collections.Generic;
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
    private Image detailsPanelBackground;
    
    [SerializeField]
    private Image barInfoPanelBackground;
    
    [SerializeField]
    private Image saveIcon;
    [SerializeField]
    private Image addBarIcon;
    [SerializeField]
    private Image removeBarIcon;

    private List<Image> themeButtonBackgroundImages = new();
    
    private void Start()
    {
        PopulateThemes();
    }

    private void PopulateThemes()
    {
        for (var i = 0; i < themeData.themes.Count; i++)
        {
            var theme = themeData.themes[i];
            var themeButton = Instantiate(iconTextButton, themeParent);
            themeButton.GetComponentInChildren<Button>().onClick.AddListener(delegate { ChangeTheme(theme); });
            themeButton.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            themeButtonBackgroundImages.Add(themeButton.GetComponent<Image>());
        }
    }

    private void ChangeTheme(Theme theme)
    {
        ChangeFont(theme);
        ChangeBackgrounds(theme);
        ChangeBar(theme);
        ChangeInputField(theme);
        ChangeIcons(theme);
    }

    private void ChangeIcons(Theme theme)
    {
        if (theme.saveIcon)
        {
            saveIcon.sprite = theme.saveIcon;
        }
        if (theme.addBarIcon) addBarIcon.sprite = theme.addBarIcon;
        if (theme.removeBarIcon) removeBarIcon.sprite = theme.removeBarIcon;
        var backgroundSprite = theme.buttonBackground ? theme.buttonBackground : null;
        saveIcon.transform.parent.GetComponent<Image>().sprite = backgroundSprite;
        foreach (var themeButtonBackgroundImage in themeButtonBackgroundImages)
        {
            themeButtonBackgroundImage.sprite = backgroundSprite;
        }
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
        else
        {
            CurrentBarSprite = null;
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
        if (theme.toolBackgroundImage)
        {
            toolBackground.sprite = theme.toolBackgroundImage;
        }
        else
        {
            toolBackground.sprite = null;
            toolBackground.color = theme.toolBackgroundColor;
        }

        if (theme.graphBackgroundSprite)
        {
            graphBackground.sprite = theme.graphBackgroundSprite;
        }
        else
        {
            graphBackground.sprite = null;
            graphBackground.color = theme.graphBackgroundColor;
        }

        if (theme.controlBackgroundSprite)
        {
            controlBackground.sprite = theme.controlBackgroundSprite;
        }
        else
        {
            controlBackground.sprite = null;
            controlBackground.color = theme.controlBackgroundColor;
        }

        if (theme.infoBackgroundSprite)
        {
            detailsPanelBackground.sprite = theme.infoBackgroundSprite;
            barInfoPanelBackground.sprite = theme.infoBackgroundSprite;
        }
        else
        {
            detailsPanelBackground.color = theme.infoBackgroundColor;
            barInfoPanelBackground.color = theme.infoBackgroundColor;
        }
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
