using UnityEngine;
using System;
using System.Collections;

public class InterActionEvent : MonoBehaviour
{

    public enum InteractionType { SIGN, DOOR, NPC }
    public InteractionType type;

    public FadeRoutine2 fade;

    public SoundController2 soundController2; // ���� ��Ʈ�ѷ� �ν��Ͻ�

    public GameObject Popup; // �˾� UI ������Ʈ
    public GameObject map; // �� ������Ʈ(Ÿ�ϸ�)
    public GameObject house; // �� ������Ʈ(Ÿ�ϸ�)

    public Vector3 inDoorPos; // �� �ȿ��� �÷��̾ ������ ��ġ
    public Vector3 outDoorPos; // �� �ۿ��� �÷��̾ ������ ��ġ
    public bool isHouse; // ���� �� �ȿ� �ִ��� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Popup.SetActive(false);
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                Popup.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRoutine(player));

                break;
            case InteractionType.NPC:
                Popup.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        soundController2.EventSoundPlay("Open Door 7"); // �� ���� ���� ���

        yield return StartCoroutine(fade.Fade(3f, Color.black, true));

        map.SetActive(isHouse); // ���� Ȱ��ȭ/��Ȱ��ȭ
        house.SetActive(!isHouse); // ���� Ȱ��ȭ/��Ȱ��ȭ

        var pos = isHouse ? outDoorPos : inDoorPos; // ��ġ�� ���� pos��ġ�� ���� �÷��̾� ��ġ�� ����
        player.transform.position = pos; // �÷��̾� ��ġ�� ����

        isHouse = !isHouse; // isHouse ���¸� ������Ŵ

        yield return new WaitForSeconds(1f); // ��� ���
        soundController2.EventSoundPlay("Close Door 2"); // �� �ݱ� ���� ���

        yield return StartCoroutine(fade.Fade(3f, Color.black, false)); // ���̵� �ƿ�
    }

}
