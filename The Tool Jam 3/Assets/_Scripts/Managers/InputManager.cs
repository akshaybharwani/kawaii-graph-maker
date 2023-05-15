using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        // Keyboard Input for fields
        CheckForTab();
        CheckFoEnter();
    }

    private void CheckFoEnter()
    {
        if (!Input.GetKeyDown(KeyCode.Return) || EventSystem.current.currentSelectedGameObject == null) return;
        // First check if there's something to the left
        var barInfo = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BarInfoInputController>();
        var selectableDown = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
        if (barInfo != null)
        {
            if (selectableDown == null)
            {
                ToolManager.Instance.AddBar();
                selectableDown = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                if (selectableDown)
                {
                    selectableDown.Select();
                }
            }
            else
            {
                selectableDown.Select();
            }
        }
    }

    private void CheckForTab()
    {
        if (!Input.GetKeyDown(KeyCode.Tab) || EventSystem.current.currentSelectedGameObject == null) return;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // First check if there's something to the left
            var selectable = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft();
            if (selectable != null)
            {
                var barInfo = selectable.GetComponentInParent<BarInfoInputController>();
                if (barInfo == null)
                {
                    selectable.Select();
                    return;
                }
            }
            selectable = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (selectable != null)
            {
                selectable.Select();
            }
        }
        else
        {
            // First check if there's something to the right
            var selectable = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();
            if (selectable != null)
            {
                selectable.Select();
                return;
            }
            selectable = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (selectable != null)
            {
                selectable.Select();
            }
        }
    }
}
