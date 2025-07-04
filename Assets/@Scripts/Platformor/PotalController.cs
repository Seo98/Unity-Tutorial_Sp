using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �� ���� ���ӽ����̽� �߰�

public class PotalController : MonoBehaviour
{
    public enum SceneType { TOWN, ADVENTURE }
    public SceneType sceneType = SceneType.TOWN;

    public GameObject potalEffect;
    public FadeRoutine2 fade;
    public GameObject loadingImage;

    public Image progessBar; // �ε� ���α׷��� ��

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        potalEffect.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, true));

        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, false)); // ���̵� ����


        // �ε� �̹��� Ȱ��ȭ
        while (progessBar.fillAmount < 1f)
        {
            progessBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }
        // �� ����

        SceneManager.LoadScene(1); // ���� ������ ���� (�� �̸��� ���÷� ���)


    }
}

