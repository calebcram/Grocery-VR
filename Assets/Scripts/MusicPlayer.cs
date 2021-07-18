using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource source;
    private int newSong;
    private int previousSong;
    private bool inStore;

    public bool isStore;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        newSong = -1;
        previousSong = -1;
        source = GetComponent<AudioSource>();
    }
    void Update() {
        if (!source.isPlaying && isStore && inStore) {
            previousSong = newSong;

            while (newSong == previousSong) {
                newSong = Random.Range(0, sounds.Length);
            }

            source.clip = sounds[newSong];
            source.Play();
        }
    }

    void OnTriggerEnter(Collider player) {
        if (player.gameObject.tag == "Player") {

            if (isStore) {
                inStore = true;
            }

            newSong = Random.Range(0, sounds.Length);

            source.clip = sounds[newSong];
            source.Play();
        }
    }

    void OnTriggerExit(Collider player) {
        if (player.gameObject.tag == "Player") {

            if (isStore) {
                inStore = false;
            }

            source.Stop();
        }
    }
}
