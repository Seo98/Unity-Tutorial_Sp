using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform shootPos; // 총알이 발사되는 위치

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero; // 잡는 위치로 이동
        transform.localRotation = Quaternion.identity; // 회전 초기화
        Debug.Log("Gun grabbed!");
    }
    public void Use()
    {
        GameObject biller = Instantiate(bulletPrefab, shootPos.position,Quaternion.identity);
        Rigidbody rb = biller.GetComponent<Rigidbody>();

        rb.AddForce(shootPos.forward * 100f, ForceMode.Impulse); // 총알을 앞으로 발사

        Debug.Log("Gun fired!");
        // 여기에 총을 쏘는 로직을 추가하세요.
        // 예: Shoot();
    }
    public void Drop()
    {
        transform.SetParent(null); // 부모를 제거하여 떨어뜨림
        transform.localPosition = Vector3.zero;

        Debug.Log("Gun dropped!");
        // 여기에 총을 떨어뜨리는 로직을 추가하세요.
        // 예: gameObject.SetActive(false);
    }
}
