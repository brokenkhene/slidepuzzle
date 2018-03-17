using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

    [SerializeField]
    GameObject[] buttons;

    ButtonController[] buttonControllers;

    Vector2[] buttonPositions = new Vector2[16];

    int empty_i;
    int empty_j;

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

    void Update() {

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
        int[] numbers = new int[buttons.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        Shuffle(numbers);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonControllers[i].SetNumber(numbers[i]);
        }

        int to_empty_i = Random.Range(1, 5);
        int to_empty_j = Random.Range(1, 5);

        MoveButton(to_empty_i, to_empty_j, empty_i, empty_j);

        for (int loop = 0; loop < buttonControllers.Length; loop++)
        {
            buttonControllers[loop].SetIJFromFuture();
        }

        empty_i = to_empty_i;
        empty_j = to_empty_j;
    }

    void OnButtonClickAt(int at)
    {
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
        }

        //Set IJ From Future
        for (int loop = 0; loop < buttonControllers.Length; loop++)
        {
            buttonControllers[loop].SetIJFromFuture();
        }
        
    }

    public void MoveButton(int i_from, int j_from, int i_to, int j_to)
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
            buttonControllerIfromJfrom.transform.position = new Vector3(newPosition.x, newPosition.y, buttonControllerIfromJfrom.transform.position.z);
            buttonControllerIfromJfrom.SetFutureIJ(i_to, j_to);
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

    void Shuffle(int[] a)
    {
        for (int i = a.Length - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i);
            int temp = a[i];

            a[i] = a[rnd];
            a[rnd] = temp;
        }
    }
}
