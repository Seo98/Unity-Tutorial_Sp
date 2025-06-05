using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {
        OnMouse();
    }

    private void OnMouse() // Mouse button pressed on the GameObject
    {
        if(Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Debug.Log("마우스버튼다운");
        }
        if(Input.GetMouseButton(0)) // Left mouse button held down
        {
            Debug.Log("마우스버튼");
        }
        if(Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            Debug.Log("마우스버튼업");
        }
    }
}
