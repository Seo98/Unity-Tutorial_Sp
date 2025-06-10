using UnityEngine;

public class Study_Switch : MonoBehaviour
{

    public enum CalculationType { PLUS, MINUS, MULTIPLY, DIVIDE } // ������ ����
    public CalculationType calculationType = CalculationType.PLUS; // ������ ����

    public int input1, input2, result;

    void Start()
    {
        
        Debug.Log(Calculation());

    }

    private int Calculation() // ��� �޼ҵ�
    {
        int result = 0;

        switch (calculationType)
        {
            case CalculationType.PLUS:
                result = input1 + input2; // ���ϱ�
                break;
            case CalculationType.MINUS:
                result = input1 - input2; // ����
                break;
            case CalculationType.MULTIPLY:
                result = input1 * input2; // ���ϱ�
                break;
            case CalculationType.DIVIDE:
                result = input1 / input2; // ������
                break;
        }

        return result;
    }

}
