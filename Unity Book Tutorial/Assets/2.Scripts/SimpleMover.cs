using UnityEngine;

public class SimpleMover : MonoBehaviour
{

    private const float SPEED = 10;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0 || horizontalInput > 0)
        {
            float movementDistance = horizontalInput * SPEED * Time.deltaTime;
            transform.position += new Vector3(movementDistance, 0, 0);
        }
    }
}
