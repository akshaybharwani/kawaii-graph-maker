using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public Image graphBackgroundImage;
    
}
