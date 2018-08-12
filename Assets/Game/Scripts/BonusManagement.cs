using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManagement : MonoBehaviour
{
    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    private ParticleSystem scrParticleSystem;

    private bool startFadeSprite;
    private bool startWaitingTransparent;

    [SerializeField] private float fadeSpeed;
    private float currentAlpha;
    private float startAlpha;
    private Color colorSprite;

    private SpriteRenderer scrSpriteRenderer;

    [SerializeField] private float reshowDelay;
    private float reshowCount;

    private bool bonusInaccessible;

    [SerializeField] private int brustDespawn;
    [SerializeField] private int brustSpawn;

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrParticleSystem = GetComponent<ParticleSystem>();
        scrSpriteRenderer = GetComponent<SpriteRenderer>();

        colorSprite = scrSpriteRenderer.color;
        currentAlpha = startAlpha = colorSprite.a;
    }


    void Update ()
    {
        if (startFadeSprite == true)
        {
            currentAlpha -= Time.deltaTime * fadeSpeed;
            if (currentAlpha < 0)
            {
                currentAlpha = 0;
                startWaitingTransparent = true;
                startFadeSprite = false;
            }
            colorSprite = new Color(colorSprite.r, colorSprite.g, colorSprite.b, currentAlpha);
            scrSpriteRenderer.color = colorSprite;
        }

        if (startWaitingTransparent == true)
        {
            reshowCount += Time.deltaTime;
            if (reshowCount > reshowDelay)
            {
                startWaitingTransparent = false;
                currentAlpha = startAlpha;
                colorSprite = new Color(colorSprite.r, colorSprite.g, colorSprite.b, currentAlpha);
                bonusInaccessible = true;
                reshowCount = 0.0f;
                scrParticleSystem.Emit(brustSpawn);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bonusInaccessible == false 
            && collision.gameObject.tag == "Player" 
            && scrCommunVariables.currentPlayerLife < scrCommunVariables.startPlayerLife)
        {
            bonusInaccessible = true;
            startFadeSprite = true;
            scrParticleSystem.Emit(brustDespawn);

            scrCommunVariables.currentPlayerLife++;
        }
    }
}
