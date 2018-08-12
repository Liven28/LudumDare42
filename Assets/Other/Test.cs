using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private GameObject Commun;
    private CommunVariables scrCommunVariables;


    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
    }



    void Update ()
    {
		
	}
}
