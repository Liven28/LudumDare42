using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] tabObstacles;
    [SerializeField] private bool[] obstacleActives;

    [SerializeField] private float sizeMini;
    [SerializeField] private float sizeMaxi;

    private float Rotation;


    [SerializeField] private AnimationCurve[] curveSiseMini;
    [SerializeField] private AnimationCurve[] curveSiseMaxi;

    [SerializeField] private AnimationCurve[] curveGravityMini;
    [SerializeField] private AnimationCurve[] curveGravityMaxi;

    //[SerializeField] private AnimationCurve[] curveSiseMini;
    //[SerializeField] private AnimationCurve[] curveSiseMini;

    [SerializeField] private float SpawnLimitesLeft;
    [SerializeField] private float SpawnLimitesDownRight;

    [SerializeField] private float DistanceMiniPlayer;
    [SerializeField] private float DistanceMaxiPlayer;

    private GameObject Player;
    private PlayerData scrPlayerData;

    private float posPlayerY;
    private Vector3 posSpawn;
    private Quaternion quatSpawn;
    private int NumObstacleToSpawn;

    private int currentCurve;
    private float posCurve;
    private float timerSpawn;
    [SerializeField] private float globalSpeedSpawn;
    [SerializeField] private float[] tabSpeedSpawn;
    [SerializeField] private AnimationCurve[] tabCurveSpeedSpawn;

    [SerializeField] private float DespawnDistance;
    private bool isActive;
    [SerializeField] private float CheckDistanceDelay;
    private float CheckDistanceCount;

    private float playerDistance;


    void Awake ()
    {
        Player = GameObject.Find("Player");
        scrPlayerData = Player.GetComponent<PlayerData>();

        posPlayerY = Player.transform.position.y;
        obstacleActives = new bool[tabObstacles.Length];
        for (int i = 0; i < tabObstacles.Length; i++)
        {
            tabObstacles[i].SetActive(false);
            obstacleActives[i] = false;
        }
        CheckDistanceCount = Random.Range(0.0f, CheckDistanceDelay);
    }

    private void Update()
    {
        CheckDistanceCount -= Time.deltaTime;
        if (CheckDistanceCount < 0.0f)
        {
            CheckDistanceCount = Random.Range(0.0f, CheckDistanceDelay);
            posPlayerY = Player.transform.position.y;
            for (int i = 0; i < tabObstacles.Length; i++)
            {
                if (obstacleActives[i] == true)
                {
                    playerDistance = posPlayerY - tabObstacles[i].transform.position.y;

                    //playerDistance = posPlayer.y - tabObstacles[i].transform.position.y;
                    if (Mathf.Abs (playerDistance) > DespawnDistance && posPlayerY > tabObstacles[i].transform.position.y)
                    {
                        tabObstacles[i].SetActive(false);
                        obstacleActives[i] = false;
                    }
                }
            }
        }

        //posCurve += Time.deltaTime;

        timerSpawn += Time.deltaTime * tabSpeedSpawn[currentCurve] * globalSpeedSpawn;
        if (timerSpawn > 1.0f)
        {
            SpawnMeteorite();
            timerSpawn = 0.0f;

            currentCurve++;
            if (currentCurve > tabCurveSpeedSpawn.Length - 1)
                currentCurve = 0;
        }
    }

    void SpawnMeteorite()
    {
        posPlayerY = scrPlayerData.posPlayer.y;

        bool check = false;
        int i  = 0;
        while (check == false)
        {
            NumObstacleToSpawn = Random.Range(0, tabObstacles.Length - 1);
            if (obstacleActives[NumObstacleToSpawn] == false)
            {
                check = true;
                break;
            }
            i++;
            if (i > 50)
                break;
        }
        //playerDistance = (tabObstacles[NumObstacleToSpawn].transform.position - posPlayer).sqrMagnitude;

        tabObstacles[NumObstacleToSpawn].transform.position = new Vector3(Random.Range(SpawnLimitesLeft, SpawnLimitesDownRight), Random.Range(posPlayerY + DistanceMiniPlayer, posPlayerY + DistanceMaxiPlayer));
        //tabObstacles[NumObstacleToSpawn].transform.rotation = new Quaternion (Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        tabObstacles[NumObstacleToSpawn].SetActive(true);
        obstacleActives[NumObstacleToSpawn] = true;

        //GameObject instance = Instantiate(tabObstacles[NumObstacleToSpawn], posSpawn, quatSpawn);
    }
}
