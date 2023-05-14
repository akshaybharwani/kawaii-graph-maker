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
        var rect = rectTransform.rect;
        rectTransform.GetWorldCorners(rectWorldCorners);
        var rectTexture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        rectTexture.ReadPixels(new Rect(rectWorldCorners[0].x, rectWorldCorners[0].y, rect.width, rect.height), 0, 0);
        rectTexture.Apply();

        // Capture screen and put rect in the middle
        /*var texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();*/
        
        var bytes = rectTexture.EncodeToPNG();
        File.WriteAllBytes($"{Application.dataPath}/Kawaii Graph_{DateTime.Now:hh-mm-ss}.png", bytes);
    }
}
