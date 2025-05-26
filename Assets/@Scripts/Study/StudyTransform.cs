using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 70f;
    void Update()
    {
        // ���� �̵�
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // ���� �̵�
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);




        //�� 
        float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime;
        float localX = transform.eulerAngles.x;
        float localZ = transform.eulerAngles.z;
        //transform.rotation = Quaternion.Euler(localX, angle , localZ);




        // ����
        // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        //����
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        // transform.RotateAround(new Vector3(0,0,0), new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);

        transform.LookAt(Vector3.zero);
    }
}
