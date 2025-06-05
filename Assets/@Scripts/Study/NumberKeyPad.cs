using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{

    public Animator doorAnim; // Animator for the door
    public GameObject doorLock;
    public string password;
    public string keyPadNumber;

    public void OnInputNumber(string NumStiring)
    {
        keyPadNumber += NumStiring;

        Debug.Log($"{NumStiring} 입력 -> 현재 입력 : {keyPadNumber}");

    }

    public void OnCheckNumber()
    {
        if(keyPadNumber == password)
        {
            Debug.Log("문 열림");
            doorAnim.SetTrigger("Door Open"); // Trigger the door open animation
            keyPadNumber = "";

            doorLock.SetActive(false); // Disable the door lock
        }
        else
        {
            keyPadNumber = ""; // Reset
            Debug.Log("비밀 번호 오류");
        }

    }
}
