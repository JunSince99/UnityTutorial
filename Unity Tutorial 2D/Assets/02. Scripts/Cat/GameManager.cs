using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;
        
        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;
        public TextMeshProUGUI jumpCountUI;
        
        private static float timer;
        public static int score; // 사과를 먹은 개수
        public static bool isPlay;

        void Start()
        {
            soundManager.SetBGMSound("Intro");
        }

        void Update()
        {
            if (!isPlay)
                return;

            timer += Time.deltaTime;
            playTimeUI.text = $"플레이 시간 : {timer:F1}초";
            scoreUI.text = $"X {score}";
            jumpCountUI.text = $"점프 횟수 : {CatController.jumpCount} / 10회";
        }

        public static void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }
    }
}