using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // spawn clone
            Instantiate(clone, collision.gameObject.transform.position, Quaternion.identity);
            player.transform.position = new Vector2(0, -3);
        }
    }
}
