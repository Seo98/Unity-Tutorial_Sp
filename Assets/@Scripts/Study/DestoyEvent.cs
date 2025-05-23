using UnityEngine;

public class DestoyEvent : MonoBehaviour
{

    public float destroyTime = 3f; // �ı��� �ð� (�� ����)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}�� �ı��Ǿ����ϴ�.");
    }
}
