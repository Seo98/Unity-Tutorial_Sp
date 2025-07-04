using UnityEngine;

public class CharactorControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    private IDropItem currentItem;
    public Transform grabpos; // �������� ��� ��ġ

    void Update()
    {
        Move();
        Interaction();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(moveX, 0, moveY).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Interaction()
    {
        if (currentItem == null) return; // ���� �������� ������ �ƹ� �۾��� ���� ����
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use(); // ������ ���
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop(); // ������ ������
            currentItem = null; // ���� �������� ���
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item;

            currentItem.Grab(grabpos);
        }
    }


    //
}
