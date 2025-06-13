using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    private void Start()
    {
        Factory<Monster> factory = new Factory<Monster>();
    }

}
