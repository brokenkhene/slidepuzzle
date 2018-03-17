using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    [SerializeField]
    RectTransform buttonStart;

    [SerializeField]
    RectTransform buttonReset;

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

    }

    void Update () {
		
	}
}
