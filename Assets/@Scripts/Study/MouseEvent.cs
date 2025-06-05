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
            Debug.Log("���콺��ư�ٿ�");
        }
        if(Input.GetMouseButton(0)) // Left mouse button held down
        {
            Debug.Log("���콺��ư");
        }
        if(Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            Debug.Log("���콺��ư��");
        }
    }
}
