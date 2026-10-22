using UnityEngine;
using TMPro;
using System.Collections;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI text; // 깜빡이게 할 텍스트

    void Start()
    {
        if (text != null)
        {
            StartCoroutine(BlinkText());
        }
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            text.enabled = !text.enabled;
            yield return new WaitForSeconds(0.7f); // 깜빡이는 주기 설정
        }
    }
}
