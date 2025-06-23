using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private float _minimumX = -2f;
    private float _maximumX = 2f;
    private float _movingSpeed = 3f;

    private void Update()
    {
        // 1. 현재 위치 가져오기
        Vector3 currentPosition = transform.position;

        // 2. x축으로 이동할 양 계산
        float movingAmount = _movingSpeed * Time.deltaTime;

        // 3. 이동할 양을 현재 위치에 더한다.
        currentPosition.x += movingAmount;

        // 4. 최댓값, 최솟값 처리를 해준다.
        if (currentPosition.x < _minimumX)
        {
            currentPosition.x = _minimumX;
            _movingSpeed *= -1f;
        }
        else if (currentPosition.x > _maximumX)
        {
            currentPosition.x = _maximumX;
            _movingSpeed *= -1f;
        }

        // 5. 위치 적용
        transform.position = currentPosition;
    }
}
