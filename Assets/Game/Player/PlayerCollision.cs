using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rigid2d;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    private PlayerData scrPlayerData;

    private bool contactWall01;
    private bool contactWall02;
    private bool contactWall03;
    private bool contactWall04;

    private IdentifyObjects scrIdentifyObjects;

    [SerializeField] private int numberOfCollisionAllowed;
    [SerializeField] private float DelayOfCollisionAllowed;

    private int numberOfCollisionCurrent;
    private float DelayOfCollisionCurrent;


    void Awake ()
    {
        rigid2d = GetComponent<Rigidbody2D>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrPlayerData = GetComponent<PlayerData>();
    }

    private void Update()
    {/*
        DelayOfCollisionCurrent += Time.deltaTime;
        if (DelayOfCollisionCurrent > DelayOfCollisionAllowed)
        {
            DelayOfCollisionCurrent = 0.0f;
            numberOfCollisionCurrent = 0;
        }

        if (numberOfCollisionCurrent > numberOfCollisionAllowed)
            scrPlayerData.playerDead = true;*/
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (scrPlayerData.playerNumber != scrCommunVariables.currentPlayerNumber)
        {
            if (collision2D.gameObject.tag == "Wall01"
                || collision2D.gameObject.tag == "Wall02"
                || collision2D.gameObject.tag == "Wall03"
                || collision2D.gameObject.tag == "Wall04")
            {
                rigid2d.isKinematic = false;
            }
        }

        if (collision2D.gameObject.tag == "Wall01")
            contactWall01 = true;            
        else if (collision2D.gameObject.tag == "Wall02")
            contactWall02 = true;
        else if (collision2D.gameObject.tag == "Wall02")
            contactWall02 = true;
        else if (collision2D.gameObject.tag == "Wall03")
            contactWall03 = true;
        else if (collision2D.gameObject.tag == "Trash")
        { 
            scrIdentifyObjects = collision2D.gameObject.GetComponent<IdentifyObjects>();

            if (scrIdentifyObjects.connectedToWall01)
                contactWall01 = true;
            if (scrIdentifyObjects.connectedToWall02)
                contactWall02 = true;
            if (scrIdentifyObjects.connectedToWall03)
                contactWall03 = true;
            if (scrIdentifyObjects.connectedToWall04)
                contactWall04 = true;
        }

        if ((contactWall01 && contactWall02)
            || (contactWall03 && contactWall04))
        {
            numberOfCollisionCurrent++;
        }
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (scrPlayerData.playerNumber != scrCommunVariables.currentPlayerNumber)
        {
            if (collision2D.gameObject.tag == "Wall01"
                || collision2D.gameObject.tag == "Wall02"
                || collision2D.gameObject.tag == "Wall03"
                || collision2D.gameObject.tag == "Wall04")
            {
                rigid2d.isKinematic = false;
            }
        }

        if (collision2D.gameObject.tag == "Wall01")
            contactWall01 = true;
        else if (collision2D.gameObject.tag == "Wall02")
            contactWall02 = true;
        else if (collision2D.gameObject.tag == "Wall02")
            contactWall02 = true;
        else if (collision2D.gameObject.tag == "Wall03")
            contactWall03 = true;
        else if (collision2D.gameObject.tag == "Trash")
        {
            scrIdentifyObjects = collision2D.gameObject.GetComponent<IdentifyObjects>();

            if (scrIdentifyObjects.connectedToWall01)
                contactWall01 = true;
            if (scrIdentifyObjects.connectedToWall02)
                contactWall02 = true;
            if (scrIdentifyObjects.connectedToWall03)
                contactWall03 = true;
            if (scrIdentifyObjects.connectedToWall04)
                contactWall04 = true;
        }

        if ((contactWall01 && contactWall02)
            || (contactWall03 && contactWall04))
        {
            numberOfCollisionCurrent++;
        }

        if ((contactWall01 && contactWall02)
            || (contactWall03 && contactWall04))
        {
            numberOfCollisionCurrent++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (scrPlayerData.playerNumber != scrCommunVariables.currentPlayerNumber)
        {
            if (collision2D.gameObject.tag == "Wall01"
                || collision2D.gameObject.tag == "Wall02"
                || collision2D.gameObject.tag == "Wall03"
                || collision2D.gameObject.tag == "Wall04")
            {
                rigid2d.isKinematic = false;
            }
        }

        if (collision2D.gameObject.tag == "Wall01")
            contactWall01 = false;
        else if (collision2D.gameObject.tag == "Wall02")
            contactWall02 = false;
        else if (collision2D.gameObject.tag == "Wall02")
            contactWall02 = false;
        else if (collision2D.gameObject.tag == "Wall03")
            contactWall03 = false;
        else if (collision2D.gameObject.tag == "Trash")
        {
            scrIdentifyObjects = collision2D.gameObject.GetComponent<IdentifyObjects>();

            if (scrIdentifyObjects.connectedToWall01)
                contactWall01 = false;
            if (scrIdentifyObjects.connectedToWall02)
                contactWall02 = false;
            if (scrIdentifyObjects.connectedToWall03)
                contactWall03 = false;
            if (scrIdentifyObjects.connectedToWall04)
                contactWall04 = false;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision.gameObject.tag ==
    }
}
