using UnityEngine;

public class NonCountZonePanel : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Panel의 RectTransform을 가져옴
    }

    // 논카운트 존에 물체가 있는지 확인
    public bool IsInsideNonCountZone(Vector3 worldPosition)
    {
        // 월드 좌표를 UI 좌표로 변환
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, worldPosition, null, out localPoint);

        // Panel RectTransform의 영역 안에 있는지 확인
        return rectTransform.rect.Contains(localPoint);
    }
}
