using UnityEngine;
using UnityEngine.Rendering;
using Cat;
using System.Collections;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager; // SoundManager �ν��Ͻ� �߰�
    public VideoManager videoManager;

    public GameObject gameOverUI; // ���� ���� UI ������Ʈ
    public GameObject fadeUI;

    private Rigidbody2D catRd;
    private Animator catAnim;

    public float Jumppower = 15;
    public float limitPower = 14f;

    public int jumpCount = 0;

    void Awake() // 1��
    {
        catRd = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    private void OnEnable() // ���������� ����
    {
        transform.localPosition = new Vector3(-7.5f,-1,0);
        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.Play();
        soundManager.audioSource.mute = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 4)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("IsGround", false);
            catRd.AddForceY(Jumppower, ForceMode2D.Impulse);
            jumpCount++;

            if (catRd.linearVelocityY > limitPower) // �ڿ������� ������ ���� �ӵ� ����
                catRd.linearVelocityY = limitPower;


            soundManager.OnJumpSound(); // ���� ���� ���
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRd.linearVelocityY * 5f;
        transform.eulerAngles = catRotation;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe")) // �������� �浹���� �� // ���� ���� ó��
        {
            soundManager.OnColliderSound();
            this.GetComponent<CircleCollider2D>().enabled = false;
            gameOverUI.SetActive(true);

            fadeUI.SetActive(true); // ���� Ȱ��ȭ
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true); // �� ���� ���̵� ����

            StartCoroutine(EndingRoutain(false));
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("IsGround", true);
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().partcle.SetActive(true);
            GameManager.score++; // ���� ����

            if(GameManager.score == 10) // ������ 10���� �Ǹ� UI Ȱ��ȭ
            {
                this.GetComponent<CircleCollider2D>().enabled = false; // �浹 ���� ��Ȱ��ȭ
                fadeUI.SetActive(true); // ���̵� UI Ȱ��ȭ
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white, true); // ���̵� ȿ�� ����

                StartCoroutine(EndingRoutain(true));
            }
        }
    }

    IEnumerator EndingRoutain(bool ishappy)    
    {
        yield return new WaitForSeconds(3.5f);
        videoManager.VideoPlay(ishappy);

        yield return new WaitForSeconds(1f);
        var NewColor = ishappy ? Color.white : Color.black;
        fadeUI.GetComponent<FadeRoutine>().OnFade(3f, NewColor, false);
        gameOverUI.SetActive(false);
        // FADE ������

        //yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);
        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);

        transform.parent.gameObject.SetActive(false); // play ���� false
        soundManager.audioSource.Stop(); // ���� ���Ұ�
    }
}