using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rigPlayer;

    private SpawnObstacle scrSpawnObstacle;

    private Vector3 startPositionPlayer;
    private Quaternion startRotationPlayer;

    private Save scrSave;
    private Scores scrScores;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;
    

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        Player = GameObject.Find("Player");
        rigPlayer = Player.GetComponent<Rigidbody2D>();

        startPositionPlayer = Player.transform.position;
        startRotationPlayer = Player.transform.rotation;

        scrSpawnObstacle = GetComponent<SpawnObstacle>();
        scrSave = GetComponent<Save>();
        scrScores = GetComponent<Scores>();
    }


    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.R))
        {
            RestartRound();
        }
	}

    public void RestartRound()
    {
        scrSave.FntSave();

        Player.transform.position = startPositionPlayer;
        Player.transform.rotation = startRotationPlayer;
        rigPlayer.velocity = Vector2.zero;

        for (int i = 0; i < scrSpawnObstacle.tabObstacles.Length; i++)
        {
            scrSpawnObstacle.tabObstacles[i].SetActive(false);
            scrSpawnObstacle.obstacleActives[i] = false;
        }

        scrSpawnObstacle.currentCurve = 0;
        scrSpawnObstacle.posCurve = 0.0f;
        scrScores.preciseScore = 0.0f;
        scrCommunVariables.currentPlayerLife = scrCommunVariables.startPlayerLife;
        scrCommunVariables.gameWaitToRestart = false;
    }
}
