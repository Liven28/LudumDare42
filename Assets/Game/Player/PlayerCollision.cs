using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rigid2d;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    private PlayerData scrPlayerData;

    void Awake ()
    {
        rigid2d = GetComponent<Rigidbody2D>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrPlayerData = GetComponent<PlayerData>();
    }


    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (scrPlayerData.playerNumber != scrCommunVariables.currentPlayerNumber)
        {
            if (collision2D.gameObject.tag == "Wall")
                rigid2d.isKinematic = false;
        }
    }
}
