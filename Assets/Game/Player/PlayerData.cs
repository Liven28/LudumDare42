using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int playerNumber;
    public bool playerDead;
    public Vector3 posPlayer;

    private void Update()
    {
        posPlayer = gameObject.transform.position;
    }
}
