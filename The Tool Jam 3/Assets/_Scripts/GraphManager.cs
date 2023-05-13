using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    
    [SerializeField]
    private BarController barPrefab;

    [SerializeField] 
    private Transform barParent;

    private List<BarController> bars = new List<BarController>();
    public List<BarController> Bars => bars;

    private void Start()
    {
        
    }
    
    public void AddBar()
    {
        var bar = Instantiate(barPrefab, barParent);
        bars.Add(bar);
    }

    public void RemoveBar(BarController barToRemove)
    {
        if (barToRemove && bars.Count > 0)
        {
            bars.Remove(barToRemove);
            Destroy(barToRemove);
        }
    }

    public void RemoveLastBar()
    {
        if (bars.Count > 0)
        {
            bars.Remove(bars.Last());
        }
    }
}
