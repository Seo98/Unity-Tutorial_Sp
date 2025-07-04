using UnityEngine;
using UnityEngine.UI;

public class ItemManager2 : MonoBehaviour
{
    public GameObject invenUI;
    public Button buttonUI;

    [SerializeField] private GameObject[] items; // 아이템으로 사용할 프리팹들을 배열로 저장 (Inspector에서 할당)

    [SerializeField ] private Transform slotgroup;

    public Slot[] slots;

    private void Start()
    {
        slots = slotgroup.GetComponentsInChildren<Slot>(true);

        buttonUI.onClick.AddListener(OnInventory);
    }


    public void OnInventory()
    {
        invenUI.SetActive(!invenUI.activeSelf);
    }

    public void DropItem(Vector3 dropPos) // 드랍 위치(vector3 참조값으로 가지는 함수) 특정 위치에 드롭
    {
        var randomIndex = Random.Range(0, items.Length); // 랜덤 인덱스 > 배열에서 무작위로 하나의 아이템을 선택

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        // 해당 아이템 프리팹을 지정된 위치(참조값) 에 생성

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        // 생성된 아이템에서 Rigidbody2D 컴포넌트를 가져옴 (물리효과를 적용하기 위함)

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);  // 좌우로 랜덤하게 힘을 가함 (X축 방향)
        itemRb.AddForceY(3f, ForceMode2D.Impulse);  // 위로 점프하듯이 힘을 가함 (Y축 방향)

        // 아이템에 회전 토크를 가해 랜덤하게 회전하도록 설정
        float ranPower = Random.Range(-1.5f, 1.5f);  
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    // 아이템을 획득했을 때 호출되는 함수 (현재 구현은 비어 있음)
    public void GetItem(IItemObject item)
    {
        // 모든 슬롯 중에서 빈 슬롯을 찾아야 함.
        foreach(var slot in slots)
        {
            if(slot.isEmpty) // 슬롯이 비어 있 을 경우
            {
                slot.Additem(item);
                break;
            }
        }

    }

}
