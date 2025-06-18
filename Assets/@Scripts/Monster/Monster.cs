using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public MonsterSpawner monsterSpawner; // 몬스터 스포너 참조 (필요시 사용)


    [SerializeField] protected SpriteRenderer sRenderer; // 스프라이트 렌더러 컴포넌트
    Animator anim; // 애니메이션 컴포넌트 (필요시 사용)

    protected float hp = 100f;
    public float speed = 2.0f;

    private bool isMove = true; // 이동 여부를 제어하는 변수
    private bool isHit = false;
    private bool isDeath = false; // 죽음 여부를 제어하는 변수


    public int dir = 1;

    public abstract void Init();

    void Start()
    {
        // 스프라이트 렌더러 컴포넌트 초기화
        sRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); // 애니메이션 컴포넌트 초기화 (필요시 사용)
        monsterSpawner = Object.FindFirstObjectByType<MonsterSpawner>(); // 몬스터 스포너 찾기 (필요시 사용)

        Init();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isMove == false)
            return; // 이동이 비활성화된 경우 이동하지 않음
        if (isDeath == true)
            return; // 죽음 상태인 경우 이동하지 않음

        transform.position += (Vector3.right * dir * speed * Time.deltaTime);

        if (transform.position.x > 8f)
        {
            sRenderer.flipX = true; // 스프라이트를 좌우 반전
            dir = -1; // 방향 전환
        }
        else if (transform.position.x < -8f)
        {
            dir = 1; // 방향 전환
            sRenderer.flipX = false; // 스프라이트를 원래대로 돌림
        }
    }

    IEnumerator Hit(float damage)
    {
        if (isHit) // 이미 Hit 상태인 경우 중복 실행 방지
            yield break;

        isHit = true; // Hit 상태로 설정
        isMove = false; // 이동 비활성화

        anim.SetTrigger("Hit"); // 애니메이션 트리거 설정 (필요시 사용)
        hp -= 1f;

        if (hp <= 0f)
        {
            isDeath = true; // 죽음 상태로 설정
            anim.SetTrigger("Death"); // 죽음 애니메이션 트리거 설정 (필요시 사용)

            monsterSpawner.DropCoin(transform.position); // 코인 드랍 (필요시 사용)
            yield return new WaitForSeconds(3f); // 죽음 애니메이션 대기 시간
            Destroy(gameObject); // 몬스터 제거
        }

        yield return new WaitForSeconds(0.5f); // 0.5초 대기
        isHit = false; // Hit 상태 해제
        isMove = true; // 이동 활성화
    }

    private void OnMouseDown()
    {
        // Hit(1);
        StartCoroutine(Hit(1f)); // Hit 메서드 호출
    }
}


