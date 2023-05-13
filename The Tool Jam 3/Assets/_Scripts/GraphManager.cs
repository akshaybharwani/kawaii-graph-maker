using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GraphManager : MonoBehaviour
{
    public static GraphManager Instance;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    [FormerlySerializedAs("barImagePrefab")] [SerializeField]
    private BarVisualController barVisualPrefab;

    [SerializeField] 
    private Transform barParent;

    private List<BarVisualController> barImages = new();

    public BarVisualController GetNewBarImage()
    {
        var bar = Instantiate(barVisualPrefab, barParent);
        bar.Setup();
        barImages.Add(bar);
        return bar;
    }

    public void RemoveBarImage(BarVisualController barVisualToRemove)
    {
        if (barVisualToRemove && barImages.Count > 0)
        {
            barImages.Remove(barVisualToRemove);
            Destroy(barVisualToRemove);
        }
    }
}
