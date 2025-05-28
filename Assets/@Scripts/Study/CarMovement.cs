using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float MoveSpeed = 3f; // Speed of the car movement
    public Rigidbody2D carRb;

    private float h; // Horizontal input

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right Arrow)
        // transform.position += Vector3.right * h * MoveSpeed * Time.deltaTime;

    }

    private void FixedUpdate()
    {

        carRb.linearVelocityX = h * MoveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("����!!");
    }
    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("������!!");
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("����Ʈ!!");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("����!!");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("������!!");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("����Ʈ!!");
    }
}
