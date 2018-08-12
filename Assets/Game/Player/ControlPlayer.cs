using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float speedUp;
    [SerializeField] private float speedDown;
    [SerializeField] private float speedSides;

    [SerializeField] private float timerUpAction;
    [SerializeField] private float timerDownAction;
    [SerializeField] private float timerLeftAction;
    [SerializeField] private float timerRightAction;

    private float timerUpActionCount;
    private float timerDownActionCount;
    private float timerLeftActionCount;
    private float timerRightActionCount;

    private Vector2 vect2Up = new Vector2(0, 1);
    private Vector2 vect2Down = new Vector2(0, -1);
    private Vector2 vect2Left = new Vector2(-1, 0);
    private Vector2 vect2Right = new Vector2(1, 0);

    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    private Vector2 vect2Pad = new Vector2(0, 0);
    private Vector2 vect2Key = new Vector2(0, 0);

    [SerializeField] private float deadZone;
    private float clampedHorizontalPad;

    private bool gravityDesactivated;

    private Rigidbody2D rigid2d;
    private SpriteRenderer rendSpriteRenderer;

    private float delta;


    private PlayerData scrPlayerData;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    private bool playerActivated;

    private bool onShot;

    [SerializeField] private float boostSideMvt;

    void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrPlayerData = GetComponent<PlayerData>();
        rendSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(scrCommunVariables.gameWaitToRestart == false)
        { 
        delta = Time.deltaTime * 50.0f;
        vect2Key = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            vect2Key = vect2Left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            vect2Key = new Vector2(vect2Key.x + vect2Right.x, vect2Key.y);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            vect2Key = new Vector2(vect2Key.x, vect2Up.y);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            vect2Key = new Vector2(vect2Key.x, vect2Key.y + vect2Down.y);
        }

            if (vect2Key != Vector2.zero)
            {
                vect2Key = vect2Key.normalized;
                vect2Key = new Vector2(vect2Key.x * boostSideMvt * Time.deltaTime * 50.0f, vect2Key.y);
                rigid2d.AddForce(vect2Key * speed * delta);
            }
            else
            {
                clampedHorizontalPad = Input.GetAxis("Horizontal");

                if (clampedHorizontalPad < deadZone && clampedHorizontalPad > 0.0f)
                {
                    clampedHorizontalPad = 0.0f;
                }
                else if (clampedHorizontalPad > -deadZone && clampedHorizontalPad < 0.0f)
                {
                    clampedHorizontalPad = 0.0f;
                }


                vect2Pad = new Vector2(clampedHorizontalPad, Input.GetAxis("Vertical"));
                if (vect2Pad != Vector2.zero)
                {
                    vect2Pad = vect2Pad.normalized;
                    vect2Pad = new Vector2(vect2Pad.x * boostSideMvt * Time.deltaTime * 50.0f, vect2Pad.y);
                    vect2Pad = new Vector2(vect2Pad.x * boostSideMvt * Time.deltaTime * 50.0f, vect2Pad.y);
                    rigid2d.AddForce(vect2Pad * speed * delta);
                }
            }
        }
    }
}
