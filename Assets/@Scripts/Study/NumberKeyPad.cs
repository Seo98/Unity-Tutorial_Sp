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

        Debug.Log($"{NumStiring} �Է� -> ���� �Է� : {keyPadNumber}");

    }

    public void OnCheckNumber()
    {
        if(keyPadNumber == password)
        {
            Debug.Log("�� ����");
            doorAnim.SetTrigger("Door Open"); // Trigger the door open animation
            keyPadNumber = "";

            doorLock.SetActive(false); // Disable the door lock
        }
        else
        {
            keyPadNumber = ""; // Reset
            Debug.Log("��� ��ȣ ����");
        }

    }
}
