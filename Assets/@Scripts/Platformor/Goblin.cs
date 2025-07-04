using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore, IDamageable
{
    private float timer;
    private float idleTime, patrolTime;

    private float traceDist = 5f;
    private float attackDist = 1f;

    private bool isAttack;

    public ItemManager2 itemManager;

    void Start()
    {
        Init(30f, 3f, 2f,10f);

        idleTime = Random.Range(1f, 5f);
        StartCoroutine(FindPlayerRoutine());
        itemManager = FindFirstObjectByType<ItemManager2>();

    }

    protected override void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        base.Init(hp, speed, attackTime, atkDamage);
    }

    public override void Idle() // 기본 상태
    {
        animator.SetBool("isRun", false); // 애니메이터 파라미터 상태 설정
        timer += Time.deltaTime; // 타이머 업데이트
        if (timer >= idleTime) // 대기 시간 초과 시
        {
            timer = 0f; //  타이머 초기화

            moveDir = Random.Range(0, 2) == 1 ? 1 : -1; // 무작위로 이동 방향 설정 ex 랜덤으로 1이 나오면 +1 아니면 -1
            transform.localScale = new Vector3(moveDir, 1, 1); // 목표 방향으로 스케일 설정
            patrolTime = Random.Range(1f, 5f); // 무작위로 순찰 시간 설정
            animator.SetBool("isRun", true); // 애니메이터 파라미터 상태 설정

            ChangeState(MonsterState.PATROL); // 상태 변경
        }

        if (targetDist <= traceDist && isTrace) // 추적 거리 이내에 있고 추적 가능 상태일 때
        {
            timer = 0f; // 타이머 초기화
            animator.SetBool("isRun", true); // 애니메이터 파라미터 상태 설정

            ChangeState(MonsterState.TRACE); // 상태 변경
        }
        // IDLE에서 공격기능은 구현하지 않음

    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime; // 이동 

        timer += Time.deltaTime; // 타이머 업데이트
        if (timer >= patrolTime) // 순찰 시간 초과 시
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE); // 상태 변경
        }

        if (targetDist <= traceDist && isTrace) // 추적 거리 이내에 있고 추적 가능 상태일 때
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE); // 상태 변경
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized; // 목표 방향 계산
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime; // 이동
        var scaleX = targetDir.x > 0 ? 1 : -1; // 목표 방향에 따라 스케일 설정

        transform.localScale = new Vector3(scaleX, 1, 1); // 스케일 적용

        if (targetDist > traceDist) // 추적 거리를 벗어나면
        {
            animator.SetBool("isRun", false);
            ChangeState(MonsterState.IDLE); // 상태 변경
        }

        if (targetDist < attackDist) // 공격 거리에 들어오면
        {
            ChangeState(MonsterState.ATTACK); // 상태 변경
        }
    }

    public override void Attack() // 공격 상태
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("isAttack");
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(currAnimLength);

        animator.SetBool("isRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(attackTime - 1f);

        isAttack = false;
        animator.SetBool("isRun", true);
        ChangeState(MonsterState.TRACE);
    }

    IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return null;
            targetDist = Vector3.Distance(transform.position, target.position);

            if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
            {
                Vector3 monsterDir = Vector3.right * moveDir;
                Vector3 playerDir = (transform.position - target.position).normalized;
                float dotValue = Vector3.Dot(monsterDir, playerDir);
                isTrace = dotValue < -0.5f && dotValue >= -1f;

                if (targetDist <= traceDist && isTrace)
                {
                    animator.SetBool("isRun", true);

                    ChangeState(MonsterState.TRACE);
                }
            }
            else if (monsterState == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idleTime = Random.Range(1f, 5f);
                    animator.SetBool("isRun", false);

                    ChangeState(MonsterState.IDLE);
                }

                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {

        curHp -= damage; // 데미지 적용
        hpbar.fillAmount = curHp / hp; // 체력바 업데이트

        if (curHp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {

        animator.SetTrigger("Death");
        monsterColl.enabled = false;
        monsterRb.gravityScale = 0f;
        Destroy(gameObject, 1f); // 1초 후에 오브젝트 제거
        isDead = true;

        itemManager.DropItem(transform.position);


        int itemCount = Random.Range(0, 3);
        if (itemCount > 0) // 혹시나 0이 나오면 에러가 발생하기 때문에 예외처리
        {
            for (int i = 0; i < itemCount; i++) // itemCount 값으로 반복문 실행
            {
                itemManager.DropItem(transform.position); // 드롭 아이템 생성
            }
        }

    }

}