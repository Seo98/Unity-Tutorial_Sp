using UnityEngine;

public class Study_Invoke : MonoBehaviour
{

    public int count = 10;
    void Start()
    {
        //Invoke("Method1", 3f);
        InvokeRepeating("Bomb", 0f, 1f);
    }

    private void Bomb()
    {
        Debug.Log($"남은시간 : {count}");
        count--;

        if (count == 0)
        {
            Debug.Log("펑.");
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("폭탄이 해제되었습니다.");
        }
    }
}
