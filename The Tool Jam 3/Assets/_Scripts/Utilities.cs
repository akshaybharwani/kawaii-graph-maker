using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Screen = UnityEngine.Device.Screen;

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

    public void TakeScreenshot()
    {
        // For capturing just the rect
        //CaptureRect(rectTransform);

        // For capturing the entire Screen
        var texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        var bytes = texture.EncodeToPNG();
        
        SaveScreenshot(bytes);
    }

    private void SaveScreenshot(byte[] bytes)
    {
        var name = $"Kawaii Graph_{DateTime.Now:hh-mm-ss}.png";
#if UNITY_WEBGL && !UNITY_EDITOR
        if (WebGLFileSaver.IsSavingSupported())
        {
            WebGLFileSaver.SaveFile(bytes, name);
        }
        else
        {
            // TODO: Show Error Dialog Box
        }
#endif
#if UNITY_EDITOR
        System.IO.File.WriteAllBytes($"{Application.dataPath}/" + name, bytes);
#endif
    }

    private void CaptureRect(RectTransform rectTransform)
    {
        // Capture rect corners
        var rectWorldCorners = new Vector3[4];
        rectTransform.GetWorldCorners(rectWorldCorners);
        var rectLeftCorner = rectWorldCorners[0];
        
        // Screen comparison
        var canvasResolution = rectTransform.GetComponentInParent<CanvasScaler>().referenceResolution;
        var xFactor = Screen.width / canvasResolution.x;
        var yFactor = Screen.height / canvasResolution.y;
        
        var rect = rectTransform.rect;
        var rectWidth = rect.width * xFactor;
        var rectHeight = rect.height * yFactor;
        var rectTexture = new Texture2D((int)rectWidth, (int)rectHeight, TextureFormat.RGB24, false);
        rectTexture.ReadPixels(new Rect(rectLeftCorner.x, rectLeftCorner.y, rectWidth, rectHeight), 0, 0);
        rectTexture.Apply();
        var bytes = rectTexture.EncodeToPNG();
    }

    public void SnapTo(RectTransform target, ScrollRect scrollRect, RectTransform contentPanel)
    {
        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
        SetLeft(contentPanel, 0);
        SetRight(contentPanel, 0);
    }
    
    public static void SetLeft(RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }
 
    public static void SetRight(RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }
}
