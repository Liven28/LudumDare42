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


    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
    }
	
	void Update ()
    {
        if (scrCommunVariables.rightHand == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (scrCommunVariables.currentPlayerNumber > 1)
                {
                    scrCommunVariables.currentPlayerNumber--;
                }
                else
                {
                    scrCommunVariables.currentPlayerNumber = 3;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (scrCommunVariables.currentPlayerNumber < 3)
                {
                    scrCommunVariables.currentPlayerNumber++;
                }
                else
                {
                    scrCommunVariables.currentPlayerNumber = 1;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {

            }
            if (Input.GetKey(KeyCode.DownArrow))
            {

            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
            {
                if (scrCommunVariables.currentPlayerNumber > 1)
                {
                    scrCommunVariables.currentPlayerNumber--;
                }
                else
                {
                    scrCommunVariables.currentPlayerNumber = 3;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (scrCommunVariables.currentPlayerNumber < 3)
                {
                    scrCommunVariables.currentPlayerNumber++;
                }
                else
                {
                    scrCommunVariables.currentPlayerNumber = 1;
                }
            }
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
            {

            }
            if (Input.GetKey(KeyCode.S))
            {

            }
        }
    }
}
