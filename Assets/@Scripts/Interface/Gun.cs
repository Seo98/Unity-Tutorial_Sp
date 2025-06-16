using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Grab()
    {
        Debug.Log("Gun grabbed!");
    }
    public void Use()
    {
        Debug.Log("Gun fired!");
        // 여기에 총을 쏘는 로직을 추가하세요.
        // 예: Shoot();
    }
    public void Drop()
    {
        Debug.Log("Gun dropped!");
        // 여기에 총을 떨어뜨리는 로직을 추가하세요.
        // 예: gameObject.SetActive(false);
    }
}
