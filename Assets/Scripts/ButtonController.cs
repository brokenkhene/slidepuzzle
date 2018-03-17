using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    [SerializeField]
    GameObject numberAlone;

    [SerializeField]
    GameObject numberCouple1;

    [SerializeField]
    GameObject numberCouple2;

    Sprite[] numberSprites;

    void Start ()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/number");
    }
	
	void Update () {
		
	}

    public void SetNumber(int number)
    {
       if(number < 10)
        {
            numberAlone.SetActive(true);
            numberCouple1.SetActive(false);
            numberCouple2.SetActive(false);

            numberAlone.GetComponent<SpriteRenderer>().sprite = numberSprites[number];
        }
       else
        {
            numberAlone.SetActive(false);
            numberCouple1.SetActive(true);
            numberCouple2.SetActive(true);

            numberCouple1.GetComponent<SpriteRenderer>().sprite = numberSprites[1];
            numberCouple2.GetComponent<SpriteRenderer>().sprite = numberSprites[number - 10];
        }
    }
}
