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
        // 터렛 헤드가 플레이어를 향하도록 회전
        turretHead.LookAt(targetTf);

        timer += Time.deltaTime;
        if (timer >= cooldownTime)
        {
            timer = 0f;

            // 방법 A: 터렛 헤드의 방향으로 총알 생성
            Instantiate(bulletPrefab, FirePos.position, turretHead.rotation);

            // 방법 B: 플레이어 방향을 직접 계산해서 총알 생성
            // Vector3 direction = (targetTf.position - FirePos.position).normalized;
            // Quaternion bulletRotation = Quaternion.LookRotation(direction);
            // Instantiate(bulletPrefab, FirePos.position, bulletRotation);
        }
    }
}