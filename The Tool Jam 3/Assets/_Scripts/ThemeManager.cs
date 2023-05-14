using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    [Header("Theme stuff")]
    [SerializeField] 
    private ThemeData themeData;

    [SerializeField] 
    private Transform themeParent;
    
    [SerializeField] 
    private GameObject iconTextButton;
    
    /*[Header("Tool objects")]
    [SerializeField]
    private */

    private void Start()
    {
        Populate();
    }

    private void Populate()
    {
        for (var index = 0; index < themeData.themes.Count; index++)
        {
            var themeButton = Instantiate(iconTextButton, themeParent);
            themeButton.GetComponent<TextMeshProUGUI>().text = (index + 1).ToString();
            themeButton.GetComponent<Button>().onClick.AddListener(delegate { ChangeTheme(index); });
        }
    }

    private void ChangeTheme(int themeIndex)
    {
        
    }
}
