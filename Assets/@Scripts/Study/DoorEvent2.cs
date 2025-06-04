using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    private Animator anim;

    public string openKey;
    public string closeKey;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Door Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Door Close");
        }
    }
}
