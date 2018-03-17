using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    [SerializeField]
    RectTransform buttonStart;

    [SerializeField]
    RectTransform buttonReset;

    [SerializeField]
    RectTransform labelTimer;

    [SerializeField]
    RectTransform textTimer;

    [SerializeField]
    RectTransform labelMoves;

    [SerializeField]
    RectTransform textMoves;

    [SerializeField]
    RectTransform panelFinished;

    [SerializeField]
    RectTransform buttonClose;

    [SerializeField]
    RectTransform pfLabelTimer;

    [SerializeField]
    RectTransform pfTextTimer;

    [SerializeField]
    RectTransform pfLabelMoves;

    [SerializeField]
    RectTransform pfTextMoves;

    [SerializeField]
    RectTransform labelBest;

    [SerializeField]
    RectTransform bestLabelTimer;

    [SerializeField]
    RectTransform bestTextTimer;

    [SerializeField]
    RectTransform bestLabelMoves;

    [SerializeField]
    RectTransform bestTextMoves;

    [SerializeField]
    RectTransform labelNew;

    void Start()
    {
        float expandRate = Screen.width / 164f;

        //buton start
        buttonStart.sizeDelta = new Vector2(buttonStart.sizeDelta.x * expandRate, buttonStart.sizeDelta.y * expandRate);

        float buttonStartY = Screen.height / 2 - Screen.width / 2 - (Screen.height / 2 - Screen.width / 2) / 2 - buttonStart.sizeDelta.y / 2;
        buttonStart.position = new Vector3(Screen.width /2 , buttonStartY, buttonStart.position.z);

        //button reset
        buttonReset.sizeDelta = new Vector2(buttonReset.sizeDelta.x * expandRate, buttonReset.sizeDelta.y * expandRate);

        float buttonResetY = Screen.height / 2 - Screen.width / 2 - (Screen.height / 2 - Screen.width / 2) / 2 - buttonReset.sizeDelta.y / 2;
        buttonReset.position = new Vector3(Screen.width / 2, buttonResetY, buttonReset.position.z);

        //label timer
        labelTimer.sizeDelta = new Vector2(labelTimer.sizeDelta.x * expandRate, labelTimer.sizeDelta.y * expandRate);

        float labelTimerY = Screen.height / 2 + Screen.width / 2 + 5 * expandRate;
        labelTimer.position = new Vector3(10 * expandRate, labelTimerY, labelTimer.position.z);

        //text timer
        textTimer.sizeDelta = new Vector2(textTimer.sizeDelta.x, labelTimer.sizeDelta.y * 1.5f);

        textTimer.position = new Vector3(labelTimer.position.x + labelTimer.sizeDelta.x + 3 * expandRate, labelTimer.position.y - (labelTimer.sizeDelta.y * 0.5f) / 2, textTimer.position.z);

        //label moves
        labelMoves.sizeDelta = new Vector2(labelMoves.sizeDelta.x * expandRate, labelMoves.sizeDelta.y * expandRate);

        labelMoves.position = new Vector3(Screen.width - 55 * expandRate, labelTimer.position.y, labelMoves.position.z);

        // text move
        textMoves.sizeDelta = new Vector2(textMoves.sizeDelta.x, textTimer.sizeDelta.y);

        textMoves.position = new Vector3(labelMoves.position.x + labelMoves.sizeDelta.x + 3 * expandRate, textTimer.position.y, textMoves.position.z);

        //panel finish
        panelFinished.sizeDelta = new Vector2(Screen.width, 65 * expandRate);

        panelFinished.position = new Vector3(Screen.width / 2 , Screen.height / 2, panelFinished.position.z);

        //button close
        buttonClose.sizeDelta = new Vector2(buttonClose.sizeDelta.x * expandRate, buttonClose.sizeDelta.y * expandRate);

        //label timer
        pfLabelTimer.sizeDelta = new Vector2(pfLabelTimer.sizeDelta.x * expandRate, pfLabelTimer.sizeDelta.y * expandRate);

        pfLabelTimer.localPosition = new Vector3(pfLabelTimer.localPosition.x + 10 * expandRate, pfLabelTimer.localPosition.y - 5 * expandRate, pfLabelTimer.localPosition.z);

        //text timer
        pfTextTimer.sizeDelta = textTimer.sizeDelta;

        pfTextTimer.position = new Vector3(pfLabelTimer.position.x + pfLabelTimer.sizeDelta.x + 3 * expandRate, pfLabelTimer.position.y + (pfLabelTimer.sizeDelta.y * 0.5f) / 2, pfTextTimer.position.z);

        // label new 
        labelNew.sizeDelta = new Vector2(labelNew.sizeDelta.x * expandRate, labelNew.sizeDelta.y * expandRate);

        labelNew.position = new Vector3(pfTextTimer.position.x, pfTextTimer.position.y - pfTextTimer.sizeDelta.y - 2 * expandRate, labelNew.position.y);

        //label move
        pfLabelMoves.sizeDelta = new Vector2(pfLabelMoves.sizeDelta.x * expandRate, pfLabelMoves.sizeDelta.y * expandRate);

        pfLabelMoves.localPosition = new Vector3(pfLabelMoves.localPosition .x - 55 * expandRate , pfLabelTimer.localPosition.y , pfLabelMoves.localPosition.z);

        //text moves
        pfTextMoves.sizeDelta = textMoves.sizeDelta;

        pfTextMoves.position = new Vector3(pfLabelMoves.position.x + pfLabelMoves.sizeDelta.x + 3 * expandRate, pfTextTimer.position.y, pfTextMoves.position.z);

        //label best
        labelBest.sizeDelta = new Vector2(labelBest.sizeDelta.x * expandRate, labelBest.sizeDelta.y * expandRate);

        labelBest.localPosition = new Vector3(labelBest.localPosition.x + 10 * expandRate, labelBest.localPosition.y, labelBest.localPosition.z);

        //label timer
        bestLabelTimer.sizeDelta = new Vector2(bestLabelTimer.sizeDelta.x * expandRate, bestLabelTimer.sizeDelta.y * expandRate);

        bestLabelTimer.position = new Vector3(pfLabelTimer.position.x, labelBest.position.y - 5 * expandRate, bestLabelTimer.localPosition.z);

        //text timer
        bestTextTimer.sizeDelta = textTimer.sizeDelta;

        bestTextTimer.position = new Vector3(pfTextTimer.position.x, bestLabelTimer.position.y + (bestLabelTimer.sizeDelta.y * 0.5f) / 2, bestTextTimer.position.z);

        //label move
        bestLabelMoves.sizeDelta = new Vector2(bestLabelMoves.sizeDelta.x * expandRate, bestLabelMoves.sizeDelta.y * expandRate);

        bestLabelMoves.position = new Vector3(pfLabelMoves.position.x, bestLabelTimer.position.y, bestLabelMoves.localPosition.z);

        //text moves
        bestTextMoves.sizeDelta = textMoves.sizeDelta;

        bestTextMoves.position = new Vector3(pfTextMoves.position.x, bestTextTimer.position.y, bestTextMoves.position.z);

    }

    void Update () {
		
	}
}
