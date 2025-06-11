using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen; // 비디오 스크린 게임오브젝트 접근

    public Button[] buttonUI; // UI 버튼 배열

    private VideoPlayer videoPlayer; // 
    public VideoClip[] clips; // 영상파일배열

    public int currClipIndex = 0;



    // public bool isOn = false;  //if로 조건문쓸때 필요
    public bool isMute = false;


    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {
        /*if (!isOn)
        {
            isOn = true;
            videoScreen.SetActive(true);
        }
        else
        {
            videoScreen.SetActive(false);
            isOn = false;
        }*/

        // 숏코딩 논리 부정 연산자 !는 피연산자가 false이면 true로 바뀌고, true이면 false로
        // 게임오브젝트 속성 활용

        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoScreen.GetComponent<VideoPlayer>().SetDirectAudioMute(0, isMute);

        // 현재 영상의 Mute 속성을 활용한 방법
        // videoPlayer.SetDirectAudio(0, !videoPlayer.GetDirectAudioMute )
    }

    public void OnNextChannel()
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1) currClipIndex = 0;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel()
    {
        currClipIndex--;
        if (currClipIndex < 0) currClipIndex = clips.Length - 1;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }


     // 통합버전

    /* public void OnChangeChannel(bool isNext)
     {
         int value = isNext ? 1 : -1; // 삼항연산자
         currClipIndex += value;
    
         if (currClipIndex > clips.Length - 1)
             currClipIndex = 0;
    
         if (currClipIndex < 0)
             currClipIndex = clips.Length - 1;
    
         videoPlayer.clip = clips[currClipIndex];
         videoPlayer.Play();
     }*/

}
