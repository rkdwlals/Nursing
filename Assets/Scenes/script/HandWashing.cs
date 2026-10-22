using UnityEngine;
using System.Collections;

public class HandWashing : MonoBehaviour
{
    private bool isUp = false; // 현재 손의 상태 (위인지 아래인지)
    private float moveDistance = 0.3f; // 손이 위아래로 이동하는 거리
    private float moveDuration = 0.1f; // 손이 이동하는 속도 (짧을수록 빠름)

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) // 좌클릭 또는 우클릭 감지
        {
            StartCoroutine(MoveHands());
        }
    }

    IEnumerator MoveHands()
    {
        GameObject[] leftHands = GameObject.FindGameObjectsWithTag("left");
        GameObject[] rightHands = GameObject.FindGameObjectsWithTag("right");

        float leftTargetY = isUp ? -moveDistance : moveDistance;   // 왼손 이동 방향
        float rightTargetY = isUp ? moveDistance : -moveDistance;  // 오른손 이동 방향

        float elapsedTime = 0f;
        Vector3[] leftStartPositions = new Vector3[leftHands.Length];
        Vector3[] rightStartPositions = new Vector3[rightHands.Length];

        for (int i = 0; i < leftHands.Length; i++)
        {
            leftStartPositions[i] = leftHands[i].transform.position;
        }

        for (int i = 0; i < rightHands.Length; i++)
        {
            rightStartPositions[i] = rightHands[i].transform.position;
        }

        while (elapsedTime < moveDuration) // 지정된 시간 동안 이동
        {
            float t = elapsedTime / moveDuration; // 0~1 사이의 보간값
            for (int i = 0; i < leftHands.Length; i++)
            {
                Vector3 newPos = leftStartPositions[i];
                newPos.y += leftTargetY * t;
                leftHands[i].transform.position = newPos;
            }

            for (int i = 0; i < rightHands.Length; i++)
            {
                Vector3 newPos = rightStartPositions[i];
                newPos.y += rightTargetY * t;
                rightHands[i].transform.position = newPos;
            }

            elapsedTime += Time.deltaTime;
            yield return null; // 한 프레임 대기
        }

        isUp = !isUp; // 상태 변경 (위 -> 아래, 아래 -> 위)
    }
}
