using System.Collections;
using UnityEngine;

public class Study_Coroutine : MonoBehaviour
{
    private Coroutine runningCoroutine;
    private bool isStop = false;
    void Start()
    {
        StartCoroutine(BombRoutain());
    }

    IEnumerator BombRoutain()
    {
        int t = 10;
        while (t > 0)
        {
            Debug.Log($"{t}초 남았습니다.");
            yield return new WaitForSeconds(1f);
            t--;

            if(isStop)
            {
                Debug.Log("펑.");
                yield break; // 코루틴 종료
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true; // 코루틴 중지 플래그 설정
        }
    }


}
