using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager; // SoundManager�� �����ϱ� ���� ����

        public GameObject PlayObj;
        public GameObject IntroObj;
        public GameObject playUI;
        public GameObject videoPanel;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;
        public Button restartButton;

        private void Awake()
        {
            PlayObj.SetActive(false);
            IntroObj.SetActive(true);
            playUI.SetActive(false);
        }
        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
            restartButton.onClick.AddListener(OnRestartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if(isNoText)
            {
                Debug.Log("�̸��� �Է����ּ���;;;;");
            }
            else
            {
                nameTextUI.text = inputField.text;
                soundManager.SetBGMSound("Play"); // ���� ���� �� ������� ����

                GameManager.isPlay = true;

                PlayObj.SetActive(true);
                playUI.SetActive(true);
                IntroObj.SetActive(false);


                
            }

        }

        public void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            PlayObj.SetActive(true);
            videoPanel.SetActive(false);
        }

    }
}