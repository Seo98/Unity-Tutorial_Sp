using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab; // Prefab to instantiate
    void Awake()
    {

        CreateObj();
    }

    public void CreateObj()
    {

        GameObject obj = Instantiate(prefab);

        obj.name = "라이온 캐릭터";

        Debug.Log($"캐릭터의 자식 오브젝트의 수 : {obj.transform.childCount}");
        Debug.Log($"캐릭터의 첫번째 자식 오브젝트 이름 : {obj.transform.GetChild(0).name}");
        Debug.Log($"캐릭터의 마지막 자식 오브젝트의 부모 이름 : {obj.transform.GetChild(obj.transform.childCount - 1).name}");

    }


}
