using System;
using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;
    private bool isGrounded = false;
    private bool isAttack = false; // 공격 중인지 여부를 나타내는 변수    
    private bool isCombo = false; // 콤보 공격 여부를 나타내는 변수


    private float atkDamage = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage}로 공격");
        }
    }

}