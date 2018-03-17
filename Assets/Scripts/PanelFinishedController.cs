using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFinishedController : MonoBehaviour {

    [SerializeField]
    Text textTimer;

    [SerializeField]
    Text textMoves;

    [SerializeField]
    Text bestTextTimer;

    [SerializeField]
    Text bestTextMoves;

    [SerializeField]
    GameObject labelNew;

    void Start () {
		
	}
	
    public void Show(string strTimer, string strMoves, string strBestTimer, string strBestMoves, bool newBestScore)
    {
        gameObject.SetActive(true);

        textTimer.text = strTimer;
        textMoves.text = strMoves;

        bestTextTimer.text = strBestTimer;
        bestTextMoves.text = strBestMoves;

        labelNew.SetActive(newBestScore);

    }
}
