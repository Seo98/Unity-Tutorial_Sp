using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet; // The planet to rotate around
    public float rotSpeed = 30f; // 자전속도
    public float revolutionSpeed = 100f; // 공전 속도
    public bool isRevolution = false; // 논리타입 true / false



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        if (isRevolution == true)
        {
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
