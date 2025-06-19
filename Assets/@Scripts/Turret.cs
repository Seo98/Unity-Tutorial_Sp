using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead; // Ÿ�� ������Ʈ

    private float theta; // Ÿ�� ������Ʈ�� ����
    public float rotSpeed = 1f;
    public float rotRange = 60f; // ȸ�� ���� (�� ����)

    public bool isTarget = false; // Ÿ�� ����
    public Transform target; // Ÿ�� ������Ʈ

    void Update()
    {
        if (!isTarget) TurretIdle();
        else LookTarget();

    }

    void TurretIdle()
    {
        theta += Time.deltaTime * rotSpeed; // �ð��� ���� ���� ����
        float rotY = Mathf.Sin(theta) * rotRange; // ���� �Լ��� ����Ͽ� ȸ�� ���� ���
        turretHead.localRotation = Quaternion.Euler(0f, rotY, 0f); // Ÿ�� ������Ʈ�� ȸ�� ����
    }

    void LookTarget()
    {
        turretHead.LookAt(target); // Ÿ�� ������Ʈ�� �ٶ󺸵��� ȸ��
    }

    void TurretTarget()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            target = other.transform; // Ÿ�� ������Ʈ ����
            isTarget = true; // Ÿ���� �����Ǹ� isTarget�� true�� ����
        }
    }
}
