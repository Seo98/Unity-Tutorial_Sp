using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // UI ��Ҹ� ����ϱ� ���� �߰�
public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadetime, Color color, bool isFadeStart)
    {
        //StopAllCoroutines();

        StartCoroutine(OutroFadeRoutine(fadetime, color, isFadeStart));
    }
    private IEnumerator OutroFadeRoutine(float fadetime, Color color, bool isFadeStart)
    {
        float percent = 0f; // ���̵� ����� (0.0f ~ 1.0f)
        float timer = 0f; // Ÿ�̸�


        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadetime; // ����� ���
            float value = isFadeStart ? percent : 1 - percent;

            fadePanel.color = new Color(color.r, color.g, color.b, value);
            yield return null;
        }
    }
}