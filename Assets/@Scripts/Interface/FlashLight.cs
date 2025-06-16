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
        // ���⿡ �÷��ö���Ʈ�� �Ѵ� ������ �߰��ϼ���.
        // ��: gameObject.SetActive(true);
    }

    public void Drop()
    {
        Debug.Log("Flashlight dropped!");
        // ���⿡ �÷��ö���Ʈ�� ����߸��� ������ �߰��ϼ���.
        // ��: gameObject.SetActive(false);
    }

}
