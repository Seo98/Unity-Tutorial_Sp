using UnityEngine;

public class Study_Switch : MonoBehaviour
{

    public enum CalculationType { PLUS, MINUS, MULTIPLY, DIVIDE } // 열거형 생성
    public CalculationType calculationType = CalculationType.PLUS; // 열거형 변수

    public int input1, input2, result;

    void Start()
    {
        
        Debug.Log(Calculation());

    }

    private int Calculation() // 계산 메소드
    {
        int result = 0;

        switch (calculationType)
        {
            case CalculationType.PLUS:
                result = input1 + input2; // 더하기
                break;
            case CalculationType.MINUS:
                result = input1 - input2; // 빼기
                break;
            case CalculationType.MULTIPLY:
                result = input1 * input2; // 곱하기
                break;
            case CalculationType.DIVIDE:
                result = input1 / input2; // 나누기
                break;
        }

        return result;
    }

}
