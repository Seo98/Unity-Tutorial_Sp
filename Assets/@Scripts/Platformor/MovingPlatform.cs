using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveType { Horizontal, Vertical }
    public MoveType moveType;

    public float theta = 0.0f; // ȸ�� ����
    public float power = 0.1f; // ȸ�� ������
    public float speed = 1.0f; // ȸ�� �ӵ�

    private Vector3 initPos; // ȸ�� �߽���

    void Start()
    {
        initPos = transform.position; // �ʱ� ��ġ ����
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
