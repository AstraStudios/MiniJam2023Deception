using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject clone;

    Player playerScript;

    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
            playerScript.Death();
    }
}
