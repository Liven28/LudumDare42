using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rigid2d;

    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    private PlayerData scrPlayerData;

    [SerializeField] private float collisionDelay;
    private float collisionCount;

    [SerializeField]
    private ParticleSystem systPart;
    [SerializeField] private int explosionIntensity;

    void Awake ()
    {
        rigid2d = GetComponent<Rigidbody2D>();

        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrPlayerData = GetComponent<PlayerData>();
    }


    private void Update()
    {
        collisionCount -= Time.deltaTime;
        if (collisionCount < 0.0f)
            collisionCount = 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag != "Eye")
            scrCommunVariables.playBong = true;

        if (collision2D.gameObject.tag == "Trash")
        {
            if (collisionCount == 0.0f)
            {
                scrCommunVariables.currentPlayerLife--;
                if (scrCommunVariables.currentPlayerLife < 0)
                    scrCommunVariables.currentPlayerLife = 0;
                collisionCount = collisionDelay;
                systPart.Emit(explosionIntensity);
            }
        }
    }
}
