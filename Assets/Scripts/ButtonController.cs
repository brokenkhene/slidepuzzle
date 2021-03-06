﻿using System.Collections;
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

    int index;

    int i;
    public int GetI()
    {
        return i;
    }

    int j;
    public int GetJ()
    {
        return j;
    }

    int _number;

    public int GetNumber()
    {
        return _number;
    }

    private void Awake()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/number");
    }

    void Start ()
    {

    }
	
	void Update () {
		
	}

    public void SetIndex(int index_)
    {
        index = index_;
    }

    public void SetIJ(int i_, int j_)
    {
        i = i_;
        j = j_;
    }

    public void SetNumber(int number)
    {
        _number = number;
       if (number < 10)
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

    private void OnMouseDown()
    {
        if (transform.parent != null)
        {
            transform.parent.SendMessage("OnButtonClickAt", index);
        }
    }
}
