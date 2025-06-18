using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{

    public GameObject lightObj;
    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos); // 부모를 잡는 위치로 설정
        transform.localPosition = Vector3.zero; // 잡는 위치로 이동
        transform.localRotation = Quaternion.identity; // 회전 초기화
        Debug.Log("Flashlight grabbed!");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf); // 플래시라이트 오브젝트 활성화
        Debug.Log("Flashlight turned on!");
        // 여기에 플래시라이트를 켜는 로직을 추가하세요.
        // 예: gameObject.SetActive(true);
    }

    public void Drop()
    {
        transform.SetParent(null); // 부모를 제거하여 떨어뜨림
        transform.localPosition = Vector3.zero;

        Debug.Log("Flashlight dropped!");
        // 여기에 플래시라이트를 떨어뜨리는 로직을 추가하세요.
        // 예: gameObject.SetActive(false);
    }

}
