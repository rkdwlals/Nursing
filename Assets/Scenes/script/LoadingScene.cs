using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // 이동할 씬 이름 (유니티에서 설정 가능)
    public AudioClip bgm; // 배경 음악 파일 (유니티에서 설정)

    private void Start()
    {
        PlayBGM(); // 음악 재생
        Invoke("LoadNextScene", 5f); // 5초 후 씬 변경
    }

    void PlayBGM()
    {
        if (bgm != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = bgm;
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("배경 음악이 설정되지 않았습니다!");
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName); // 지정한 씬으로 이동
    }
}
