using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public void Grab()
    {
        Debug.Log("Flashlight grabbed!");
    }

    public void Use()
    {
        Debug.Log("Flashlight turned on!");
        // 여기에 플래시라이트를 켜는 로직을 추가하세요.
        // 예: gameObject.SetActive(true);
    }

    public void Drop()
    {
        Debug.Log("Flashlight dropped!");
        // 여기에 플래시라이트를 떨어뜨리는 로직을 추가하세요.
        // 예: gameObject.SetActive(false);
    }

}
