using UnityEngine;

public class CharactorControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    private IDropItem currentItem;
    public Transform grabpos; // 아이템을 잡는 위치

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
        if (currentItem == null) return; // 현재 아이템이 없으면 아무 작업도 하지 않음
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use(); // 아이템 사용
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop(); // 아이템 버리기
            currentItem = null; // 현재 아이템을 비움
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
