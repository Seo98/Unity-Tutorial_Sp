using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬 관리 네임스페이스 추가

public class PotalController : MonoBehaviour
{
    public enum SceneType { TOWN, ADVENTURE }
    public SceneType sceneType = SceneType.TOWN;

    public GameObject potalEffect;
    public FadeRoutine2 fade;
    public GameObject loadingImage;

    public Image progessBar; // 로딩 프로그레스 바

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
        yield return StartCoroutine(fade.Fade(3f, Color.white, false)); // 페이드 오프


        // 로딩 이미지 활성화
        while (progessBar.fillAmount < 1f)
        {
            progessBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }
        // 씬 변경

        SceneManager.LoadScene(1); // 다음 씬으로 변경 (씬 이름은 예시로 사용)


    }
}

