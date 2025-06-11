using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen; // ���� ��ũ�� ���ӿ�����Ʈ ����

    public Button[] buttonUI; // UI ��ư �迭

    private VideoPlayer videoPlayer; // 
    public VideoClip[] clips; // �������Ϲ迭

    public int currClipIndex = 0;



    // public bool isOn = false;  //if�� ���ǹ����� �ʿ�
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

        // ���ڵ� �� ���� ������ !�� �ǿ����ڰ� false�̸� true�� �ٲ��, true�̸� false��
        // ���ӿ�����Ʈ �Ӽ� Ȱ��

        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoScreen.GetComponent<VideoPlayer>().SetDirectAudioMute(0, isMute);

        // ���� ������ Mute �Ӽ��� Ȱ���� ���
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


     // ���չ���

    /* public void OnChangeChannel(bool isNext)
     {
         int value = isNext ? 1 : -1; // ���׿�����
         currClipIndex += value;
    
         if (currClipIndex > clips.Length - 1)
             currClipIndex = 0;
    
         if (currClipIndex < 0)
             currClipIndex = clips.Length - 1;
    
         videoPlayer.clip = clips[currClipIndex];
         videoPlayer.Play();
     }*/

}
