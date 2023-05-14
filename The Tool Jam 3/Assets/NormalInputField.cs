using System.Collections;
using System.Collections.Generic;
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
            image.color = ThemeManager.Instance.CurrentInputFieldColor;
        }
    }
}
