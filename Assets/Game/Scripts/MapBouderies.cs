using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBouderies : MonoBehaviour
{
    private GameObject Commun;
    private CommunVariables scrCommunVariables;


    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
    }
	


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag ==  "Player")
        {
            scrCommunVariables.Victory = true;
        }
    }
}
