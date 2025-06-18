using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{

    public GameObject lightObj;
    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos); // �θ� ��� ��ġ�� ����
        transform.localPosition = Vector3.zero; // ��� ��ġ�� �̵�
        transform.localRotation = Quaternion.identity; // ȸ�� �ʱ�ȭ
        Debug.Log("Flashlight grabbed!");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf); // �÷��ö���Ʈ ������Ʈ Ȱ��ȭ
        Debug.Log("Flashlight turned on!");
        // ���⿡ �÷��ö���Ʈ�� �Ѵ� ������ �߰��ϼ���.
        // ��: gameObject.SetActive(true);
    }

    public void Drop()
    {
        transform.SetParent(null); // �θ� �����Ͽ� ����߸�
        transform.localPosition = Vector3.zero;

        Debug.Log("Flashlight dropped!");
        // ���⿡ �÷��ö���Ʈ�� ����߸��� ������ �߰��ϼ���.
        // ��: gameObject.SetActive(false);
    }

}
