using UnityEngine;
using UnityEngine.UI;

public class SoundController2 : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource eventAudio;

    [SerializeField] private AudioClip[] clips;

    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Slider eventVolume;

    [SerializeField] private Toggle bgmToggle;
    [SerializeField] private Toggle eventToggle;

    void Awake()
    {
        bgmVolume.value = bgmAudio.volume;
        eventVolume.value = eventAudio.volume;

        bgmToggle.isOn = bgmAudio.mute;
        eventToggle.isOn = eventAudio.mute;
    }

    void Start()
    {
        BgmSoundPlay("02 Welcome to Town");

        bgmVolume.onValueChanged.AddListener(OnvolumeChangeBGM);
        eventVolume.onValueChanged.AddListener(OnEventVolumeChange);
        bgmToggle.onValueChanged.AddListener(ToggleBGM);
        eventToggle.onValueChanged.AddListener(ToggleEvent);
    }

    public void BgmSoundPlay(string clipName)
    {
        foreach (var clip in clips) // clips 배열을 순회
        {
            if (clip.name == clipName) // 파일 이름이 일치하는지 확인
            {
                bgmAudio.clip = clip; // 일치하는 클립을 bgmAudio에 할당
                bgmAudio.Play(); // BGM 재생
                return; // 클립을 찾으면 함수 종료
            }
        }

        Debug.Log($"{clipName}을 찾지 못했습니다."); // 클립을 찾지 못했을 때 로그 출력
    }

    public void EventSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                eventAudio.PlayOneShot(clip);
                return;
            }
        }

        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }


    private void OnvolumeChangeBGM(float volume)
    {
        bgmAudio.volume = volume;
    }

    private void OnEventVolumeChange(float volume)
    {
        eventAudio.volume = volume;
    }

    public void ToggleBGM(bool isMute)
    {
        bgmAudio.mute = isMute;
    }

    public void ToggleEvent(bool isMute)
    {
        eventAudio.mute = isMute;
    }




}
