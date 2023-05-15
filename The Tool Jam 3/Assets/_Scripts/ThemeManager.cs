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
        CurrentFontColor = themeData.themes[0].fontColor;
        CurrentBarColor = themeData.themes[0].barColor;
        CurrentBarInfoColor = themeData.themes[0].barInfoInputColor;
        CurrentInputFieldColor = themeData.themes[0].inputFieldColor;
        CurrentInputFieldTextColor = themeData.themes[0].inputFieldTextColor;
    }

    [NonSerialized]
    public TMP_FontAsset CurrentFontAsset;
    [NonSerialized]
    public Color CurrentFontColor;
    
    [NonSerialized]
    public Sprite CurrentBarSprite;
    [NonSerialized]
    public Color CurrentBarColor;

    [NonSerialized]
    public Sprite CurrentInputFieldSprite;
    [NonSerialized]
    public Color CurrentInputFieldColor;
    [NonSerialized] 
    public Color CurrentInputFieldTextColor;
    
    [NonSerialized] 
    public Color CurrentBarInfoColor;
    
    [Header("Theme stuff")]
    [SerializeField] 
    private ThemeData themeData;

    [SerializeField] 
    private Transform themeParent;
    
    [SerializeField] 
    private GameObject iconTextButton;

    [SerializeField] 
    private Sprite normalBackgroundSprite;
    public Sprite NormalBackgroundSprite => normalBackgroundSprite;

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

    [SerializeField] 
    private Image xAxisLine;
    [SerializeField]
    private Image yAxisLine;

    [SerializeField] 
    private Image scrollRect;

    [SerializeField] 
    private Image addBarImage;
    [SerializeField] 
    private Image removeBarImage;

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
        ChangeButtons(theme);
    }

    private void ChangeButtons(Theme theme)
    {
        addBarImage.color = theme.barButtonColor;
        removeBarImage.color = theme.barButtonColor;
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
        var saveIconParentImage = saveIcon.transform.parent.GetComponent<Image>();
        saveIconParentImage.sprite = backgroundSprite;
        saveIconParentImage.color = theme.buttonBackgroundColor;
        foreach (var themeButtonBackgroundImage in themeButtonBackgroundImages)
        {
            themeButtonBackgroundImage.sprite = backgroundSprite;
            themeButtonBackgroundImage.color = theme.buttonBackgroundColor;
        }
    }

    private void ChangeInputField(Theme theme)
    {
        CurrentInputFieldSprite = theme.inputFieldSprite ? theme.inputFieldSprite : null;
        CurrentInputFieldColor = theme.inputFieldColor;
        CurrentInputFieldTextColor = theme.inputFieldTextColor;
        var inputFields = FindObjectsOfType<NormalInputField>();

        foreach (var inputField in inputFields)
        {
            inputField.UpdateImage();
        }
    }

    private void ChangeBar(Theme theme)
    {
        CurrentBarSprite = theme.barSprite ? theme.barSprite : null;
        CurrentBarColor = theme.barColor;
        CurrentBarInfoColor = theme.barInfoInputColor;
        xAxisLine.color = theme.axisColor;
        yAxisLine.color = theme.axisColor;
        var bars = FindObjectsOfType<BarVisualController>();
        var barInfoInputs = FindObjectsOfType<BarInfoInputController>();

        foreach (var bar in bars)
        {
            bar.UpdateBarImage();
        }
        
        foreach (var barInfoInput in barInfoInputs)
        {
            barInfoInput.UpdateImage();
        }
    }

    private void ChangeBackgrounds(Theme theme)
    {
        toolBackground.sprite = theme.toolBackgroundImage ? theme.toolBackgroundImage : null;
        toolBackground.color = theme.toolBackgroundColor;
        graphBackground.sprite = theme.graphBackgroundSprite ? theme.graphBackgroundSprite : null;
        graphBackground.color = theme.graphBackgroundColor;
        controlBackground.sprite = theme.controlBackgroundSprite ? theme.controlBackgroundSprite : null;
        controlBackground.color = theme.controlBackgroundColor;
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

        scrollRect.color = theme.infoBackgroundColor;
    }

    private void ChangeFont(Theme theme)
    {
        CurrentFontAsset = theme.fontAsset;
        CurrentFontColor = theme.fontColor;
        var normalTexts = FindObjectsOfType<NormalText>();

        foreach (var normalText in normalTexts)
        {
            normalText.UpdateFontAsset();
        }
    }
}
