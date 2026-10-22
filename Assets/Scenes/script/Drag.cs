using UnityEngine;

public class DragAndCollision : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    public AudioSource audioSource; // 효과음을 재생할 오디오 소스
    public AudioClip collisionSound; // 재생할 효과음

    void Update()
    {
        // 마우스 클릭 시 드래그 시작
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            // 클릭한 오브젝트가 이 스크립트를 가진 오브젝트일 때 드래그 시작
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                offset = transform.position - mousePos;
                isDragging = true;
            }
        }

        // 드래그 중일 때 오브젝트 위치 업데이트
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }

        // 마우스 버튼을 놓으면 드래그 중지
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    // 충돌을 감지하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 태그가 'amp'일 때
        if (collision.gameObject.CompareTag("amp"))
        {
            // 효과음 재생
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
