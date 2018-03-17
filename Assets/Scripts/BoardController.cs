using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

    [SerializeField]
    GameObject button1;

	void Start () {
        float w = GetComponent<SpriteRenderer>().bounds.size.x;
        float h = GetComponent<SpriteRenderer>().bounds.size.y;

        float button_w = w / 4;
        float button_h = h / 4;

        button1.transform.position = new Vector3((- w / 2) + (button_w / 2), (h / 2) - (button_h / 2), button1.transform.position.z);
    }

    void Update () {
		
	}
}
