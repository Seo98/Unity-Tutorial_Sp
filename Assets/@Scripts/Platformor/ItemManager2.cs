using UnityEngine;
using UnityEngine.UI;

public class ItemManager2 : MonoBehaviour
{
    public GameObject invenUI;
    public Button buttonUI;

    [SerializeField] private GameObject[] items; // ���������� ����� �����յ��� �迭�� ���� (Inspector���� �Ҵ�)

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

    public void DropItem(Vector3 dropPos) // ��� ��ġ(vector3 ���������� ������ �Լ�) Ư�� ��ġ�� ���
    {
        var randomIndex = Random.Range(0, items.Length); // ���� �ε��� > �迭���� �������� �ϳ��� �������� ����

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        // �ش� ������ �������� ������ ��ġ(������) �� ����

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        // ������ �����ۿ��� Rigidbody2D ������Ʈ�� ������ (����ȿ���� �����ϱ� ����)

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);  // �¿�� �����ϰ� ���� ���� (X�� ����)
        itemRb.AddForceY(3f, ForceMode2D.Impulse);  // ���� �����ϵ��� ���� ���� (Y�� ����)

        // �����ۿ� ȸ�� ��ũ�� ���� �����ϰ� ȸ���ϵ��� ����
        float ranPower = Random.Range(-1.5f, 1.5f);  
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    // �������� ȹ������ �� ȣ��Ǵ� �Լ� (���� ������ ��� ����)
    public void GetItem(IItemObject item)
    {
        // ��� ���� �߿��� �� ������ ã�ƾ� ��.
        foreach(var slot in slots)
        {
            if(slot.isEmpty) // ������ ��� �� �� ���
            {
                slot.Additem(item);
                break;
            }
        }

    }

}
