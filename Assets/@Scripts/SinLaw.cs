using Unity.Mathematics;
using UnityEngine;

public class SinLaw : MonoBehaviour
{
    //public float aAngle = 30f; // a 앵글
    //public float bAngle = 90f; //  b 앵글
    //public float aSide = 1f; // a 변의 길이

    public float cAngle = 60f; // c 앵글\
    public float aSide = 1f; // c 변의 길이
    public float bSide = 1f; // b 변의 길이 (계산된 값)


    private void Start()
    {
        /*
        float aAngleRad = aAngle * Mathf.Deg2Rad; // a 앵글을 라디안으로 변환
        float bAngleRad = bAngle * Mathf.Deg2Rad; // b 앵글을 라디안으로 변환

        float bSide = (aSide * Mathf.Sin(bAngleRad)) / Mathf.Sin(aAngleRad); // b 변의 길이 계산
        Debug.Log($"{bSide}"); // b 변의 길이 출력
        */

        float cRad = cAngle * Mathf.Deg2Rad; // c 앵글을 라디안으로 변환
        float cSide = Mathf.Sqrt(Mathf.Pow(aSide, 2) + Mathf.Pow(bSide, 2) - 2 * aSide * bSide * Mathf.Cos(cRad)); // c 변의 길이 계산
    }
}
