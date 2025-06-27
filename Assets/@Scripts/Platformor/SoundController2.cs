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
        foreach (var clip in clips) // clips �迭�� ��ȸ
        {
            if (clip.name == clipName) // ���� �̸��� ��ġ�ϴ��� Ȯ��
            {
                bgmAudio.clip = clip; // ��ġ�ϴ� Ŭ���� bgmAudio�� �Ҵ�
                bgmAudio.Play(); // BGM ���
                return; // Ŭ���� ã���� �Լ� ����
            }
        }

        Debug.Log($"{clipName}�� ã�� ���߽��ϴ�."); // Ŭ���� ã�� ������ �� �α� ���
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

        Debug.Log($"{clipName}�� ã�� ���߽��ϴ�.");
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
