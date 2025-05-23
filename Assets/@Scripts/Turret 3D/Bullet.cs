using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;

    void Start()
    {
        // 총알이 일정 시간 후 자동으로 삭제되도록 (성능 최적화)
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // 앞으로 직진
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}