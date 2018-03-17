using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    BoardController boardController;

    [SerializeField]
    GameObject startButton;

    [SerializeField]
    GameObject resetButton;

    [SerializeField]
    Text textTimer;

    [SerializeField]
    GameObject labelTimer;

    [SerializeField]
    Text textMoves;

    [SerializeField]
    GameObject labelMoves;

    [SerializeField]
    PanelFinishedController panelFinishedController;

    public enum GameState
    {
        READY, //0
        PLAYING,
        FINISH,
    }

    public static GameState gameState;
    float timer;
    int moves;

    void Start()
    {
        ChangeGameState(GameState.READY);
    }

    void Update()
    {
        if (gameState == GameState.PLAYING)
        {
            timer += Time.deltaTime;
            textTimer.text = ToNiceTime(timer);
        }
    }

    void ChangeGameState(GameState state)
    {
        gameState = state;

        if (gameState == GameState.READY)
        {
            startButton.SetActive(true);
            resetButton.SetActive(false);

            textTimer.gameObject.SetActive(false);
            labelTimer.SetActive(false);

            textMoves.gameObject.SetActive(false);
            labelMoves.SetActive(false);

            timer = 0;
            textTimer.text = ToNiceTime(timer);

            moves = 0;
            textMoves.text = moves + "";
        }
        else if (gameState == GameState.PLAYING)
        {
            textTimer.gameObject.SetActive(true);
            labelTimer.SetActive(true);

            textMoves.gameObject.SetActive(true);
            labelMoves.SetActive(true);

            startButton.SetActive(false);
            resetButton.SetActive(true);
        }
        else if (gameState == GameState.FINISH)
        {
            textTimer.gameObject.SetActive(false);
            labelTimer.SetActive(false);

            textMoves.gameObject.SetActive(false);
            labelMoves.SetActive(false);

            startButton.SetActive(false);
            resetButton.SetActive(false);


            float bestTimer = PlayerPrefs.GetFloat("best_timer");
            bool newBestScore = false;

            if(bestTimer == 0.0f)
            {
                PlayerPrefs.SetFloat("best_timer", timer);
                PlayerPrefs.SetInt("best_moves", moves);
            }
            else
            {
                if(timer < bestTimer)
                {
                    PlayerPrefs.SetFloat("best_timer", timer);
                    PlayerPrefs.SetInt("best_moves", moves);
                    newBestScore = true;
                }
            }

            panelFinishedController.Show(ToNiceTime(timer), moves + "", ToNiceTime(PlayerPrefs.GetFloat("best_timer")), PlayerPrefs.GetInt("best_moves") + "", newBestScore);

        }
    }

    public void OnButtonBoardMove()
    {
        moves++;
        textMoves.text = moves + "";
    }

    public void OnBoardFinished()
    {
        ChangeGameState(GameState.FINISH);
    }

    public void OnStartButtonClick()
    {
        boardController.ShuffleBoard();
        ChangeGameState(GameState.PLAYING);
    }

    public void OnResetButtonClick()
    {
        boardController.ResetBoard();
        ChangeGameState(GameState.READY);
    }

    public void OnButtonCloseClick()
    {
        panelFinishedController.gameObject.SetActive(false);
        ChangeGameState(GameState.READY);
    }

    public string ToNiceTime(float totalTimeSec)
    {
        string niceTime = "";
        if(totalTimeSec / 3600 >= 1)
        {
            niceTime = (totalTimeSec / 3600).ToString("00")  +  ":";
            totalTimeSec = totalTimeSec % 3600;
        }

        niceTime = niceTime + (totalTimeSec / 60).ToString("00") + ":" + (totalTimeSec % 60).ToString("00");
        return niceTime;
    }
}
