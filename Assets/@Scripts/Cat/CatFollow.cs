using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform cat;

    public Vector3 Offset;

    private void Update()
    {
        transform.position = cat.transform.position + (Vector3)Offset;  
    }
}
