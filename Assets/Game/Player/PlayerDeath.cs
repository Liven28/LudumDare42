using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerData scrPlayerData;

    private BoxCollider2D boxColliderPlayer;

    private ParticleSystem systPart;

    private bool bloodSplashDone;

    private SpriteRenderer rendSpriteRenderer;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    void Awake ()
    {
        scrPlayerData = GetComponent<PlayerData>();
        boxColliderPlayer = GetComponent<BoxCollider2D>();
        systPart = GetComponent<ParticleSystem>();
        rendSpriteRenderer = GetComponent<SpriteRenderer>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
    }


    void Update ()
    {
        if (scrPlayerData.playerDead == true && bloodSplashDone == false)
        {
            bloodSplashDone = true;
            boxColliderPlayer.enabled = false;
            rendSpriteRenderer.color = new Color (0,0,0,0);
            systPart.Emit(10);
            if (scrPlayerData.playerNumber == 1)
                scrCommunVariables.Player01Dead = true;
            else if (scrPlayerData.playerNumber == 2)
                scrCommunVariables.Player02Dead = true;
            else if (scrPlayerData.playerNumber == 3)
                scrCommunVariables.Player03Dead = true;
        }
    }
}
