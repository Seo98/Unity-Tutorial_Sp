using UnityEngine;

public class MathVector : MonoBehaviour
{
    public Vector3 vec1 = new Vector3(3, 0, 0); // ���� ����
    public Vector3 vec2 = new Vector3(0, 4, 0); // �� �ٸ� ���� ����

    private void Start()
    {
        float size = Vector3.Magnitude(vec1 + vec2); // ������ ũ�� ���
        Debug.Log($"Magnitude : {size}");

        float distance = Vector3.Distance(vec1, vec2); // �� ���� ������ �Ÿ� ���
        Debug.Log($"Distance : {distance}");

        float size2 = Vector3.SqrMagnitude(vec1 + vec2); // ������ ���� ũ�� ���
        Debug.Log($"SqrMagnitude : {size2}");

    }
}

