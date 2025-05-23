using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet; // The planet to rotate around
    public float rotSpeed = 30f; // �����ӵ�
    public float revolutionSpeed = 100f; // ���� �ӵ�
    public bool isRevolution = false; // ��Ÿ�� true / false



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        if (isRevolution == true)
        {
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
