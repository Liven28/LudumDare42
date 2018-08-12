using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifyObjects : MonoBehaviour
{
    public bool connectedToWall01;
    public bool connectedToWall02;
    public bool connectedToWall03;
    public bool connectedToWall04;

    private string tagObject;

    private IdentifyObjects scrIdentifyObjects;

    [SerializeField] private bool ActiveScript;
	

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (ActiveScript == true)
        { 
        tagObject = collision2D.gameObject.tag;
            if (tagObject == "Wall01")
            {
                if (connectedToWall02 == false)
                {
                    connectedToWall01 = true;
                }
                else
                {
                    connectedToWall01 = false;
                    connectedToWall02 = false;
                }
            }
            else if (tagObject == "Wall02")
            {
                if (connectedToWall01 == false)
                {
                    connectedToWall02 = true;
                }
                else
                {
                    connectedToWall01 = false;
                    connectedToWall02 = false;
                }
            }
            else if (tagObject == "Wall03")
            {
                if (connectedToWall04 == false)
                {
                    connectedToWall03 = true;
                }
                else
                {
                    connectedToWall03 = false;
                    connectedToWall04 = false;
                }
            }
            else if (tagObject == "Wall04")
            {
                if (connectedToWall03 == false)
                {
                    connectedToWall04 = true;
                }
                else
                {
                    connectedToWall03 = false;
                    connectedToWall04 = false;
                }
            }
            else if (tagObject == "Player" || tagObject == "Trash")
            {
                scrIdentifyObjects = collision2D.gameObject.GetComponent<IdentifyObjects>();

                if (scrIdentifyObjects.connectedToWall01)
                    if (connectedToWall02 == false)
                    {
                        connectedToWall01 = true;
                    }
                    else
                    {
                        connectedToWall01 = false;
                        connectedToWall02 = false;
                    }
                if (scrIdentifyObjects.connectedToWall02)
                    if (connectedToWall01 == false)
                    {
                        connectedToWall02 = true;
                    }
                    else
                    {
                        connectedToWall01 = false;
                        connectedToWall02 = false;
                    }
                if (scrIdentifyObjects.connectedToWall03)
                    if (connectedToWall04 == false)
                    {
                        connectedToWall03 = true;
                    }
                    else
                    {
                        connectedToWall03 = false;
                        connectedToWall04 = false;
                    }
                if (scrIdentifyObjects.connectedToWall04)
                    if (connectedToWall03 == false)
                    {
                        connectedToWall04 = true;
                    }
                    else
                    {
                        connectedToWall03 = false;
                        connectedToWall04 = false;
                    }
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (ActiveScript == true)
        {
            tagObject = collision2D.gameObject.tag;
            if (tagObject == "Wall01")
                connectedToWall01 = false;
            else if (tagObject == "Wall02")
                connectedToWall02 = false;
            else if (tagObject == "Wall03")
                connectedToWall03 = false;
            else if (tagObject == "Wall04")
                connectedToWall04 = false;
            else if (tagObject == "Player" || tagObject == "Trash")
            {
                scrIdentifyObjects = collision2D.gameObject.GetComponent<IdentifyObjects>();

                if (scrIdentifyObjects.connectedToWall01)
                    connectedToWall01 = false;
                if (scrIdentifyObjects.connectedToWall02)
                    connectedToWall02 = false;
                if (scrIdentifyObjects.connectedToWall03)
                    connectedToWall03 = false;
                if (scrIdentifyObjects.connectedToWall04)
                    connectedToWall04 = false;
            }
        }
    }
}
