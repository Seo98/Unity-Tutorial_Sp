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
            audioSource.clip = bgmClip; //���ϼ���
            audioSource.playOnAwake = true; // �����Ҷ� �ڵ����� ���
            audioSource.loop = true; // �ݺ����
            audioSource.volume = 0.1f; // ��������

            audioSource.Play(); // ���
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
