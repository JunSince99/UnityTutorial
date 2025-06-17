using UnityEngine;
using UnityEngine.EventSystems;

public class VirtyalJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private const float _maxMagnitude = 100f;
    private const float SPEED = 10;

    [SerializeField]
    private RectTransform _handle;
    [SerializeField]
    private Transform _player;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("onDrag!");
        _handle.anchoredPosition += eventData.delta;

        Vector2 currentPosition = _handle.anchoredPosition;
        float currentMagnitude = Mathf.Sqrt(currentPosition.x * currentPosition.x + currentPosition.y * currentPosition.y);
        float currentAngleRadian = Mathf.Atan2(currentPosition.y, currentPosition.x);

        //최대 길이 벡터 생성
        float clampedMagnitude = Mathf.Min(currentMagnitude, _maxMagnitude);
        var clampedPosition = new Vector2(clampedMagnitude * Mathf.Cos(currentAngleRadian),
        clampedMagnitude * Mathf.Sin(currentAngleRadian));

        //위치를 구한 벡터로 설정
        _handle.anchoredPosition = clampedPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _handle.anchoredPosition = Vector3.zero;
    }

    public void Update()
    {
        float horiinput = _handle.anchoredPosition.x / _maxMagnitude;
        if (horiinput != 0)
        { 
            float movementDistance = horiinput * SPEED * Time.deltaTime;
            _player.position += new Vector3(movementDistance, 0, 0);
        }
    }
}