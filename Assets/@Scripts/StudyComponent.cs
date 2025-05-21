using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    
    public GameObject obj; //큐브오브젝트

    public string changeName; //큐브의 이름을 바꿉니다.
    void Start()
    {
        obj = GameObject.Find("Main Camera");

        obj.name = changeName; //큐브의 이름을 바꿉니다.
    }
}
