using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 5f;

    [SerializeField] private Vector2 minBound;
    [SerializeField] private Vector2 maxBound;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void LateUpdate()
    {
        Vector3 destination = target.position + offset; // 플레이어의 위치에 오프셋을 더하여 카메라의 목표 위치 계산
        Vector3 smoothPos = Vector3.Lerp(transform.position, destination, smoothSpeed * Time.deltaTime);
        // 카메라의 현재 위치와 목표 위치 사이를 부드럽게 보간. 

        smoothPos.x = Mathf.Clamp(smoothPos.x, minBound.x, maxBound.x); // 카메라 x축 위치 제한
        smoothPos.y = Mathf.Clamp(smoothPos.y, minBound.y, maxBound.y); // 카메라 y축 위치 제한

        transform.position = smoothPos; // 카메라의 위치를 부드럽게 업데이트
    }
}
