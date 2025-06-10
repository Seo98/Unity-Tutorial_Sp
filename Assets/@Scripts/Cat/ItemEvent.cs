using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public GameObject partcle;
    public enum ColliderType { Pipe, Apple, Both }
    public ColliderType colliderTypes;

    public GameObject pipe;
    public GameObject apple;
    public GameObject Particle;

    public float moveSpeed = 3f;
    public float returnPosX = 15f;
    public float randomPosY;


    void Start()
    {
        SetRandomSetting(transform.position.x);
    }
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            SetRandomSetting(returnPosX);
        }
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-8f, -3f);
        transform.position = new Vector3(posX, randomPosY, 0);

        colliderTypes = (ColliderType)Random.Range(0, 3);

        pipe.SetActive(false);
        apple.SetActive(false);
        Particle.SetActive(false);


        switch (colliderTypes)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                apple.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
        }
    }

}
