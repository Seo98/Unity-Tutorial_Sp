using System;
using UnityEngine;
using UnityEngine.UI;

public class KnightController_Keyboard : MonoBehaviour, IDamageable
{
    private Animator animator;
    private Rigidbody2D knightRb;
    [SerializeField] private Collider2D knightColl; // Knight의 Collider2D 컴포넌트
    [SerializeField] private Image hpBar;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;

    private bool isGrounded = false;
    private bool isAttack = false; // 공격 중인지 여부를 나타내는 변수    
    private bool isCombo = false; // 콤보 공격 여부를 나타내는 변수
    private bool isLadder = false; // 사다리 타는 여부를 나타내는 변수

    public float hp = 100;
    public float curHp; // 현재 체력
    private float atkDamage = 3f;



    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        knightColl = GetComponent<Collider2D>();

        curHp = hp; // 현재 체력을 최대 체력으로 초기화
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }
        else
        {
            // 멈출 때 X속도 강제로 0으로
            knightRb.linearVelocity = new Vector2(0, knightRb.linearVelocity.y);
        }

        // 사다리 타는 경우 Y축 속도 조정
        if (isLadder && inputDir.y != 0)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed; // 사다리 타는 속도
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetTrigger("isJump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("isGround"))
        {
            animator.SetBool("isGround", true);
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("isGround"))
        {
            animator.SetBool("isGround", false);
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage}로 공격");
            // IDamageable 인터페이스를 구현한 오브젝트인지 확인
            if (other.GetComponent<IDamageable>() != null)
            {
                Debug.Log($"{other.name} 에게 {atkDamage} 데미지 줌");
                other.GetComponent<IDamageable>().TakeDamage(atkDamage);
                other.GetComponent<Animator>().SetTrigger("Hit"); // 몬스터가 맞았을 때 애니메이션 트리거
            }

        }

        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0; // 사다리 타는 동안 중력 비활성화
            knightRb.linearVelocity = Vector2.zero; // 사다리 타는 동안 속도 초기화
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 1; // 사다리에서 벗어나면 중력 활성화
            knightRb.linearVelocity = Vector2.zero; // 사다리에서 벗어나면 속도 초기화
        }
    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // Z 키 또는 마우스 왼쪽 버튼 클릭 시 공격
        {

            if (!isAttack)
            {
                isAttack = true;
                atkDamage = 3f; // 공격력 초기화
                animator.SetTrigger("isAttack");
            }
            else
            {
                isCombo = true;
            }
        }
    }

    public void WaitCombo()
    {
        if (isCombo)
        {
            atkDamage = 5f;
            animator.SetBool("isCombo", true);
        }
        else
        {
            isAttack = false;
            animator.SetBool("isCombo", false);
        }
    }

    public void EndCombo()
    {
        isCombo = false;
        isAttack = false;
        animator.SetBool("isCombo", false);
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage;

        hpBar.fillAmount = curHp / hp; // 체력바 업데이트

        if (hp <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        animator.SetTrigger("isDeath");
        knightRb.gravityScale = 0; // 죽으면 중력 비활성화
        knightColl.enabled = false; // 죽으면 충돌 비활성화
        Destroy(gameObject, 1f); // 1초 후에 오브젝트 제거
    }

}