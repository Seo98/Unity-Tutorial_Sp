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
                audioSource.clip = introBgmClip; // ���ϼ���
            }
            else if (bgmName == "Play")
            {
                audioSource.clip = playBgmClip; //���ϼ���
            }

            audioSource.loop = true; // �ݺ����
            audioSource.volume = 0.1f; // ��������
            audioSource.Play(); // ���
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
