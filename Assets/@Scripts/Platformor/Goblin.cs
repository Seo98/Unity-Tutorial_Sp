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

    public override void Idle() // �⺻ ����
    {
        animator.SetBool("isRun", false); // �ִϸ����� �Ķ���� ���� ����
        timer += Time.deltaTime; // Ÿ�̸� ������Ʈ
        if (timer >= idleTime) // ��� �ð� �ʰ� ��
        {
            timer = 0f; //  Ÿ�̸� �ʱ�ȭ

            moveDir = Random.Range(0, 2) == 1 ? 1 : -1; // �������� �̵� ���� ���� ex �������� 1�� ������ +1 �ƴϸ� -1
            transform.localScale = new Vector3(moveDir, 1, 1); // ��ǥ �������� ������ ����
            patrolTime = Random.Range(1f, 5f); // �������� ���� �ð� ����
            animator.SetBool("isRun", true); // �ִϸ����� �Ķ���� ���� ����

            ChangeState(MonsterState.PATROL); // ���� ����
        }

        if (targetDist <= traceDist && isTrace) // ���� �Ÿ� �̳��� �ְ� ���� ���� ������ ��
        {
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
            animator.SetBool("isRun", true); // �ִϸ����� �Ķ���� ���� ����

            ChangeState(MonsterState.TRACE); // ���� ����
        }
        // IDLE���� ���ݱ���� �������� ����

    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime; // �̵� 

        timer += Time.deltaTime; // Ÿ�̸� ������Ʈ
        if (timer >= patrolTime) // ���� �ð� �ʰ� ��
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE); // ���� ����
        }

        if (targetDist <= traceDist && isTrace) // ���� �Ÿ� �̳��� �ְ� ���� ���� ������ ��
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE); // ���� ����
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized; // ��ǥ ���� ���
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime; // �̵�
        var scaleX = targetDir.x > 0 ? 1 : -1; // ��ǥ ���⿡ ���� ������ ����

        transform.localScale = new Vector3(scaleX, 1, 1); // ������ ����

        if (targetDist > traceDist) // ���� �Ÿ��� �����
        {
            animator.SetBool("isRun", false);
            ChangeState(MonsterState.IDLE); // ���� ����
        }

        if (targetDist < attackDist) // ���� �Ÿ��� ������
        {
            ChangeState(MonsterState.ATTACK); // ���� ����
        }
    }

    public override void Attack() // ���� ����
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

        curHp -= damage; // ������ ����
        hpbar.fillAmount = curHp / hp; // ü�¹� ������Ʈ

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
        Destroy(gameObject, 1f); // 1�� �Ŀ� ������Ʈ ����
        isDead = true;

        itemManager.DropItem(transform.position);


        int itemCount = Random.Range(0, 3);
        if (itemCount > 0) // Ȥ�ó� 0�� ������ ������ �߻��ϱ� ������ ����ó��
        {
            for (int i = 0; i < itemCount; i++) // itemCount ������ �ݺ��� ����
            {
                itemManager.DropItem(transform.position); // ��� ������ ����
            }
        }

    }

}