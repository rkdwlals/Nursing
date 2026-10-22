using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        // 씬 시작 시 대화 설정
        string SceneName = SceneManager.GetActiveScene().name;
        if (SceneName == "Second") 
        {
            string[] sceneDialogue = {
                "시작하기에 앞서 손을 씻자!",
                "좌클릭 우클릭을 번갈아 누르며 손 씻기를 시작해보자! ",
                "좌클릭 우클릭 30번 시작!"
            };
            dialogueManager.SetDialogueLines(sceneDialogue);
        }
    }
}
