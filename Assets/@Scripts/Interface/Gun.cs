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
        // ���⿡ ���� ��� ������ �߰��ϼ���.
        // ��: Shoot();
    }
    public void Drop()
    {
        Debug.Log("Gun dropped!");
        // ���⿡ ���� ����߸��� ������ �߰��ϼ���.
        // ��: gameObject.SetActive(false);
    }
}
