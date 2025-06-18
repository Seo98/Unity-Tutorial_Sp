using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public MonsterSpawner monsterSpawner; // ���� ������ ���� (�ʿ�� ���)


    [SerializeField] protected SpriteRenderer sRenderer; // ��������Ʈ ������ ������Ʈ
    Animator anim; // �ִϸ��̼� ������Ʈ (�ʿ�� ���)

    protected float hp = 100f;
    public float speed = 2.0f;

    private bool isMove = true; // �̵� ���θ� �����ϴ� ����
    private bool isHit = false;
    private bool isDeath = false; // ���� ���θ� �����ϴ� ����


    public int dir = 1;

    public abstract void Init();

    void Start()
    {
        // ��������Ʈ ������ ������Ʈ �ʱ�ȭ
        sRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); // �ִϸ��̼� ������Ʈ �ʱ�ȭ (�ʿ�� ���)
        monsterSpawner = Object.FindFirstObjectByType<MonsterSpawner>(); // ���� ������ ã�� (�ʿ�� ���)

        Init();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isMove == false)
            return; // �̵��� ��Ȱ��ȭ�� ��� �̵����� ����
        if (isDeath == true)
            return; // ���� ������ ��� �̵����� ����

        transform.position += (Vector3.right * dir * speed * Time.deltaTime);

        if (transform.position.x > 8f)
        {
            sRenderer.flipX = true; // ��������Ʈ�� �¿� ����
            dir = -1; // ���� ��ȯ
        }
        else if (transform.position.x < -8f)
        {
            dir = 1; // ���� ��ȯ
            sRenderer.flipX = false; // ��������Ʈ�� ������� ����
        }
    }

    IEnumerator Hit(float damage)
    {
        if (isHit) // �̹� Hit ������ ��� �ߺ� ���� ����
            yield break;

        isHit = true; // Hit ���·� ����
        isMove = false; // �̵� ��Ȱ��ȭ

        anim.SetTrigger("Hit"); // �ִϸ��̼� Ʈ���� ���� (�ʿ�� ���)
        hp -= 1f;

        if (hp <= 0f)
        {
            isDeath = true; // ���� ���·� ����
            anim.SetTrigger("Death"); // ���� �ִϸ��̼� Ʈ���� ���� (�ʿ�� ���)

            monsterSpawner.DropCoin(transform.position); // ���� ��� (�ʿ�� ���)
            yield return new WaitForSeconds(3f); // ���� �ִϸ��̼� ��� �ð�
            Destroy(gameObject); // ���� ����
        }

        yield return new WaitForSeconds(0.5f); // 0.5�� ���
        isHit = false; // Hit ���� ����
        isMove = true; // �̵� Ȱ��ȭ
    }

    private void OnMouseDown()
    {
        // Hit(1);
        StartCoroutine(Hit(1f)); // Hit �޼��� ȣ��
    }
}


