using UnityEngine;

public class StudySomething : MonoBehaviour
{
    public int currentLevel = 10;

    public int maxLevel = 99;
    void Start()
    {
        //3�׿�����
        string msg = currentLevel >= maxLevel ? "���� �����Դϴ�." : "���� ������ �ƴմϴ�.";

        Debug.Log(msg);
    }

    

}
