using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 5f;

    public bool isStop;

    void Start()
    {
        rotSpeed  = 0f;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); // forward = Z축 기준으로 회전


        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭시 회전 시작
        {
            rotSpeed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if (isStop == true)
        {
            rotSpeed *= 0.98f;
            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}