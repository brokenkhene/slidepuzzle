﻿using System.Collections;
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
    Text textMoves;

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

        if(gameState == GameState.READY)
        {
            startButton.SetActive(true);
            resetButton.SetActive(false);

            timer = 0;
            textTimer.text = ToNiceTime(timer);

            moves = 0;
            textMoves.text = moves + "";
        }
        else if (gameState == GameState.PLAYING)
        {
            startButton.SetActive(false);
            resetButton.SetActive(true);
        }
        else if(gameState == GameState.FINISH)
        {

        }
    }

    public void OnButtonBoardMove()
    {
        moves++;
        textMoves.text = moves + "";
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
