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

        Vector2 move_right = new Vector2(button_w, 0);

        button_positions[0] = top_left;
        button_positions[1] = button_positions[0] + move_right;
        button_positions[2] = button_positions[1] + move_right;
        button_positions[3] = button_positions[2] + move_right;

        buttons[0].transform.position = new Vector3(button_positions[0].x, button_positions[0].y, buttons[0].transform.position.y);
        buttons[1].transform.position = new Vector3(button_positions[1].x, button_positions[1].y, buttons[1].transform.position.y);
        buttons[2].transform.position = new Vector3(button_positions[2].x, button_positions[2].y, buttons[2].transform.position.y);
        buttons[3].transform.position = new Vector3(button_positions[3].x, button_positions[3].y, buttons[3].transform.position.y);
    }

    void Update () {
		
	}
}
