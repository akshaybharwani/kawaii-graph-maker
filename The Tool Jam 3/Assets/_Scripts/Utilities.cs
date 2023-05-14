using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Utilities : MonoBehaviour
{
    public static Utilities Instance;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void TakeScreenshot(RectTransform rect)
    {
        StartCoroutine(WaitAndTakeScreenshot(rect));
    }
    
    private IEnumerator WaitAndTakeScreenshot(RectTransform rectTransform)
    {
        yield return new WaitForEndOfFrame();
        
        // Capture rect
        var rectWorldCorners = new Vector3[4];
        rectTransform.GetWorldCorners(rectWorldCorners);
        var rectLeftCorner = rectWorldCorners[0];
        var rect = rectTransform.rect;
        var rectWidth = rect.width;
        var rectHeight = rect.height;
        var rectTexture = new Texture2D((int)rectWidth, (int)rectHeight, TextureFormat.RGB24, false);
        rectTexture.ReadPixels(new Rect(rectLeftCorner.x, rectLeftCorner.y, rectWidth, rectHeight), 0, 0);
        rectTexture.Apply();
        var bytes = rectTexture.EncodeToPNG();
        File.WriteAllBytes($"{Application.dataPath}/Kawaii Graph_{DateTime.Now:hh-mm-ss}.png", bytes);
    }
}
