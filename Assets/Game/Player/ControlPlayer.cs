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

    private bool gravityDesactivated;

    private Rigidbody2D rigid2d;
    private SpriteRenderer rendSpriteRenderer;

    private float delta;


    private PlayerData scrPlayerData;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    private bool playerActivated;

    private bool onShot;

    void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrPlayerData = GetComponent<PlayerData>();
        rendSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {/*
        float deltaTime = Time.deltaTime;
        timerUpActionCount -= deltaTime;
        timerDownActionCount -= deltaTime;
        timerLeftActionCount -= deltaTime;
        timerRightActionCount -= deltaTime;
        if (timerUpActionCount < 0.0f)
            timerUpActionCount = 0.0f;
        if (timerDownActionCount < 0.0f)
            timerDownActionCount = 0.0f;
        if (timerLeftActionCount < 0.0f)
            timerLeftActionCount = 0.0f;
        if (timerRightActionCount < 0.0f)
            timerRightActionCount = 0.0f;*/

        timerUpActionCount = 0.0f;
        timerDownActionCount = 0.0f;
        timerLeftActionCount = 0.0f;
        timerRightActionCount = 0.0f;

        //if (scrPlayerData.playerNumber == scrCommunVariables.currentPlayerNumber)
        {
            if (playerActivated == false)
            {
                playerActivated = true;
                rigid2d.isKinematic = false;
                rendSpriteRenderer.color = activeColor;
            }

            delta = Time.deltaTime * 50.0f;
            vect2Key = new Vector2(0, 0);

            if (scrCommunVariables.rightHand == true)
            {
                if (timerLeftActionCount == 0.0f && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)))
                {
                    vect2Key = vect2Left * speedSides;
                    timerLeftActionCount = timerLeftAction;
                }
                if (timerRightActionCount == 0.0f && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
                {
                    vect2Key = new Vector2(vect2Key.x + vect2Right.x * speedSides, vect2Key.y);
                    timerRightActionCount = timerRightAction;
                }
                if (timerUpActionCount == 0.0f && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)))
                {
                    vect2Key = new Vector2(vect2Key.x, vect2Up.y * speedUp);
                    timerUpActionCount = timerUpAction;
                }
                if (timerDownActionCount == 0.0f && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
                {
                    vect2Key = new Vector2(vect2Key.x, vect2Key.y + vect2Down.y * speedDown);
                    timerDownActionCount = timerDownAction;
                }

                if (vect2Key != Vector2.zero)
                {
                    rigid2d.velocity = Vector2.zero;

                    vect2Key = vect2Key.normalized;
                    rigid2d.AddForce(vect2Key * speed);
                    scrCommunVariables.mvt = true;
                    rendSpriteRenderer.color = inactiveColor;

                }
                else
                {
                    rendSpriteRenderer.color = activeColor;

                    vect2Pad = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    if (vect2Pad != Vector2.zero)
                    {
                        rigid2d.velocity = Vector2.zero;

                        vect2Pad = vect2Pad.normalized;
                        rigid2d.AddForce(vect2Pad * speed);
                    }
                }
            }
            /*else
            {
                if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
                {
                    vect2Key = vect2Left;
                }
                if ( Input.GetKey(KeyCode.D))
                {
                    vect2Key = new Vector2(vect2Key.x + vect2Right.x, vect2Key.y);
                }
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
                {
                    vect2Key = new Vector2(vect2Key.x, vect2Up.y);
                }
                if ( Input.GetKey(KeyCode.S))
                {
                    vect2Key = new Vector2(vect2Key.x, vect2Key.y + vect2Down.y);
                }

                if (vect2Key != Vector2.zero)
                {
                    vect2Key = vect2Key.normalized;
                    rigid2d.AddForce(vect2Key * speed * delta);
                }
                else
                {
                    vect2Pad = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    if (vect2Pad != Vector2.zero)
                    {
                        vect2Pad = vect2Pad.normalized;
                        rigid2d.AddForce(vect2Pad * speed * delta);
                    }
                }
            }
        }*//*
        else 
        {
            if (playerActivated == true || onShot == false)
            {
                onShot = true;
                playerActivated = false;
                rendSpriteRenderer.color = inactiveColor;
                rigid2d.velocity = Vector2.zero;
                rigid2d.angularVelocity = 0;
                rigid2d.isKinematic = true;
            }*/
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timerUpActionCount = 0.0f;
        timerDownActionCount = 0.0f;
        timerLeftActionCount = 0.0f;
        timerRightActionCount = 0.0f;
    }
}
