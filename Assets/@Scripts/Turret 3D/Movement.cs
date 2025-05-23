using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �ذ� ��� 1: �Է°��� �ݴ�� ����
        Vector3 dir = new Vector3(h, 0, v);

        Vector3 normalDir = dir.normalized;
        Debug.Log($"���� �Է� : {normalDir}");

        if (normalDir != Vector3.zero) // �Է��� ���� ���� �̵�
        {
            transform.position += normalDir * moveSpeed * Time.deltaTime;
            transform.LookAt(transform.position + normalDir);
        }
    }
}

/* 
=== �ٸ� �ذ� ����� ===

��� 4: ĳ���� ȸ������ �ذ�
- ĳ���� ������Ʈ�� Y ȸ���� 180���� ����

��� 5: ��ũ��Ʈ ���� Unity �����Ϳ��� �ذ�
- ĳ���� ���� �� ������Ʈ�� �ڽ����� �����
- �ڽ� ���� Y ȸ���� 180���� ����

��� 6: �̵� ���� ��� ����
Vector3 dir = new Vector3(h, 0, v);
// �̵� ������ 180�� ȸ��
dir = Quaternion.Euler(0, 180, 0) * dir;
*/