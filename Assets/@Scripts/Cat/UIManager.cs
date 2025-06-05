using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject PlayObj;
        public GameObject IntroObj;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;


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
                PlayObj.SetActive(true);
                IntroObj.SetActive(false);

                Debug.Log(nameTextUI);
                nameTextUI.text = inputField.text;
            }

        }

    }
}