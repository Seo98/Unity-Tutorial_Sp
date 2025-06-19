using Unity.Mathematics;
using UnityEngine;

public class SinLaw : MonoBehaviour
{
    //public float aAngle = 30f; // a �ޱ�
    //public float bAngle = 90f; //  b �ޱ�
    //public float aSide = 1f; // a ���� ����

    public float cAngle = 60f; // c �ޱ�\
    public float aSide = 1f; // c ���� ����
    public float bSide = 1f; // b ���� ���� (���� ��)


    private void Start()
    {
        /*
        float aAngleRad = aAngle * Mathf.Deg2Rad; // a �ޱ��� �������� ��ȯ
        float bAngleRad = bAngle * Mathf.Deg2Rad; // b �ޱ��� �������� ��ȯ

        float bSide = (aSide * Mathf.Sin(bAngleRad)) / Mathf.Sin(aAngleRad); // b ���� ���� ���
        Debug.Log($"{bSide}"); // b ���� ���� ���
        */

        float cRad = cAngle * Mathf.Deg2Rad; // c �ޱ��� �������� ��ȯ
        float cSide = Mathf.Sqrt(Mathf.Pow(aSide, 2) + Mathf.Pow(bSide, 2) - 2 * aSide * bSide * Mathf.Cos(cRad)); // c ���� ���� ���
    }
}
