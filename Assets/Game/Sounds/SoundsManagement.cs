using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManagement : MonoBehaviour
{
    private GameObject Commun;
    private CommunVariables scrCommunVariables;

    private AudioSource scrAudioSource;
    [SerializeField] private AudioClip[] tabAudioClip;
    private int NumClip;
    [SerializeField] private AudioClip audioClipExplosion;
    [SerializeField] private AudioClip audioClipDing;
    [SerializeField] private AudioClip audioClipBong02;

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrAudioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
		if (scrCommunVariables.playBong && scrCommunVariables.currentPlayerLife > 0)
        {
            scrAudioSource.Stop();
            NumClip = Random.Range(0, tabAudioClip.Length - 1);

            scrAudioSource.PlayOneShot(tabAudioClip[NumClip]);
            scrCommunVariables.playBong = false;
        }

        if (scrCommunVariables.playExplosion)
        {
            scrAudioSource.Stop();
            scrAudioSource.PlayOneShot(audioClipExplosion);
            scrCommunVariables.playExplosion = false;
        }

        if (scrCommunVariables.playDing)
        {
            scrAudioSource.Stop();
            scrAudioSource.PlayOneShot(audioClipDing);
            scrCommunVariables.playDing = false;
        }

        if (scrCommunVariables.playBong02)
        {
            scrAudioSource.Stop();
            scrAudioSource.PlayOneShot(audioClipBong02);
            scrCommunVariables.playBong02 = false;
        }
    }
}
