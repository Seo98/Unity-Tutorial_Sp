using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    
    public GameObject obj; //ť�������Ʈ

    public string changeName; //ť���� �̸��� �ٲߴϴ�.
    void Start()
    {
        obj = GameObject.Find("Main Camera");

        obj.name = changeName; //ť���� �̸��� �ٲߴϴ�.
    }
}
