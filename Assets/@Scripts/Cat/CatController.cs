using UnityEngine;
using UnityEngine.Rendering;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRd;
    public float Jumppower = 10;

    public bool isGround = false;

    public int jumpCount = 0;

    public GameObject cat2;
    private bool state = false;
    public float angel = 0f;
    void Start()
    {
        catRd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catRd.AddForceY(Jumppower, ForceMode2D.Impulse);
            jumpCount++;
        }
        cat2.transform.rotation = Quaternion.Euler(0, 0, angel);
        angel += 10f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isGround = true;
            cat2.SetActive(state = true);


        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            cat2.SetActive(state = false);
        }
    }
}
