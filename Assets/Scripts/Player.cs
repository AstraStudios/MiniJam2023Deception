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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        Instantiate(clone, transform.position, Quaternion.identity);
        transform.position = spawnPosition;
    }
}
