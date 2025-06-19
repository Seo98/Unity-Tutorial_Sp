using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead; // 타겟 오브젝트

    private float theta; // 타겟 오브젝트의 각도
    public float rotSpeed = 1f;
    public float rotRange = 60f; // 회전 범위 (도 단위)

    public bool isTarget = false; // 타겟 여부
    public Transform target; // 타겟 오브젝트

    void Update()
    {
        if (!isTarget) TurretIdle();
        else LookTarget();

    }

    void TurretIdle()
    {
        theta += Time.deltaTime * rotSpeed; // 시간에 따라 각도 증가
        float rotY = Mathf.Sin(theta) * rotRange; // 사인 함수를 사용하여 회전 각도 계산
        turretHead.localRotation = Quaternion.Euler(0f, rotY, 0f); // 타겟 오브젝트의 회전 적용
    }

    void LookTarget()
    {
        turretHead.LookAt(target); // 타겟 오브젝트를 바라보도록 회전
    }

    void TurretTarget()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            target = other.transform; // 타겟 오브젝트 설정
            isTarget = true; // 타겟이 감지되면 isTarget을 true로 설정
        }
    }
}
