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
            //Invoke("PushPlayer", 0.1f); // 약간의 지연 후 플레이어를 밀도록 설정
            // 추가적인 로직이 필요하다면 여기에 작성
        }
    }

    void PushPlayer()
    {
        if (targetRb != null)
        {

            targetRb.AddForceY(15f, ForceMode2D.Impulse);
            animator.SetTrigger("Push"); // 애니메이션 트리거 설정
        }
    }
}
