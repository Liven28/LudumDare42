using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class End : MonoBehaviour
{
    private GameObject Commun;
    private CommunVariables scrCommunVariables;
    private Save scrSave;

    public float EndY;

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
        scrSave = Commun.GetComponent<Save>();

        Vector3 pos = new Vector3 (this.gameObject.transform.position.x, EndY, this.gameObject.transform.position.z);
        this.gameObject.transform.position = pos;
    }


    void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (scrCommunVariables.gameFinished == false && collision.gameObject.tag == "Player")
        {
            if (Application.isEditor == false)
                Analytics.CustomEvent("Finished");
            scrCommunVariables.gameFinished = true;
            scrSave.FntSave();
        }
    }
}
