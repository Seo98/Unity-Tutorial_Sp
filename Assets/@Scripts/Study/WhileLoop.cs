using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    int count = 0;
    void Start()
    {
        /*while (count < 10)
        {
            Debug.Log($"{count}");
            count++;
        }*/

        // Do-While Loop Example
        do
        {
            Debug.Log($"{count}");
            count++;
        } 
        while (count < 10);


    }

    void Update()
    {

    }

}
