using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 추가


namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager; // SoundManager를 참조하기 위한 변수

        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private float timer;
        public static int score = 0; // 점수 변수
        public static bool isPlay;

        private void Update()
        {
            if(!isPlay) return; // 게임이 진행 중이지 않으면 업데이트하지 않음

            timer += Time.deltaTime; // 타이머 업데이트
            playTimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            scoreUI.text = $"X {score}";
        }

        void Start()
        {
            soundManager.SetBGMSound("Intro"); // 게임 시작 시 배경음악 설정
        }


    }
}