using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIStates {Game, Pause}

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject gameUIParent;
    public GameObject pauseUIParent;

    public Text scoreText;
    public Text timerText;
    public FixedJoystick leftJoystick;
    public FixedJoystick rightJoystick;
    private UIStates uiState;
    public UIStates UIState
    {
        get { return uiState; }
        set
        {
            uiState = value;
            gameUIParent.SetActive(false);
            pauseUIParent.SetActive(false);
            switch (uiState)
            {
                case UIStates.Game:
                    gameUIParent.SetActive(true);
                    Time.timeScale = 1.0f;
                    break;
                case UIStates.Pause:
                    pauseUIParent.SetActive(true);
                    Time.timeScale = 0.0f;
                    break;
                default:
                    break;
            }
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
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateScore (int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateTime(float time)
    {
        timerText.text = "Elapsed Time: " + time.ToString("F1");
    }
}
