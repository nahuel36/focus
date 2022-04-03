using UnityEngine;
using System.Collections;

public class particles_circle : MonoBehaviour {

    public ParticleSystem particles;

	void Start ()
    {
        gameEvents.effects_showParticles += Show;
        gameEvents.effects_hideParticles += Hide;
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    
    void Hide()
    {
        if(particles != null)
        { 
            particles.Stop();
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void Show()
    {
        if (particles != null)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            particles.Play();
        }
    }

    

}
