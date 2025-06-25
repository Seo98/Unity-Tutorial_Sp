using UnityEngine;
using UnityEngine.EventSystems;

public class JoystcikController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private KnightController_Joystick knightController; // KnightController_Keyboard 스크립트의 인스턴스를 참조합니다.
    

    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handleUI;

    private Vector2 startPos;
    private Vector2 currentPos;

    void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData) // 이 메서드는 터치가 이동할떄 호출
    {
        currentPos = eventData.position; // 현재 터치 위치를 저장합니다.

        Vector2 dragDir = currentPos - startPos;
        float maxDist = Mathf.Min(dragDir.magnitude, 100f);
        handleUI.transform.position = startPos + dragDir.normalized * maxDist; // 핸들 UI를 터치 위치로 이동합니다.


        Vector2 direction = dragDir.normalized * (maxDist / 100f); // -1~1 정규화
        knightController.Input_Joystick(direction.x, direction.y); // 캐릭터에 전달
    }

    public void OnPointerDown(PointerEventData eventData) // 이 메서드는 터치가 시작될 때 호출됩니다.
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position; // 배경 UI를 터치 위치로 이동합니다.
        handleUI.transform.position = eventData.position;
        startPos = eventData.position;

    }


    public void OnPointerUp(PointerEventData eventData) // 이 메서드는 터치가 끝날 때 호출됩니다.
    {
        handleUI.transform.position = Vector2.zero; // 핸들 UI를 배경 UI 위치로 이동합니다.
        backgroundUI.SetActive(false); // 배경 UI를 비활성화합니다.
        knightController.Input_Joystick(0, 0); // 입력 초기화
    }
}
