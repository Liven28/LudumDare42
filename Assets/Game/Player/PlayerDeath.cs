using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem systPart;

    private Rigidbody2D rigPlayer;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;
    private Restart scrRestart;

    private bool Waiting;
    private bool explosionDone;
    [SerializeField] private float restartDelay;
    private float restartCount;

    [SerializeField] private float waitToShowMessageDelay;

    [SerializeField] private int explosionIntensity;

    [SerializeField] private Color colorAlive;
    [SerializeField] private Color colorDead;
    private SpriteRenderer scrSpriteRenderer;

    private int lifePlayerOld;
    [SerializeField] private GameObject imageTool01;
    [SerializeField] private GameObject imageTool02;
    [SerializeField] private GameObject imageTool03;
    [SerializeField] private GameObject imageTool04;
    [SerializeField] private GameObject imageTool05;

    [SerializeField] private GameObject TextNewHightScore;

    private float normalGravity;
    [SerializeField] private float deadGravity;
    void Awake ()
    {
        rigPlayer = GetComponent<Rigidbody2D>();
        scrSpriteRenderer = GetComponent<SpriteRenderer>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();
        scrRestart = Commun.GetComponent<Restart>();

        scrSpriteRenderer.color = colorAlive;
        normalGravity = rigPlayer.gravityScale;
    }


    void Update ()
    {
        if (scrCommunVariables.currentPlayerLife == 0 && explosionDone == false)
        {
            scrCommunVariables.gameWaitToRestart = true;
            Waiting = true;
            explosionDone = true;
            systPart.Emit(explosionIntensity);
            scrSpriteRenderer.color = colorDead;
            rigPlayer.gravityScale = deadGravity;
        }

        if (Waiting == true)
        {
            restartCount += Time.deltaTime;

            if (restartCount > waitToShowMessageDelay)
            {
                if (scrCommunVariables.Score >= scrCommunVariables.HightScore)
                    TextNewHightScore.SetActive(true);
            }

            if (restartCount > restartDelay)
            {
                TextNewHightScore.SetActive(false);
                explosionDone = false;
                Waiting = false;
                restartCount = 0.0f;
                scrSpriteRenderer.color = colorAlive;
                rigPlayer.gravityScale = normalGravity;
                scrRestart.RestartRound();
            }
        }

        if (scrCommunVariables.currentPlayerLife != lifePlayerOld)
        {
            lifePlayerOld = scrCommunVariables.currentPlayerLife;
            imageTool01.SetActive(false);
            imageTool02.SetActive(false);
            imageTool03.SetActive(false);
            imageTool04.SetActive(false);
            imageTool05.SetActive(false);

            if (lifePlayerOld >= 1)
                imageTool01.SetActive(true);
            if (lifePlayerOld >= 2)
                imageTool02.SetActive(true);
            if (lifePlayerOld >= 3)
                imageTool03.SetActive(true);
            if (lifePlayerOld >= 4)
                imageTool04.SetActive(true);
            if (lifePlayerOld >= 5)
                imageTool05.SetActive(true);
        }

    }
}
