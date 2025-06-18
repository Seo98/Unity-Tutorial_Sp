using Cat;
using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    /*private int number1 = 10; // Number1은 private로 선언되어 외부에서 직접 접근할 수 없음
    public int Number1 // 외부에서 읽고 쓸 수 있는 속성 number1
    {
        get { return number1; }
        set { number1 = value; }
    }

    //
    private int number2 = 20; // 외부에서 읽고 쓸 수 있는 속성  

    public int Number2 { get; set; } = 20;// 외부에서 읽고 쓸 수 있는 속성

    public int Number3 { get; private set; } = 30; //내부에서만 설정 가능 외부에서 읽기만 가능

    public int Number4 { get; } = 40; // 외부에서 읽기만 가능, 초기화는 생성자나 선언 시에만 가능

    private float hp = 100;
    public float Hp // 외부에서 읽고 쓸 수 있는 속성
    {
        get { return hp; }
        set
        {
            if (value < 0)
            {
                hp = 0; // HP가 0보다 작아지지 않도록 제한
                Death();
            }
            else
            {
                hp = value; // 유효한 값이면 설정
            }
        }
    }

    private SoundManager soundManager;
    public SoundManager SoundManager // 외부에서 읽고 쓸 수 있는 속성
    {
        get 
        {
            if (soundManager == null)soundManager = FindFirstObjectByType<SoundManager>(); 
            // SoundManager가 없으면 찾아서 할당
            return soundManager; 
        }
        set { soundManager = value; } // SoundManager를 설정할 수 있음
    }


    public void Death()
    {
        Debug.Log("죽음 상태입니다.");
    }*/

}
