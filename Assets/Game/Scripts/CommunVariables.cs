using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunVariables : MonoBehaviour
{
    public int currentPlayerNumber;

    public bool Player01Dead;
    public bool Player02Dead;
    public bool Player03Dead;

    public bool rightHand;
    public bool inMenu;


    public bool gameRunnig;
    public bool continu;
    public bool play;
    public bool gameWaitToRestart;

    public bool End;
    public bool End01;
    public bool End02;
    public bool End03;
    public bool End04;

    public bool Victory;


    void Awake ()
    {
		
	}
	
	void Update ()
    {
		if (End01 && End02 && End03 && End04)
        {
            End = true;
            End01 = End02 = End03 = End04 = false;
        }
	}
}
