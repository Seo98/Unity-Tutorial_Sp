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
            Debug.Log($"{t}�� ���ҽ��ϴ�.");
            yield return new WaitForSeconds(1f);
            t--;

            if(isStop)
            {
                Debug.Log("��.");
                yield break; // �ڷ�ƾ ����
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true; // �ڷ�ƾ ���� �÷��� ����
        }
    }


}
