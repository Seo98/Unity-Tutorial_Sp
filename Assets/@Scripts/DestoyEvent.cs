using UnityEngine;

public class DestoyEvent : MonoBehaviour
{

    public float destroyTime = 3f; // 파괴될 시간 (초 단위)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}이 파괴되었습니다.");
    }
}
