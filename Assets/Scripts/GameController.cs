using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    BoardController boardController;

    [SerializeField]
    GameObject startButton;

    [SerializeField]
    GameObject resetButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartButtonClick()
    {
        boardController.ShuffleBoard();

        startButton.SetActive(false);
        resetButton.SetActive(true);
    }

    public void OnResetButtonClick()
    {
        boardController.ResetBoard();

        startButton.SetActive(true);
        resetButton.SetActive(false);
    }
}
