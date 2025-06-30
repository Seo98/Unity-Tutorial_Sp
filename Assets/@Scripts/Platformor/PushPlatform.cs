using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D targetRb;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            targetRb = other.GetComponent<Rigidbody2D>();
            PushPlayer();
            //Invoke("PushPlayer", 0.1f); // �ణ�� ���� �� �÷��̾ �е��� ����
            // �߰����� ������ �ʿ��ϴٸ� ���⿡ �ۼ�
        }
    }

    void PushPlayer()
    {
        if (targetRb != null)
        {

            targetRb.AddForceY(15f, ForceMode2D.Impulse);
            animator.SetTrigger("Push"); // �ִϸ��̼� Ʈ���� ����
        }
    }
}
