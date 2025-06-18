using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform shootPos; // �Ѿ��� �߻�Ǵ� ��ġ

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero; // ��� ��ġ�� �̵�
        transform.localRotation = Quaternion.identity; // ȸ�� �ʱ�ȭ
        Debug.Log("Gun grabbed!");
    }
    public void Use()
    {
        GameObject biller = Instantiate(bulletPrefab, shootPos.position,Quaternion.identity);
        Rigidbody rb = biller.GetComponent<Rigidbody>();

        rb.AddForce(shootPos.forward * 100f, ForceMode.Impulse); // �Ѿ��� ������ �߻�

        Debug.Log("Gun fired!");
        // ���⿡ ���� ��� ������ �߰��ϼ���.
        // ��: Shoot();
    }
    public void Drop()
    {
        transform.SetParent(null); // �θ� �����Ͽ� ����߸�
        transform.localPosition = Vector3.zero;

        Debug.Log("Gun dropped!");
        // ���⿡ ���� ����߸��� ������ �߰��ϼ���.
        // ��: gameObject.SetActive(false);
    }
}
