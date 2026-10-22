using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D collider2D;
    Vector3 offset;
    public string destinationTag = "Cart";
    public string fakeTag = "Fake";
    public string goodTagPrefix = "Good";
    public float dragZPosition = -1.0f;
    public bool isInCart = false;
    private bool isInNonCountZone = false;
    private bool isFake = false;
    private bool isGood = false;
    private string goodTag = "";

    private static Vector3 nextOffset = Vector3.zero;
    private Vector3 originalPosition;

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        originalPosition = transform.position;

        // 태그에 따라 물품 상태 설정
        if (CompareTag(fakeTag))
        {
            isFake = true;
        }
        else if (tag.StartsWith(goodTagPrefix))
        {
            isGood = true;
            goodTag = tag;
        }

        // GameManager 인스턴스가 존재할 때만 등록
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterDraggableObject(this);
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = MouseWorldPosition() + offset;
        newPosition.z = dragZPosition;
        transform.position = newPosition;
    }

    void OnMouseUp()
    {
        collider2D.enabled = false;

        Vector3 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rayDirection = Vector3.forward;

        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);
        if (hitInfo)
        {
            if (hitInfo.transform.CompareTag(destinationTag) && !isInNonCountZone)
            {
                Vector3 newPosition = hitInfo.transform.position + new Vector3(-3, 0, -0.01f) + nextOffset;
                newPosition.z = dragZPosition;
                transform.position = newPosition;

                nextOffset += new Vector3(1.3f, 0f, 0);

                if (!isInCart)
                {
                    isInCart = true;
                    GameManager.Instance.ObjectEnteredCart();

                    if (isFake)
                    {
                        GameManager.Instance.FakeItemEnteredCart();
                    }
                    else if (isGood)
                    {
                        GameManager.Instance.GoodItemEnteredCart(); // 인수 없이 호출
                    }
                }
            }
            else
            {
                if (isInCart)
                {
                    isInCart = false;
                    GameManager.Instance.ObjectExitedCart();

                    if (isFake)
                    {
                        GameManager.Instance.FakeItemExitedCart();
                    }
                    else if (isGood)
                    {
                        GameManager.Instance.GoodItemExitedCart();
                    }

                    ResetPosition();
                }
            }
        }

        collider2D.enabled = true;
    }

    public void SetNonCountZone(bool inNonCountZone)
    {
        isInNonCountZone = inNonCountZone;

        if (isInNonCountZone && isInCart)
        {
            isInCart = false;
            GameManager.Instance.ObjectExitedCart();

            if (isFake)
            {
                GameManager.Instance.FakeItemExitedCart();
            }
            else if (isGood)
            {
                GameManager.Instance.GoodItemExitedCart();
            }

            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        nextOffset = Vector3.zero;
        isInCart = false;
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
