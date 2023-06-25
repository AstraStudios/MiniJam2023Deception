using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] string levelToLoad;

    bool inZone;

    // Start is called before the first frame update
    void Start()
    {
        inZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.E))
            LoadLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone = false;
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
