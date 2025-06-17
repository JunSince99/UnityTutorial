using System;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPower = 10f;
    public bool isGround = false;
    
    public int jumpCount = 2;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            soundManager.OnJumpSound();
            catAnim.SetTrigger("Jump");

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse); //(힘의 값, 힘을 가하는 방식식)
            jumpCount++; // 1씩 증가
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", false);
            isGround = false;
        }
    }
}