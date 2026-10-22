using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 사용을 위한 네임스페이스

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI talkText; // TextMeshProUGUI로 변경
    public string[] dialogueLines; // 대사 목록
    private int currentLineIndex = 0; // 현재 대사 인덱스
    public AudioSource effect; // 효과음
    private bool audioPlayed = false; // 오디오 재생 여부 플래그

    void Start()
    {
        // 필요시 Start에서 초기 설정 가능
        if (dialogueLines != null && dialogueLines.Length > 0)
        {
            currentLineIndex = 0; // 대사 인덱스 초기화
            DisplayNextDialogue(); // 첫 대사를 표시
        }
        else
        {
            Debug.LogWarning("Dialogue lines are not set or empty.");
        }
    }

    void Update()
    {
        // 좌클릭이 감지되는지 확인하고 오디오가 아직 재생되지 않았을 때만 실행
        if (Input.GetMouseButtonDown(0) && !audioPlayed)
        {
            Debug.Log("좌클릭 감지"); // 좌클릭 입력 확인
            PlayEffectSound(); // 효과음 재생
            audioPlayed = true; // 오디오가 재생되었음을 표시
        }

        // 대사를 넘기기 위한 Enter 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter 눌림"); // E 키 입력 확인
            DisplayNextDialogue(); // 다음 대사 표시
        }
    }

    public void DisplayNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            talkText.text = dialogueLines[currentLineIndex];
            Debug.Log("대사: " + dialogueLines[currentLineIndex]); // 디버그 로그 추가
            currentLineIndex++;
        }
        else
        {
            // 모든 대화가 끝났을 때 마지막 대사를 유지하고 추가로 지우지 않음
            Debug.Log("대화창 끝남");
        }
    }

    // 효과음을 재생하는 메서드
    private void PlayEffectSound()
    {
        if (effect != null)
        {
            effect.Play();
            Debug.Log("재생");
        }
        else
        {
            Debug.LogWarning("소리 설정 봐라");
        }
    }

    public void SetDialogueLines(string[] lines)
    {
        dialogueLines = lines;
        currentLineIndex = 0;
        talkText.text = ""; // 텍스트 초기화
        DisplayNextDialogue(); // 첫 대사를 바로 표시
    }
}
