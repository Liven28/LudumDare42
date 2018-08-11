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

    void Awake ()
    {
        wallTransform = GetComponent<Transform>();
        rigbodyWall = GetComponent<Rigidbody2D>();
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
