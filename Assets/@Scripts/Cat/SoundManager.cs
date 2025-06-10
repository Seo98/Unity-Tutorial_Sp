using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip introBgmClip;
        public AudioClip playBgmClip;

        public AudioClip ColliderClip;
        public AudioClip jumpClip;

        public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
            {
                audioSource.clip = introBgmClip; // 파일설정
            }
            else if (bgmName == "Play")
            {
                audioSource.clip = playBgmClip; //파일설정
            }

            audioSource.loop = true; // 반복재생
            audioSource.volume = 0.1f; // 볼륨설정
            audioSource.Play(); // 재생
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(ColliderClip);
        }
    }
}
