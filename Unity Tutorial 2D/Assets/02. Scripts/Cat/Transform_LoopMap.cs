using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        // 배경 왼쪽으로
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < -30)
        {
            transform.position += Vector3.right * 60;
        }
    }
}
