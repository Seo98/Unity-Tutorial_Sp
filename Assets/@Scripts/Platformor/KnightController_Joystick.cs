using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton; // 공격 버튼은 현재 사용되지 않지만, 나중에 추가할 수 있습니다.

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


        jumpButton.onClick.AddListener(Jump); // 점프 버튼 클릭 시 Jump 메서드 호출
        attackButton.onClick.AddListener(Attack);
    }

    void Update() // 일반적인 작업
    {
        //InputKeyboard();
    }

    void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            knightRb.linearVelocity = new Vector2(inputDir.x * moveSpeed, knightRb.linearVelocity.y);
        }
        else
        {
            // 입력이 없을 땐 멈춤
            knightRb.linearVelocity = new Vector2(0, knightRb.linearVelocity.y);
        }
    }

    void Jump()
    {
        if (isGrounded)
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

    public void Input_Joystick(float h, float v)
    {
        inputDir = new Vector3(h, v, 0);
        animator.SetFloat("JoystickX", h);
        animator.SetFloat("JoystickY", v);

        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

        }

    }

    void Attack()
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
            animator.SetBool("isCombo", true);
        }
    }

    public void WaitCombo()
    {
        if (!animator.GetBool("isCombo"))
        {
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

}