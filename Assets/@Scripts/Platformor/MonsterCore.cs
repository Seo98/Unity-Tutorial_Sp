using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE;


    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    public Transform target;
    public Image hpbar;


    public float hp;
    public float curHp; // 현재 체력
    public float speed;
    public float attackTime;
    public float atkDamage;

    protected float moveDir;
    protected float targetDist;


    protected bool isTrace;
    protected bool isDead = false;

    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.atkDamage = atkDamage;

        curHp = hp; // 현재 체력을 최대 체력으로 초기화

        target = GameObject.FindGameObjectWithTag("Player").transform;


        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }

    void Update()
    {
        /*targetDist = Vector3.Distance(transform.position, target.position); // 플레이어와 몬스터 간의 거리 계산

        Vector3 monsterDir = Vector3.right * moveDir; // 몬스터의 이동 방향 벡터
        Vector3 playerDir = (transform.position - target.position).normalized; // 플레이어 방향 벡터
        // 플레이어 방향 - 몬스터 방향 = 몬스터가 바라보는 방향과 플레이어 방향의 차이 벡터
        float dotValue = Vector3.Dot(monsterDir, playerDir); // 몬스터 방향과 플레이어 방향의 내적 계산

        // isTrace = dotValue < 0f;
        isTrace = dotValue < -0.9f && dotValue >= -1f; // 몬스터가 플레이어를 바라보고 있는지 확인*/


        if (isDead)
            return;

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }

        if (other.GetComponent<IDamageable>() != null) // IDamageable 인터페이스를 구현한 오브젝트인지 확인
        {
            Debug.Log($"{atkDamage}로 공격");
            other.GetComponent<IDamageable>().TakeDamage(atkDamage); // IDamageable 인터페이스를 구현한 오브젝트에 데미지 적용
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState)
            monsterState = newState;
    }

}