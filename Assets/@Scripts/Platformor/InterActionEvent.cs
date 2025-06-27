using UnityEngine;
using System;
using System.Collections;

public class InterActionEvent : MonoBehaviour
{

    public enum InteractionType { SIGN, DOOR, NPC }
    public InteractionType type;

    public FadeRoutine2 fade;

    public SoundController2 soundController2; // 사운드 컨트롤러 인스턴스

    public GameObject Popup; // 팝업 UI 오브젝트
    public GameObject map; // 맵 오브젝트(타일맵)
    public GameObject house; // 집 오브젝트(타일맵)

    public Vector3 inDoorPos; // 집 안에서 플레이어가 시작할 위치
    public Vector3 outDoorPos; // 집 밖에서 플레이어가 시작할 위치
    public bool isHouse; // 현재 집 안에 있는지 여부

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
        soundController2.EventSoundPlay("Open Door 7"); // 문 열기 사운드 재생

        yield return StartCoroutine(fade.Fade(3f, Color.black, true));

        map.SetActive(isHouse); // 맵을 활성화/비활성화
        house.SetActive(!isHouse); // 집을 활성화/비활성화

        var pos = isHouse ? outDoorPos : inDoorPos; // 위치를 변경 pos위치에 따라 플레이어 위치를 변경
        player.transform.position = pos; // 플레이어 위치를 변경

        isHouse = !isHouse; // isHouse 상태를 반전시킴

        yield return new WaitForSeconds(1f); // 잠시 대기
        soundController2.EventSoundPlay("Close Door 2"); // 문 닫기 사운드 재생

        yield return StartCoroutine(fade.Fade(3f, Color.black, false)); // 페이드 아웃
    }

}
