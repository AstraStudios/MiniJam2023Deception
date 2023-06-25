using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    GameObject player;

    Player playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerScript = player.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
            playerScript.Death();
    }
}
