using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private GameObject player01;
    [SerializeField] private GameObject player02;
    [SerializeField] private GameObject player03;

    private Vector3 posPlayer01;
    private Vector3 posPlayer02;
    private Vector3 posPlayer03;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    [SerializeField] private float playerSelectionDelay;
    private float playerSelectionDelayCount;

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
    }
	
	void Update ()
    {
        if (playerSelectionDelayCount == 0.0f)
        {
            if (scrCommunVariables.rightHand == false)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetButtonDown("joystick button 0"))
                    DecreasePlayerNumber();

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetButtonDown("joystick button 1"))
                    IncreasePlayerNumber();
                
                if (Input.GetKey(KeyCode.UpArrow))
                {

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {

                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetButtonDown("joystick button 0"))
                    DecreasePlayerNumber();

                if (Input.GetKey(KeyCode.D) || Input.GetButtonDown("joystick button 1"))
                    IncreasePlayerNumber();

                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
                {

                }
                if (Input.GetKey(KeyCode.S))
                {

                }
            }
        }
        else
        {
            playerSelectionDelayCount -= Time.deltaTime;
            if (playerSelectionDelayCount < 0.0f)
                playerSelectionDelayCount = 0.0f;
        }
    }

    private void IncreasePlayerNumber()
    {
        playerSelectionDelayCount = playerSelectionDelay;

        bool PlayerFound = false;
        int i = 0;

        while (PlayerFound == false)
        {
            if (scrCommunVariables.currentPlayerNumber < 3)
                scrCommunVariables.currentPlayerNumber++;
            else
                scrCommunVariables.currentPlayerNumber = 1;

            if (scrCommunVariables.currentPlayerNumber == 1 && scrCommunVariables.Player01Dead == false)
            {
                PlayerFound = true;
                break;
            }
            else if (scrCommunVariables.currentPlayerNumber == 2 && scrCommunVariables.Player02Dead == false)
            {
                PlayerFound = true;
                break;
            }
            else if (scrCommunVariables.currentPlayerNumber == 3 && scrCommunVariables.Player03Dead == false)
            {
                PlayerFound = true;
                break;
            }
            i++;
            if (i == 2)
            {
                PlayerFound = true;
                break;
            }
        }     
    }

    private void DecreasePlayerNumber()
    {        
        playerSelectionDelayCount = playerSelectionDelay;

        bool PlayerFound = false;
        int i = 0;

        while (PlayerFound == false)
        {
            if (scrCommunVariables.currentPlayerNumber > 1)
                scrCommunVariables.currentPlayerNumber--;
            else
                scrCommunVariables.currentPlayerNumber = 3;

            if (scrCommunVariables.currentPlayerNumber == 1 && scrCommunVariables.Player01Dead == false)
            {
                PlayerFound = true;
                break;
            }
            else if (scrCommunVariables.currentPlayerNumber == 2 && scrCommunVariables.Player02Dead == false)
            {
                PlayerFound = true;
                break;
            }
            else if (scrCommunVariables.currentPlayerNumber == 3 && scrCommunVariables.Player03Dead == false)
            {
                PlayerFound = true;
                break;
            }
            i++;
            if (i == 3)
            {
                PlayerFound = true;
                break;
            }
        }
    }
}
