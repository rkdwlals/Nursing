using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owari : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.anyKeyDown)
        {
            ExitApplication();
        }

        // 마우스 클릭이 있는지 확인
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            ExitApplication();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExitApplication()
    {
#if UNITY_EDITOR
        // Unity 에디터에서 실행 중일 경우 에디터 정지
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 애플리케이션에서 실행 중일 경우 애플리케이션 종료
        Application.Quit();
#endif
    }
}
