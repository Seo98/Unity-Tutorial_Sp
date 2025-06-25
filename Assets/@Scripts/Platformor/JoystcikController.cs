using UnityEngine;
using UnityEngine.EventSystems;

public class JoystcikController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private KnightController_Joystick knightController; // KnightController_Keyboard ��ũ��Ʈ�� �ν��Ͻ��� �����մϴ�.
    

    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handleUI;

    private Vector2 startPos;
    private Vector2 currentPos;

    void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData) // �� �޼���� ��ġ�� �̵��ҋ� ȣ��
    {
        currentPos = eventData.position; // ���� ��ġ ��ġ�� �����մϴ�.

        Vector2 dragDir = currentPos - startPos;
        float maxDist = Mathf.Min(dragDir.magnitude, 100f);
        handleUI.transform.position = startPos + dragDir.normalized * maxDist; // �ڵ� UI�� ��ġ ��ġ�� �̵��մϴ�.


        Vector2 direction = dragDir.normalized * (maxDist / 100f); // -1~1 ����ȭ
        knightController.Input_Joystick(direction.x, direction.y); // ĳ���Ϳ� ����
    }

    public void OnPointerDown(PointerEventData eventData) // �� �޼���� ��ġ�� ���۵� �� ȣ��˴ϴ�.
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position; // ��� UI�� ��ġ ��ġ�� �̵��մϴ�.
        handleUI.transform.position = eventData.position;
        startPos = eventData.position;

    }


    public void OnPointerUp(PointerEventData eventData) // �� �޼���� ��ġ�� ���� �� ȣ��˴ϴ�.
    {
        handleUI.transform.position = Vector2.zero; // �ڵ� UI�� ��� UI ��ġ�� �̵��մϴ�.
        backgroundUI.SetActive(false); // ��� UI�� ��Ȱ��ȭ�մϴ�.
        knightController.Input_Joystick(0, 0); // �Է� �ʱ�ȭ
    }
}
