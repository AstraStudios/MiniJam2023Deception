using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 spawnPosition;
    [SerializeField] GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform.position;
    }

    public void Death()
    {
        GameObject newClone = Instantiate(clone, transform.position, Quaternion.identity);
        newClone.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        newClone.GetComponent<SpriteRenderer>().flipX = transform.GetChild(1).GetComponent<SpriteRenderer>().flipX;

        transform.position = spawnPosition;
    }
}
