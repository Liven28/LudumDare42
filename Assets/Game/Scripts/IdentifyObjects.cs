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

    void Awake ()
    {
		
	}
	

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        tagObject = collision2D.gameObject.tag;
        if (tagObject == "Wall01")
            connectedToWall01 = true;
        else if (tagObject == "Wall02")
            connectedToWall02 = true;
        else if (tagObject == "Wall03")
            connectedToWall03 = true;
        else if (tagObject == "Wall04")
            connectedToWall04 = true;
        else if (tagObject == "Player" || tagObject == "Trash")
        {
            scrIdentifyObjects = collision2D.gameObject.GetComponent<IdentifyObjects>();

            if (scrIdentifyObjects.connectedToWall01)
                connectedToWall01 = true;
            if (scrIdentifyObjects.connectedToWall02)
                connectedToWall02 = true;
            if (scrIdentifyObjects.connectedToWall03)
                connectedToWall03 = true;
            if (scrIdentifyObjects.connectedToWall04)
                connectedToWall04 = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision2D)
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
        else if (tagObject == "Player" || tagObject == "Player")
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
