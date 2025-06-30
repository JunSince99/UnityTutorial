using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick_Controller : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private KnightControllelr_Joystick knightController;

    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    private Vector2 startPos, curPos;


    void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        backgroundUI.transform.position = startPos;
        backgroundUI.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        curPos = eventData.position;
        Vector2 dragDir = curPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f);
        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;
        knightController.InputJoystick(dragDir.x, dragDir.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
        knightController.InputJoystick(0, 0);
    }
}