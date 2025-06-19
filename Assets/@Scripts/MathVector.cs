using UnityEngine;

public class MathVector : MonoBehaviour
{
    public Vector3 vec1 = new Vector3(3, 0, 0); // 예시 벡터
    public Vector3 vec2 = new Vector3(0, 4, 0); // 또 다른 예시 벡터

    private void Start()
    {
        float size = Vector3.Magnitude(vec1 + vec2); // 벡터의 크기 계산
        Debug.Log($"Magnitude : {size}");

        float distance = Vector3.Distance(vec1, vec2); // 두 벡터 사이의 거리 계산
        Debug.Log($"Distance : {distance}");

        float size2 = Vector3.SqrMagnitude(vec1 + vec2); // 벡터의 제곱 크기 계산
        Debug.Log($"SqrMagnitude : {size2}");

    }
}

