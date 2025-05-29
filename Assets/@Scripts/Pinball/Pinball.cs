using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager;
    private void OnCollisionEnter2D(Collision2D other)
    {
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score20":
                score = 20;
                break;
            case "Score30":
                score = 30;
                break;

        }
        pinballManager.totalScore += score;
        

        if(score != 0)
        {
            Debug.Log(score);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Game Over!");
        }

    }
}
