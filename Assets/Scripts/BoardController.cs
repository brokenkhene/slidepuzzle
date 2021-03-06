﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    GameController gameController;

    [SerializeField]
    AudioSource SoundPlayer;

    ButtonController[] buttonControllers;

    Vector2[] buttonPositions = new Vector2[16];

    int empty_i;
    int empty_j;

    struct MovingButton
    {
        public ButtonController bc;
        public Vector3 des;
        public int i;
        public int j;

        public MovingButton(ButtonController bc_, Vector3 des_, int i_, int j_)
        {
            bc = bc_;
            des = des_;
            i = i_;
            j = j_;
        }
    }

    List<MovingButton> movingButtons = new List<MovingButton>();

    void Start() {

        buttonControllers = new ButtonController[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonControllers[i] = buttons[i].GetComponent<ButtonController>();
        }

        float w = GetComponent<SpriteRenderer>().bounds.size.x;
        float h = GetComponent<SpriteRenderer>().bounds.size.y;

        float button_w = w / 4;
        float button_h = h / 4;

        //button1.transform.position = new Vector3((- w / 2) + (button_w / 2), (h / 2) - (button_h / 2), button1.transform.position.z);

        Vector2 top_left = new Vector2((-w / 2) + (button_w / 2), (h / 2) - (button_h / 2));



        int multiply_x = 0;
        int multiply_y = 0;

        for (int i = 0; i < buttonPositions.Length; i++)
        {
            Vector2 move = new Vector2(button_w * multiply_x, -button_h * multiply_y);
            buttonPositions[i] = top_left + move;
            multiply_x++;

            if (multiply_x >= 4)
            {
                multiply_x = 0;
                multiply_y++;
            }
        }

        ResetBoard();
    }

    void Update()
    {
        if (movingButtons.Count > 0)
        {
            for (int i = movingButtons.Count - 1; i >= 0; i--)
            {
                movingButtons[i].bc.transform.position = Vector3.Lerp(movingButtons[i].bc.transform.position, movingButtons[i].des, Time.deltaTime * 20);
                float dist = Vector3.Distance(movingButtons[i].bc.transform.position, movingButtons[i].des);
                if (dist < 0.0002)
                {
                    movingButtons[i].bc.transform.position = movingButtons[i].des;
                    movingButtons[i].bc.SetIJ(movingButtons[i].i, movingButtons[i].j);
                    CheckFinish();
                    movingButtons.RemoveAt(i);
                }
            }
        }
    }

    public void ResetBoard()
    {
        int i_ = 1;
        int j_ = 1;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.position = new Vector3(buttonPositions[i].x, buttonPositions[i].y, buttons[i].transform.position.z);
            buttonControllers[i].SetNumber(i + 1);
            buttonControllers[i].SetIndex(i);
            buttonControllers[i].SetIJ(i_, j_);
            j_++;
            if (j_ > 4)
            {
                j_ = 1;
                i_++;
            }
        }

        empty_i = 4;
        empty_j = 4;
    }

    public void ShuffleBoard()
    {
        for (int i = 0; i < 1000; i++)
        {
            int to_empty_i = empty_i;
            int to_empty_j = empty_j;

            int i_or_j = Random.Range(0, 2);

            if (i_or_j == 0)
            {
                //move i
                if (to_empty_i == 1)
                {
                    //up
                    to_empty_i = to_empty_i + 1;
                }
                else if (to_empty_i == 4)
                {
                    //down
                    to_empty_i = to_empty_i - 1;
                }
                else
                {
                    int up_or_down = Random.Range(0, 2);
                    if (up_or_down == 0)
                    {
                        //up
                        to_empty_i = to_empty_i + 1;
                    }
                    else
                    {
                        //down
                        to_empty_i = to_empty_i - 1;
                    }
                }
            }
            else
            {
                //move j
                if (to_empty_j == 1)
                {
                    //left
                    to_empty_j = to_empty_j + 1;
                }
                else if (to_empty_j == 4)
                {
                    //right
                    to_empty_j = to_empty_j - 1;
                }
                else
                {
                    int left_or_right = Random.Range(0, 2);
                    if (left_or_right == 0)
                    {
                        //left
                        to_empty_j = to_empty_j + 1;
                    }
                    else
                    {
                        //right
                        to_empty_j = to_empty_j - 1;
                    }
                }
            }

            MoveButton(to_empty_i, to_empty_j, empty_i, empty_j, true);

            empty_i = to_empty_i;
            empty_j = to_empty_j;
        }
    }

    void OnButtonClickAt(int at)
    {
        if (GameController.gameState != GameController.GameState.PLAYING)
        {
            return;
        }
        
        if(movingButtons.Count > 0)
        {
            return;
        }


        int i = buttonControllers[at].GetI();
        int j = buttonControllers[at].GetJ();

        if (i == empty_i)
        {
            if (j < empty_j)
            {
                //เลื่อนขวา
                for (int j_to_move = j; j_to_move < empty_j; j_to_move++)
                {
                    MoveButton(i, j_to_move, i, j_to_move + 1);
                }

            }
            else
            {
                //เลื่อนซ้าย j > empty_j
                for (int j_to_move = j; j_to_move > empty_j; j_to_move--)
                {
                    MoveButton(i, j_to_move, i, j_to_move - 1);
                }

            }

            empty_j = j;
            gameController.OnButtonBoardMove();
            SoundPlayer.PlayOneShot(SoundPlayer.clip);
        }
        else if (j == empty_j)
        {
            if (i < empty_i)
            {
                //เลื่อนลง
                for (int i_to_move = i; i_to_move < empty_i; i_to_move++)
                {
                    MoveButton(i_to_move, j, i_to_move + 1, j);
                }

            }
            else
            {
                //เลื่อนขึ้น
                for (int i_to_move = i; i_to_move > empty_i; i_to_move--)
                {
                    MoveButton(i_to_move, j, i_to_move - 1, j);
                }
            }

            empty_i = i;
            gameController.OnButtonBoardMove();
            SoundPlayer.PlayOneShot(SoundPlayer.clip);
        }
    }

    public void CheckFinish()
    {
        //เช็คว่าเลขเรียงกันรึป่าว
        if (empty_i != 4 || empty_j != 4)
        {
            return;
        }

        for (int loop = 0; loop < buttonControllers.Length; loop++)
        {
            int i = buttonControllers[loop].GetI();
            int j = buttonControllers[loop].GetJ();

            int expectedNumber = (i - 1) * 4 + j;
            int number = buttonControllers[loop].GetNumber();
            if(expectedNumber != number)
            {
                return;
            }
        }
        gameController.OnBoardFinished();
    }

    public void MoveButton(int i_from, int j_from, int i_to, int j_to, bool now = false)
    {
        ButtonController buttonControllerIfromJfrom = null;

        for (int i = 0; i < buttonControllers.Length; i++)
        {
            if (i_from == buttonControllers[i].GetI() && j_from == buttonControllers[i].GetJ())
            {
                buttonControllerIfromJfrom = buttonControllers[i];
            }
        }

        if(buttonControllerIfromJfrom != null)
        {
            Vector2 newPosition = FindButtonPosition(i_to, j_to);
            if (now)
            {
                buttonControllerIfromJfrom.transform.position = new Vector3(newPosition.x, newPosition.y, buttonControllerIfromJfrom.transform.position.z);
                buttonControllerIfromJfrom.SetIJ(i_to, j_to);
            }
            else
            {
                movingButtons.Add(new MovingButton(buttonControllerIfromJfrom, new Vector3(newPosition.x, newPosition.y, buttonControllerIfromJfrom.transform.position.z), i_to, j_to));
            }
            
        }
    }

    public Vector2 FindButtonPosition(int I, int J)
    {
        int i_count = 1;
        int j_count = 1;

        for (int i = 0; i < buttonPositions.Length; i++)
        {
            if(i_count == I && j_count == J)
            {
                return buttonPositions[i];
            }

            j_count++;
            if(j_count > 4)
            {
                j_count = 1;
                i_count++;
            }
        }

        return Vector2.zero;
    }
}
