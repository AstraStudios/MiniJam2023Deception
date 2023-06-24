using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    AudioSource audioPlayer;
    int currentClipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        audioPlayer.loop = false;
        PlayNextClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayNextClip()
    {
        currentClipIndex = Random.Range(0, audioClips.Count);
        audioPlayer.clip = audioClips[currentClipIndex];

        currentClipIndex++;
        audioPlayer.Play();
    }
}
