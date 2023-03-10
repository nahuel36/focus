using UnityEngine;
using System.Collections;

public class musicinmenu : MonoBehaviour {
    public AudioSource music;
	// Use this for initialization
	void Start () {
        music.Play();
        music.loop = true;
	}

    public void stopMusic() {
        music.Stop();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
