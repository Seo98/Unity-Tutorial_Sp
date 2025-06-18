using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters; // ���� ������ �迭
    [SerializeField] private GameObject[] items; // ���� ������ �迭

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // 3�ʸ��� ���� ����

            var randomIndex = Random.Range(0, monsters.Length); // ���� �ε��� ����
            var randomX = Random.Range(-8, 9); // ���� X ��ǥ ����
            var randomY = Random.Range(-3, 5); // ���� Y ��ǥ ����


            var createPos = new Vector3(randomX, randomY, 0f); // ���� ��ġ ����

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity); // ���� ����
        }
    }
    public void DropCoin(Vector3 DropPos)
    {
        var randomIndex = Random.Range(0, items.Length); // ���� �ε��� ����

        GameObject item = Instantiate(items[randomIndex], DropPos, Quaternion.identity); // ���� ����
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������

        rb.AddForceX(Random.Range(-2f,2f), ForceMode2D.Impulse); // ���������� ���� ����
        rb.AddForceY(1f, ForceMode2D.Impulse); // ���� ���� ����

        float ranPower = Random.Range(-2f, 2f); // ���� �Ŀ� ����
        rb.AddTorque(ranPower, ForceMode2D.Impulse); // ȸ�� ���� ����
    }

}