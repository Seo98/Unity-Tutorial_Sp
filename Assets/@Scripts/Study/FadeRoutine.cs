using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // UI 요소를 사용하기 위해 추가
public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadetime, Color color)
    {
        StartCoroutine(OutroFadeRoutine(fadetime, color));
    }
    private IEnumerator OutroFadeRoutine(float fadetime, Color color)
    {
        float percent = 0f; // 페이드 진행률 (0.0f ~ 1.0f)
        float timer = 0f; // 타이머
        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadetime; // 진행률 계산

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
    }
}