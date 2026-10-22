using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer targetRenderer; // 변경할 스프라이트 렌더러 오브젝트
    public Sprite newSprite;  // 클릭 후 변경될 스프라이트

    private Sprite originalSprite; // 원래 스프라이트를 저장해둠

    void Start()
    {
        // 원래 스프라이트를 저장합니다.
        originalSprite = targetRenderer.sprite;
    }

    // 이 함수는 스프라이트가 클릭될 때 호출됩니다.
    public void ChangeSprite()
    {
        if (targetRenderer.sprite == originalSprite)
        {
            targetRenderer.sprite = newSprite;
        }
        else
        {
            targetRenderer.sprite = originalSprite;
        }
    }

    // 오브젝트가 클릭될 때 호출되는 함수
    private void OnMouseDown()
    {
        Debug.Log("Object Clicked!"); // 클릭 이벤트 확인
        ChangeSprite();
    }
}
