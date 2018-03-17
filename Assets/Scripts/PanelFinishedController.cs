using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFinishedController : MonoBehaviour {

    [SerializeField]
    Text textTimer;

    [SerializeField]
    Text textMoves;

	void Start () {
		
	}
	
    public void Show(string strTimer, string strMoves)
    {
        gameObject.SetActive(true);

        textTimer.text = strTimer;
        textMoves.text = strMoves;
    }
}
