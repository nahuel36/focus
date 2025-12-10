using UnityEngine;
using System.Collections;

public class MusicInMenu : MonoBehaviour {
    public AudioSource music;
	// Use this for initialization
	void Start () {
        music.Play();
        music.loop = true;
	}

    public void stopMusic() {
        music.Stop();
    }


}
