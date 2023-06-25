using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject clone;
    [SerializeField] bool clonesTurnEvil = true;

    Vector2 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            transform.position = spawnPosition;
    }

    public void Death()
    {
        GameObject newClone = Instantiate(clone, transform.position, Quaternion.identity);
        newClone.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        newClone.GetComponent<SpriteRenderer>().flipX = transform.GetChild(1).GetComponent<SpriteRenderer>().flipX;
        newClone.GetComponent<Clone>().turnEvil = clonesTurnEvil;

        transform.position = spawnPosition;
    }
}
