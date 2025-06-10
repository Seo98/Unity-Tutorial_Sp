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

    }
}