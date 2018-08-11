using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMvt : MonoBehaviour
{
    [SerializeField] private bool useForce;
    /*
    private Vector2 forceUp = new Vector3 (1, 0);
    private Vector2 forceDown = new Vector3(-1, 0);
    private Vector2 forceLeft = new Vector3(0, -1);
    private Vector2 forceRight = new Vector3(0, 1);
    */
    private Vector2 forceUp = new Vector3(0, -1);
    private Vector2 forceDown = new Vector3(0, 1);
    private Vector2 forceLeft = new Vector3(1, 0);
    private Vector2 forceRight = new Vector3(-1,0);

    [SerializeField] private float forceIntensity;
    [SerializeField] private float forceIntensityUp;
    [SerializeField] private float forceIntensityDown;
    [SerializeField] private float forceIntensityLeft;
    [SerializeField] private float forceIntensityRight;

    private Vector2 forceApply;


    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;

    [SerializeField] private AnimationCurve wallMvtCurve;
    [SerializeField] private float wallMvtspeed;

    private float wallcurvePos;
    private float wallMvtPos;

    private Transform wallTransform;
    private Rigidbody2D rigbodyWall;

    [SerializeField] private int numWall;

    [SerializeField] private float checkpositionDistance;
    [SerializeField] private float checkPositionDelay;
    private float checkPositionCount;

    private Vector2 wallPosition;
    private Vector2 wallPositionOld;
    private float Distance;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;


    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        wallTransform = GetComponent<Transform>();
        rigbodyWall = GetComponent<Rigidbody2D>();

        checkPositionCount = checkPositionDelay;

        wallPosition = wallPositionOld = wallTransform.position;
    }

    void Update ()
    {
        if (useForce == false)
        {
            if (wallcurvePos < 1.0f)
            {
                wallcurvePos += wallMvtspeed * Time.deltaTime;
                if (wallcurvePos > 1.0f)
                    wallcurvePos = 1.0f;

                wallMvtPos = wallMvtCurve.Evaluate(wallcurvePos);
                wallTransform.position = Vector3.Lerp(startPosition, endPosition, wallMvtPos);
            }
        }

        checkPositionCount -= Time.deltaTime;
        if (checkPositionCount < 0.0f)
        {
            checkPositionCount = checkPositionDelay;
            wallPosition = wallTransform.position;
            Distance = Mathf.Abs(wallPosition.x - wallPositionOld.x) + Mathf.Abs(wallPosition.y - wallPositionOld.y);
            if (Distance > checkpositionDistance)
            {
                if (numWall == 1)
                    scrCommunVariables.End01 = true;
                else if (numWall == 2)
                    scrCommunVariables.End02 = true;
                else if (numWall == 3)
                    scrCommunVariables.End03 = true;
                else if (numWall == 4)
                    scrCommunVariables.End04 = true;
            }

            wallPositionOld = wallPosition;
        }
    }

    void FixedUpdate()
    {
        if (useForce == true)
        {
            forceApply = new Vector2(                
                forceLeft.x * forceIntensityLeft + forceRight.x * forceIntensityRight,
                forceUp.y * forceIntensityUp + forceDown.y * forceIntensityDown) 
                * forceIntensity;

            rigbodyWall.AddForce(forceApply);
        }
    }
}
