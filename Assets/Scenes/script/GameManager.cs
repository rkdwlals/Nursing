using System.Collections.Generic; // List 사용을 위한 네임스페이스 추가
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager 사용을 위한 네임스페이스 추가
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int objectsInCart = 0;
    private int fakeItemCount = 0;
    private int goodItemCount = 0;
    private int totalGoodItemCount; // 모든 Good 물품 수를 저장할 변수
    public TextMeshProUGUI warningText;

    private List<DragAndDrop> draggableObjects = new List<DragAndDrop>(); // 드래그 가능한 오브젝트들을 저장할 리스트

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }

        // 'Good' 태그가 붙은 모든 오브젝트를 찾고 totalGoodItemCount 설정
        totalGoodItemCount = GameObject.FindGameObjectsWithTag("Good").Length;
    }

    // 드래그 가능한 오브젝트를 등록하는 메서드
    public void RegisterDraggableObject(DragAndDrop obj)
    {
        if (!draggableObjects.Contains(obj))
        {
            draggableObjects.Add(obj);
        }
    }

    public void ResetCart()
    {
        objectsInCart = 0;
        fakeItemCount = 0;
        goodItemCount = 0;

        // draggableObjects 리스트에 있는 모든 오브젝트의 상태를 초기화
        foreach (var obj in draggableObjects)
        {
            obj.ResetPosition();
        }

        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }

        Debug.Log("카트 상태가 초기화되었습니다.");
    }

    // 오브젝트가 Cart에 들어갔을 때 호출
    public void ObjectEnteredCart()
    {
        objectsInCart++;
        CheckAllObjectsInCart();
    }

    // 오브젝트가 Cart에서 나갔을 때 호출
    public void ObjectExitedCart()
    {
        if (objectsInCart > 0)
        {
            objectsInCart--;
        }
        CheckAllObjectsInCart();
    }

    // Fake 물품이 Cart에 들어갔을 때 호출
    public void FakeItemEnteredCart()
    {
        fakeItemCount++;
        Debug.Log("Fake 물품이 Cart에 들어갔습니다.");
        CheckAllObjectsInCart();
    }

    // Fake 물품이 Cart에서 나갔을 때 호출
    public void FakeItemExitedCart()
    {
        if (fakeItemCount > 0)
        {
            fakeItemCount--;
        }
        Debug.Log("Fake 물품이 Cart에서 나갔습니다.");
        CheckAllObjectsInCart();
    }

    // Good 물품이 Cart에 들어갔을 때 호출
    public void GoodItemEnteredCart()
    {
        goodItemCount++;
        CheckAllObjectsInCart();
    }

    // Good 물품이 Cart에서 나갔을 때 호출
    public void GoodItemExitedCart()
    {
        if (goodItemCount > 0)
        {
            goodItemCount--;
        }
        Debug.Log("Good 물품이 Cart에서 나갔습니다.");
        CheckAllObjectsInCart();
    }

    // 모든 드래그 가능한 오브젝트가 Cart 안에 있는지 확인
    public void CheckAllObjectsInCart()
    {
        Debug.Log($"Cart에 있는 오브젝트 수: {objectsInCart}, 전체 오브젝트 수: {draggableObjects.Count}, Fake 물품 수: {fakeItemCount}, Good 물품 수: {goodItemCount}/{totalGoodItemCount}");

        // 모든 Good 물품이 카트에 있고, Fake 물품이 없을 때 씬 전환
        if (goodItemCount == totalGoodItemCount && fakeItemCount == 0)
        {
            Debug.Log("모든 Good 물품이 카트에 있고 Fake 물품이 없습니다. 씬 전환 중...");
            SceneManager.LoadScene("Load2"); // 씬 전환
        }
        else if (fakeItemCount > 0)
        {
            Debug.Log("Fake 물품이 있어 씬 전환 불가.");
            if (warningText != null)
            {
                warningText.gameObject.SetActive(true); // 경고 메시지 활성화
                warningText.text = "함정이 있으니 조심하자"; // 경고 메시지 텍스트 설정
            }
        }
        else
        {
            if (warningText != null)
            {
                warningText.gameObject.SetActive(false); // 경고 메시지 비활성화
            }
        }
    }
}
