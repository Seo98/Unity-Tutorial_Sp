using System;
using UnityEngine;

public class Study_Casting : MonoBehaviour
{

    int number1 = 1;
    float number2 = 1.99f;
    void Start()
    {
        int num0 = 0;
        int num1 = 1;
        int num2 = 2;
        int num100 = 100;

        float fNum0 = 0f;
        float fNum1 = 1.57f;
        float fNum2 = 3.14f;


        string str1 = "æ»≥Á«œººø‰";
        string str2 = "true";
        string str3 = "false";

        Debug.Log("Num0 : " + Convert.ToBoolean(num0));
        Debug.Log("Num1 : " + Convert.ToBoolean(num1));
        Debug.Log("Num2 : " + Convert.ToBoolean(num2));
        Debug.Log("Num100 : " + Convert.ToBoolean(num100));

        Debug.Log("fNum0 : " + Convert.ToBoolean(fNum0));
        Debug.Log("fNum1 : " + Convert.ToBoolean(fNum1));
        Debug.Log("fNum2 : " + Convert.ToBoolean(fNum2));

        Debug.Log("str1 : " + Convert.ToBoolean(str1));
        Debug.Log("str2 : " + Convert.ToBoolean(str2));
        Debug.Log("str3 : " + Convert.ToBoolean(str3));


        Monster m = new Monster();
    }
}