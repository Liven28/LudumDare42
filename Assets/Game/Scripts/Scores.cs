using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    private GameObject Player;
    private PlayerData scrPlayerData;
    private Rigidbody2D rigPlayer;


    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    [SerializeField] private Text TextValueHightScore;
    [SerializeField] private Text TextValueScore;


    private int scoreToShow;
    public float preciseScore;

    [SerializeField] private float pointPerDistance;

    private float startY;
    private float oldY;

    [SerializeField] private float maxiVelocity;
    [SerializeField] private float VelocityMultipier;

    private float multiplierApply;
    private float distanceApply;


    private float veloc;

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        Player = GameObject.Find("Player");
        scrPlayerData = Player.GetComponent<PlayerData>();
        rigPlayer = Player.GetComponent<Rigidbody2D>();

        startY = oldY = Player.transform.position.y;
    }

    private void Start()
    {
        TextValueHightScore.text = scrCommunVariables.HightScore.ToString();
    }

    void Update ()
    {
        distanceApply = (scrPlayerData.posPlayer.y - oldY) * pointPerDistance;
        if (distanceApply < 0)
            distanceApply = 0;
        oldY = scrPlayerData.posPlayer.y;

        veloc = rigPlayer.velocity.y;
        if (veloc < 0)
            veloc = 0;

        multiplierApply = rigPlayer.velocity.y / maxiVelocity * VelocityMultipier;

        preciseScore += distanceApply * multiplierApply;
        scoreToShow = Mathf.FloorToInt(preciseScore);
        TextValueScore.text = scoreToShow.ToString();

        scrCommunVariables.Score = scoreToShow;
        if (scoreToShow > scrCommunVariables.HightScore)
        {
            scrCommunVariables.HightScore = scoreToShow;
            TextValueHightScore.text = scrCommunVariables.HightScore.ToString();
        }
    }
}
