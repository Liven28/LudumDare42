using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] tabObstacles;
    public bool[] obstacleActives;

    [SerializeField] private float sizeMini;
    [SerializeField] private float sizeMaxi;

    private float Rotation;
    
    [SerializeField] private AnimationCurve[] curveSiseMini;
    [SerializeField] private AnimationCurve[] curveSiseMaxi;

    [SerializeField] private AnimationCurve[] curveGravityMini;
    [SerializeField] private AnimationCurve[] curveGravityMaxi;

    [SerializeField] private float SpawnLimitesLeft;
    [SerializeField] private float SpawnLimitesDownRight;

    [SerializeField] private float DistanceMiniPlayer;
    [SerializeField] private float DistanceMaxiPlayer;

    private GameObject Player;
    private PlayerData scrPlayerData;

    private float posPlayerY;
    private Vector3 posSpawn;
    private Quaternion quatSpawn;

    [SerializeField] private float DespawnDistance;
    private bool isActive;
    [SerializeField] private float CheckDistanceDelay;
    private float CheckDistanceCount;
    private float playerDistance;

    [SerializeField] private AnimationCurve[] tabCurveSpeedSpawn;

    [SerializeField] private float[] tabSpeedSpawn;
    [SerializeField] private float globalSpeedSpawn;

    [SerializeField] private float[] tabQuatitySpawn;
    [SerializeField] private float globalQuantitySpawn;

    private int NumObstacleToSpawn;

    public int currentCurve;
    public float posCurve;
    private float spawnRate;
    private float spawnTimer;

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

                    if (Mathf.Abs (playerDistance) > DespawnDistance && posPlayerY > tabObstacles[i].transform.position.y)
                    {
                        tabObstacles[i].SetActive(false);
                        obstacleActives[i] = false;
                    }
                }
            }
        }

        spawnRate = tabSpeedSpawn[currentCurve] * globalSpeedSpawn;
        posCurve += spawnRate * Time.deltaTime;
        if (posCurve > 1.0f)
        {
            posCurve = 0.0f;

            currentCurve++;
            if (currentCurve > tabCurveSpeedSpawn.Length - 1)
                currentCurve = 0;
        }
        spawnTimer -= tabCurveSpeedSpawn[currentCurve].Evaluate(posCurve) * tabQuatitySpawn[currentCurve] * globalQuantitySpawn;
        if (spawnTimer < 0.0f)
        {
            spawnTimer = 1.0f;
            SpawnMeteorite();
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
            }
            i++;
            if (i > 50)
                break;
        }

        if (check == true)
        {
            tabObstacles[NumObstacleToSpawn].transform.position = new Vector3(
                Random.Range(SpawnLimitesLeft, SpawnLimitesDownRight),
                Random.Range(posPlayerY + DistanceMiniPlayer,
                posPlayerY + DistanceMaxiPlayer));


            tabObstacles[NumObstacleToSpawn].SetActive(true);
            obstacleActives[NumObstacleToSpawn] = true;
        }
    }
}
