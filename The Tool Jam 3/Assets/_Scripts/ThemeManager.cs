using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    [SerializeField] 
    private ThemeData themeData;

    [SerializeField] 
    private Transform themeParent;

    private void Start()
    {
        Populate();
    }

    private void Populate()
    {
        
    }
}
