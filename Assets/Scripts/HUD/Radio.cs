using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

    [SerializeField]
    AudioClip[] musicPlaylist;

	// Use this for initialization
	void Start ()
    {
        int newSong = Random.Range(0, musicPlaylist.Length);
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().clip = musicPlaylist[newSong];
        gameObject.GetComponent<AudioSource>().Play();

        Invoke("LoadNewSong", musicPlaylist[newSong].length);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void LoadNewSong()
    {
        int newSong = Random.Range(0, musicPlaylist.Length);
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().clip = musicPlaylist[newSong];
        gameObject.GetComponent<AudioSource>().Play();

        Invoke("LoadNewSong", musicPlaylist[newSong].length);
    }
}
