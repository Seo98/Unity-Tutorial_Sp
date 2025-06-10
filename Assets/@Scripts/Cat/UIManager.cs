using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager; // SoundManager를 참조하기 위한 변수

        public GameObject PlayObj;
        public GameObject IntroObj;
        public GameObject playUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Awake()
        {
            PlayObj.SetActive(false);
            IntroObj.SetActive(true);
            playUI.SetActive(false);
        }
        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if(isNoText)
            {
                Debug.Log("이름을 입력해주세요;;;;");
            }
            else
            {
                nameTextUI.text = inputField.text;
                soundManager.SetBGMSound("Play"); // 게임 시작 시 배경음악 설정

                GameManager.isPlay = true;

                PlayObj.SetActive(true);
                playUI.SetActive(true);
                IntroObj.SetActive(false);


                
            }

        }

    }
}