using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 해결 방법 1: 입력값을 반대로 적용
        Vector3 dir = new Vector3(h, 0, v);

        Vector3 normalDir = dir.normalized;
        Debug.Log($"현재 입력 : {normalDir}");

        if (normalDir != Vector3.zero) // 입력이 있을 때만 이동
        {
            transform.position += normalDir * moveSpeed * Time.deltaTime;
            transform.LookAt(transform.position + normalDir);
        }
    }
}

/* 
=== 다른 해결 방법들 ===

방법 4: 캐릭터 회전으로 해결
- 캐릭터 오브젝트의 Y 회전을 180도로 설정

방법 5: 스크립트 없이 Unity 에디터에서 해결
- 캐릭터 모델을 빈 오브젝트의 자식으로 만들고
- 자식 모델의 Y 회전을 180도로 설정

방법 6: 이동 방향 계산 변경
Vector3 dir = new Vector3(h, 0, v);
// 이동 방향을 180도 회전
dir = Quaternion.Euler(0, 180, 0) * dir;
*/