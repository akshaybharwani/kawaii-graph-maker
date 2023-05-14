using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ThemeData", menuName = "ScriptableObjects/ThemeData", order = 1)]
public class ThemeData : ScriptableObject
{
    public List<Theme> themes = new();
}

[Serializable]
public class Theme
{
    public string name;
    public TMP_FontAsset fontAsset;
    public Color fontColor;
    public Color axisColor;
    [Header("Input Field")]
    public Sprite inputFieldSprite;
    public Color inputFieldColor;
    public Color inputFieldTextColor;
    [Header("Tool Background")]
    public Sprite toolBackgroundImage;
    public Color toolBackgroundColor;
    [Header("Graph Background")]
    public Sprite graphBackgroundSprite;
    public Color graphBackgroundColor;
    [Header("Control Background")]
    public Sprite controlBackgroundSprite;
    public Color controlBackgroundColor;
    [Header("Info Background")]
    public Sprite infoBackgroundSprite;
    public Color infoBackgroundColor;
    [Header("Bar")]
    public Sprite barSprite;
    public Color barColor;
    [Header("Icons")]
    public Sprite saveIcon;
    public Sprite addBarIcon;
    public Sprite removeBarIcon;
    public Sprite buttonBackground;
    public Color buttonBackgroundColor;
    public Color barButtonColor;
    public Color barInfoInputColor;
}
