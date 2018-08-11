using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMvt : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;

    [SerializeField] private AnimationCurve wallMvtCurve;
    [SerializeField] private float wallMvtspeed;

    private float wallcurvePos;
    private float wallMvtPos;

    private Transform wallTransform;

    void Awake ()
    {
        wallTransform = GetComponent<Transform>();
    }

    void Update ()
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
