using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� �߰�


namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager; // SoundManager�� �����ϱ� ���� ����

        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private float timer;
        public static int score = 0; // ���� ����
        public static bool isPlay;

        private void Update()
        {
            if(!isPlay) return; // ������ ���� ������ ������ ������Ʈ���� ����

            timer += Time.deltaTime; // Ÿ�̸� ������Ʈ
            playTimeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer);
            scoreUI.text = $"X {score}";
        }

        void Start()
        {
            soundManager.SetBGMSound("Intro"); // ���� ���� �� ������� ����
        }


    }
}