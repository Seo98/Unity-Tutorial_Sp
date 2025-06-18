using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters; // 몬스터 프리팹 배열
    [SerializeField] private GameObject[] items; // 몬스터 프리팹 배열

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // 3초마다 몬스터 생성

            var randomIndex = Random.Range(0, monsters.Length); // 랜덤 인덱스 생성
            var randomX = Random.Range(-8, 9); // 랜덤 X 좌표 생성
            var randomY = Random.Range(-3, 5); // 랜덤 Y 좌표 생성


            var createPos = new Vector3(randomX, randomY, 0f); // 생성 위치 설정

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity); // 몬스터 생성
        }
    }
    public void DropCoin(Vector3 DropPos)
    {
        var randomIndex = Random.Range(0, items.Length); // 랜덤 인덱스 생성

        GameObject item = Instantiate(items[randomIndex], DropPos, Quaternion.identity); // 코인 생성
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기

        rb.AddForceX(Random.Range(-2f,2f), ForceMode2D.Impulse); // 오른쪽으로 힘을 가함
        rb.AddForceY(1f, ForceMode2D.Impulse); // 위로 힘을 가함

        float ranPower = Random.Range(-2f, 2f); // 랜덤 파워 생성
        rb.AddTorque(ranPower, ForceMode2D.Impulse); // 회전 힘을 가함
    }

}