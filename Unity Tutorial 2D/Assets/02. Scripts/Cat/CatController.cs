using System;
using System.Collections;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    
    private Rigidbody2D catRb;
    private Animator catAnim;
    
    public static int jumpCount = 0;
    public float jumpPower = 10f;
    
    void Awake() // 1번만 실행
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    
    void OnEnable() // 켜질때마다 1번씩 실행
    {
        catRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        transform.position = new Vector3(-6.73f, 0.59f, 0); // 고양이 처음 위치

        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.Play();
    }

    void Update()
    {
        if (!GameManager.isPlay)
        {
            return;
        }

        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 10)
        {
            catAnim.SetTrigger("Jump"); // 점프 애니메이션 시작
            catAnim.SetBool("isGround", false); // 
            jumpCount++;
            soundManager.OnJumpSound();
            catRb.linearVelocity = new Vector2(catRb.linearVelocityX, 0f);
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

            // if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
            //     catRb.linearVelocityY = limitPower;
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);
            
            GameManager.score++;
            
            if (GameManager.score == 10) // 사과를 10개 먹어서 성공
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white, true);
                GetComponent<CircleCollider2D>().enabled = false;
                
                StartCoroutine(EndingRoutine(true));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe")) // 파이프에 부딪혀서 실패
        {
            if (other.contacts[0].normal.y > 0.4f)
            {
                catAnim.SetBool("isGround", true);
                jumpCount = 0;
            }
            else
            {
                soundManager.OnColliderSound();
                GameManager.isPlay = false;
                gameOverUI.SetActive(true); // 게임 오버 문구 켜기
                fadeUI.SetActive(true); // 페이드 켜기
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true); // 페이드 실행

                // 죽으면 뒤집어 지면서 한번 위로 튕기기
                transform.eulerAngles = new Vector3(0, 0, 180);
                catRb.linearVelocity = Vector2.zero;
                catRb.constraints = RigidbodyConstraints2D.None; // x축 이동제한 풀기
                catRb.AddForce(new Vector2(-2f, 10f), ForceMode2D.Impulse);
                GetComponent<CircleCollider2D>().enabled = false;
                
                StartCoroutine(EndingRoutine(false));
            }
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);
        videoManager.VideoPlay(isHappy); // 영상 재생 시작
        transform.parent.gameObject.SetActive(false); // PLAY 오브젝트 Off
        soundManager.audioSource.Stop();
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
}