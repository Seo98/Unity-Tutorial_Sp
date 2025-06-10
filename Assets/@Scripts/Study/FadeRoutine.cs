using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // UI ��Ҹ� ����ϱ� ���� �߰�
public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadetime, Color color)
    {
        StartCoroutine(OutroFadeRoutine(fadetime, color));
    }
    private IEnumerator OutroFadeRoutine(float fadetime, Color color)
    {
        float percent = 0f; // ���̵� ����� (0.0f ~ 1.0f)
        float timer = 0f; // Ÿ�̸�
        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadetime; // ����� ���

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
    }
}