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
        Vector3 destination = target.position + offset; // �÷��̾��� ��ġ�� �������� ���Ͽ� ī�޶��� ��ǥ ��ġ ���
        Vector3 smoothPos = Vector3.Lerp(transform.position, destination, smoothSpeed * Time.deltaTime);
        // ī�޶��� ���� ��ġ�� ��ǥ ��ġ ���̸� �ε巴�� ����. 

        smoothPos.x = Mathf.Clamp(smoothPos.x, minBound.x, maxBound.x); // ī�޶� x�� ��ġ ����
        smoothPos.y = Mathf.Clamp(smoothPos.y, minBound.y, maxBound.y); // ī�޶� y�� ��ġ ����

        transform.position = smoothPos; // ī�޶��� ��ġ�� �ε巴�� ������Ʈ
    }
}
