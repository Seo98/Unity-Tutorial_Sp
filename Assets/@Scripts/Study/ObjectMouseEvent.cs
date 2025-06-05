using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Mouse Down on ");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up on ");
    }
    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter on ");
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit on ");
    }
    private void OnMouseOver()
    {
        Debug.Log("Mouse Over on ");
    }
    private void OnMouseDrag()
    {
        Debug.Log("Mouse Drag on ");
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse Up As Button on ");
    }

}
