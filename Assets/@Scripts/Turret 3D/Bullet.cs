using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;

    void Start()
    {
        // �Ѿ��� ���� �ð� �� �ڵ����� �����ǵ��� (���� ����ȭ)
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // ������ ����
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}