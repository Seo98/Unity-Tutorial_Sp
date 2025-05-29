using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D Leftbar_lb;
    public Rigidbody2D Rightbar_rb;

    public int totalScore = 0;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            Leftbar_lb.AddTorque(30f);
        else
            Leftbar_lb.AddTorque(-25f);

        if (Input.GetKey(KeyCode.RightArrow))
            Rightbar_rb.AddTorque(-30f);
        else
            Rightbar_rb.AddTorque(25f);
    }
}


