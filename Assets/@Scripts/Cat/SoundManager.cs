using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip bgmClip;
        public AudioClip jumpClip;


        void Start()
        {
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; //파일설정
            audioSource.playOnAwake = true; // 시작할때 자동으로 재생
            audioSource.loop = true; // 반복재생
            audioSource.volume = 0.1f; // 볼륨설정

            audioSource.Play(); // 재생
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
