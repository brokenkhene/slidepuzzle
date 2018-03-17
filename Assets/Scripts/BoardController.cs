using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

    [SerializeField]
    GameObject[] buttons;
    
    void Start () {
        float w = GetComponent<SpriteRenderer>().bounds.size.x;
        float h = GetComponent<SpriteRenderer>().bounds.size.y;

        float button_w = w / 4;
        float button_h = h / 4;

        //button1.transform.position = new Vector3((- w / 2) + (button_w / 2), (h / 2) - (button_h / 2), button1.transform.position.z);

        Vector2 top_left = new Vector2((-w / 2) + (button_w / 2), (h / 2) - (button_h / 2));

        Vector2[] button_positions = new Vector2[16];


        int multiply_x = 0;
        int multiply_y = 0;

        for (int i = 0; i < button_positions.Length; i++)
        {
            Vector2 move = new Vector2(button_w * multiply_x, - button_h * multiply_y);
            button_positions[i] = top_left + move;
            multiply_x++;

            if(multiply_x >= 4)
            {
                multiply_x = 0;
                multiply_y++;
            }
        }

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.position = new Vector3(button_positions[i].x, button_positions[i].y, buttons[i].transform.position.z);
        }

    }

    void Update () {
		
	}
}
