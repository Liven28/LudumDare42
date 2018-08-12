using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPulse : MonoBehaviour
{
    private CircleCollider2D scrCircleCollider2D;
    private PointEffector2D scrPointEffector2D;


    [SerializeField] private AnimationCurve curvePulse;
    [SerializeField] private float pulseIntensityForceMagnitude;
    [SerializeField] private float pulseIntensityRadius;

    [SerializeField] private float pulseSpeed;
        
        
    private float posCurvePulse;
    private int sign = 1;

    private float pulseApplyForceMagnitude;
    private float pulseApplyRadius;


    void Awake ()
    {
        scrCircleCollider2D = GetComponent<CircleCollider2D>();
        scrPointEffector2D = GetComponent<PointEffector2D>();

    }

    void Update ()
    {
        posCurvePulse += Time.deltaTime * sign * pulseSpeed;
        if (posCurvePulse > 1.0f)
        {
            posCurvePulse = 1.0f;
            sign *= -1;
        }
        if (posCurvePulse < 0.0f)
        {
            posCurvePulse = 0.0f;
            sign *= -1;
        }

        pulseApplyForceMagnitude = curvePulse.Evaluate(posCurvePulse) * pulseIntensityForceMagnitude;
        pulseApplyRadius = curvePulse.Evaluate(posCurvePulse) * pulseIntensityRadius;

       // scrPointEffector2D.forceMagnitude = pulseApplyForceMagnitude;
        scrCircleCollider2D.radius = pulseApplyRadius;
    }
}
