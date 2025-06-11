using UnityEngine;
using UnityEngine.Rendering;
using Cat;
using System.Collections;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager; // SoundManager 인스턴스 추가
    public VideoManager videoManager;

    public GameObject gameOverUI; // 게임 오버 UI 오브젝트
    public GameObject fadeUI;

    private Rigidbody2D catRd;
    private Animator catAnim;

    public float Jumppower = 15;
    public float limitPower = 14f;

    public int jumpCount = 0;

    void Start()
    {
        catRd = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 4)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("IsGround", false);
            catRd.AddForceY(Jumppower, ForceMode2D.Impulse);
            jumpCount++;

            if (catRd.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                catRd.linearVelocityY = limitPower;


            soundManager.OnJumpSound(); // 점프 사운드 재생
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRd.linearVelocityY * 5f;
        transform.eulerAngles = catRotation;
    }   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe")) // 파이프와 충돌했을 때 // 게임 오버 처리
        {
            soundManager.OnColliderSound();
            this.GetComponent<CircleCollider2D>().enabled = false;
            gameOverUI.SetActive(true);

            fadeUI.SetActive(true); // 먼저 활성화
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black); // 그 다음 페이드 시작

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
            GameManager.score++; // 점수 증가

            if(GameManager.score == 10) // 점수가 10점이 되면 UI 활성화
            {
                this.GetComponent<CircleCollider2D>().enabled = false; // 충돌 감지 비활성화
                fadeUI.SetActive(true); // 페이드 UI 활성화
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white); // 페이드 효과 시작

                StartCoroutine(EndingRoutain(true));
            }
        }
    }

    IEnumerator EndingRoutain(bool ishappy)    
    {
        yield return new WaitForSeconds(3.5f);
        videoManager.VideoPlay(ishappy);

        //yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        soundManager.audioSource.mute = true; // 사운드 음소거
    }
}