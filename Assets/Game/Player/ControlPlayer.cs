using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] private float speed;

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
    {
        if (scrPlayerData.playerNumber == scrCommunVariables.currentPlayerNumber)
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
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    vect2Key = vect2Left;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    vect2Key = new Vector2(vect2Key.x + vect2Right.x, vect2Key.y);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vect2Key = new Vector2(vect2Key.x, vect2Up.y);
                }
                if (Input.GetKey(KeyCode.DownArrow))
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
            else
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
        }
        else
        {
            if (playerActivated == true || onShot == false)
            {
                onShot = true;
                playerActivated = false;
                rigid2d.isKinematic = true;
                rendSpriteRenderer.color = inactiveColor;
            }
        }
    }
}
