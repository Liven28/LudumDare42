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

    void Awake ()
    {
        Commun = GameObject.Find("Commun");
        scrCommunVariables = Commun.GetComponent<CommunVariables>();

        scrAudioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
		if (scrCommunVariables.playBong)
        {
            scrAudioSource.Stop();
            NumClip = Random.Range(0, tabAudioClip.Length - 1);

            scrAudioSource.PlayOneShot(tabAudioClip[NumClip]);
            scrCommunVariables.playBong = false;
        }
	}
}
