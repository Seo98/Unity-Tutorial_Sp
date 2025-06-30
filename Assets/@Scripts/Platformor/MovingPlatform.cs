using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveType { Horizontal, Vertical }
    public MoveType moveType;

    public float theta = 0.0f; // 회전 각도
    public float power = 0.1f; // 회전 반지름
    public float speed = 1.0f; // 회전 속도

    private Vector3 initPos; // 회전 중심점

    void Start()
    {
        initPos = transform.position; // 초기 위치 저장
    }

    void Update()
    {
        theta += Time.deltaTime * speed;

        if (moveType == MoveType.Horizontal)
            transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
        else if (moveType == MoveType.Vertical)
            transform.position = new Vector3(initPos.x, initPos.y + power * Mathf.Sin(theta), initPos.z);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

}
