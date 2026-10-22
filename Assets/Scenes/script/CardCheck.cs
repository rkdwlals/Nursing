using UnityEngine;

public class CardCheck : MonoBehaviour
{
    public GameObject uiPanel; // UI 패널을 참조하는 변수

    // UI 패널 활성화 상태 초기화
    void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // 초기에는 UI 패널을 비활성화
        }
    }

    // R키를 눌렀을 때 UI 패널 활성/비활성 토글
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (uiPanel != null)
            {
                // 현재 상태의 반대로 UI 패널 활성화 상태를 토글
                uiPanel.SetActive(!uiPanel.activeSelf);
            }
        }
    }
}
