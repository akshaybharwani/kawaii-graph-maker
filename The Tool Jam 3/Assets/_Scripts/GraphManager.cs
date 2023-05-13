using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField]
    private BarController barPrefab;

    [SerializeField] 
    private Transform barParent;
    
    private void Start()
    {
        
    }
    
    public void AddBar()
    {
        var bar = Instantiate(barPrefab, barParent);
    }

    public void RemoveBar()
    {
        
    }
}
