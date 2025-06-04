using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;

    public float moveSpeed;
    public float jumpPower = 10f;
    private float h;

    public bool isGround;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal"); // Ű �Է�

        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGround = true;

        renderers[2].gameObject.SetActive(false); // Jump
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGround = false;

        renderers[0].gameObject.SetActive(false); // Idle
        renderers[1].gameObject.SetActive(false); // Run
        renderers[2].gameObject.SetActive(true); // Jump
    }

    /// <summary>
    /// ĳ���� �����ӿ� ���� �̹����� Flip ���°� ���ϴ� ���
    /// </summary>
    private void Move()
    {

        if (h != 0 && characterRb.linearVelocityY == 0) // ĳ���Ͱ� �¿�� �̵� ���� ��
        {
            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(true); // Run
            renderers[2].gameObject.SetActive(false); // Jump

            characterRb.linearVelocityX = h * moveSpeed; // �������� �̵�

            if (h > 0) // ���������� �̵��� ��
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }

            else if (h < 0)// �������� �̵��� ��
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }

        else if (characterRb.linearVelocityY != 0) // ĳ���Ͱ� ���� ���� ��
        {
            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(false); // Run
            renderers[2].gameObject.SetActive(true); // Jump
            if (characterRb.linearVelocityX > 0) // ���������� �̵��� ��
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            else if (characterRb.linearVelocityX < 0)// �������� �̵��� ��
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }

        else if (h == 0)// �������� ���� ��
        {
            renderers[0].gameObject.SetActive(true); // Idle
            renderers[1].gameObject.SetActive(false); // Run
            renderers[2].gameObject.SetActive(false); // Jump
        }

    }

    /// <summary>
    /// ĳ���Ͱ� +Y �������� �����ϴ� ���
    /// </summary>
    private void Jump()
    {

        if (Input.GetButtonDown("Jump")) // ���� ��ư�� ������ ��    
        {
            

            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            if (!isGround && h != 0)
            {
                characterRb.linearVelocityX = h * moveSpeed;
                renderers[0].gameObject.SetActive(false); // Idle
                renderers[1].gameObject.SetActive(false); // Run
                renderers[2].gameObject.SetActive(true); // Jump
                
            }

        }

        if (Input.GetButton("Horizontal")) // �¿� �̵� ��ư�� ������ ���� ��
        {
            characterRb.linearVelocityX = h * moveSpeed;
            if (h > 0) // ���������� �̵��� ��
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            else if (h < 0)// �������� �̵��� ��
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }
    }
}