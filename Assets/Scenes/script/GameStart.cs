using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStart : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource effectSound;

    void Start()
    {
        backgroundMusic.Play(); // 씬 시작 시 배경음악 재생

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter키 눌림");
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // 배경음악 멈춤
            Debug.Log("배경음악 멈춤");
        }

        if (effectSound != null)
        {
            Debug.Log("효과음 찾음");
            effectSound.Play(); // 효과음 재생
            Debug.Log("효과음 나오는 중임, 볼륨: " + effectSound.volume + ", 길이: " + effectSound.clip.length);
            yield return new WaitForSeconds(effectSound.clip.length); // 효과음 재생이 끝날 때까지 대기
        }
        else
        {
            Debug.LogError("효과음 못찾음");
        }

        SceneManager.LoadScene("second"); // "GameScene"을 실제 게임 씬 이름으로 변경하세요.
    }
}