using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    private Vector3 startPos;
    private float timer, percent;
    public float lertTime;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        percent = timer / lertTime;

        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}