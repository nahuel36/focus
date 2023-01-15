using UnityEngine;
using System.Collections;

public class particles_circle : MonoBehaviour {

    public ParticleSystem particles;
    public bool showing;

	void Start ()
    {
        showing = false;
        EventsExecute.Instance.data.SetEnter("show particles", Show);
        EventsExecute.Instance.data.SetLeave("show particles", Hide);
        EventsExecute.Instance.data.SetEnter("pause actual fx", Stop);
        EventsExecute.Instance.data.SetEnter("resume actual fx", Resume);
        //gameEvents.effects_showParticles += Show;
        //gameEvents.effects_hideParticles += Hide;
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    void Resume()
    {
        if (showing)
            Show();
    }

    void Stop()
    {
        if(showing && particles != null)
            particles.Pause();
    }
    void Hide()
    {
        if(particles != null)
        {
            showing = false;
            particles.Stop();
        }
    }

    void Show()
    {
        if (particles != null)
        {
            showing = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
            particles.Play();
        }
    }

    

}
