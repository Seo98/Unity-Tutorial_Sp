using UnityEngine;
using DevA;


public class ProgrammerB : MonoBehaviour
{
    public ProgrammerA pA;

    private void Start()
    {
        //pA.number1 = 10; // Error: number1 is not accessible due to its protection level
        pA.number2 = 20; // OK: number2 is public and accessible
        //pA.number3 = 30; // Error: number3 is not accessible due to its protection level
        //pA.number4 = 40; // Error: number4 is not accessible due to its protection level
        //pA.number5 = 50; // Error: number5 is not accessible due to its protection level


    }

}
