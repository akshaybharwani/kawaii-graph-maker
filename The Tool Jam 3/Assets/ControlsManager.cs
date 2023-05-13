using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var layoutGroups = GetComponentsInChildren<LayoutGroup>();

        foreach (var layoutGroup in layoutGroups)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
    }
}
