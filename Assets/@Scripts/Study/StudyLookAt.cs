using System.Threading;
using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turretHead;
    public GameObject bulletPrefab;
    public Transform FirePos;
    public float timer;
    public float cooldownTime;

    void Start()
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // �ͷ� ��尡 �÷��̾ ���ϵ��� ȸ��
        turretHead.LookAt(targetTf);

        timer += Time.deltaTime;
        if (timer >= cooldownTime)
        {
            timer = 0f;

            // ��� A: �ͷ� ����� �������� �Ѿ� ����
            Instantiate(bulletPrefab, FirePos.position, turretHead.rotation);

            // ��� B: �÷��̾� ������ ���� ����ؼ� �Ѿ� ����
            // Vector3 direction = (targetTf.position - FirePos.position).normalized;
            // Quaternion bulletRotation = Quaternion.LookRotation(direction);
            // Instantiate(bulletPrefab, FirePos.position, bulletRotation);
        }
    }
}