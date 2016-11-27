using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Canvas winCanvas;
        public AudioPlayerLib winAudioLib;
        public bool lastScene;

        [Tooltip("Time in seconds to ensure win")]
        public float winPeriod = 0.8f;

        private List<OnAbleBall> outputBalls;
        private float winStopTime;

        public void AddOutputBall(OnAbleBall outputBall)
        {
            //print("Adding ball " + outputBall.name);
            Debug.Assert(!outputBall.inputBall, "Invalid Ball Type Added to GameManager");
            outputBalls.Add(outputBall);
        }

        public bool IsWin()
        {
            var win = true;
            foreach (OnAbleBall outputBall in outputBalls)
            {
                win &= outputBall.IsOn();
                if (!win)
                {
                    break;
                }
            }
            return win;
        }

        public void NextLevel()
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            //print("Loading next level " + (level + 1));
            if (lastScene)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(level + 1);
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            outputBalls = new List<OnAbleBall>();
        }

        private void Start()
        {
            winCanvas.gameObject.SetActive(false);
            StartCoroutine(CheckWinPeriodically());
        }

        private IEnumerator CheckWinPeriodically()
        {
            while (true)
            {
                if (!IsWin())
                {
                    winStopTime = Time.timeSinceLevelLoad;
                }
                if (Time.timeSinceLevelLoad - winStopTime >= winPeriod)
                {
                    //print("YOU WIN! Balls Activated: " + outputBalls.Count);
                    winCanvas.gameObject.SetActive(true);
                    winAudioLib.PlayNow();
                    break;
                }
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}