using UnityEngine;
using System.Collections;

public class Particles_circle : MonoBehaviour {

    public ParticleSystem particles;
    public bool showing;

	void Start ()
    {
        showing = false;
        EventsExecute.Instance.data.SetEnter("show particles", Play);
        EventsExecute.Instance.data.SetLeave("show particles", Stop);
        EventsExecute.Instance.data.SetEnter("pause actual fx", Pause);
        EventsExecute.Instance.data.SetEnter("resume actual fx", Resume);
        EventsExecute.Instance.data.SetEnter("hide actual fx", Hide);
        Hide();
    }

    void Resume()
    {
        if (showing)
            Play();
    }

    void Pause()
    {
        if(showing && particles != null)
            particles.Pause();
    }
    void Stop()
    {
        if(particles != null)
        {
            showing = false;
            particles.Stop();
        }
    }

    void Play()
    {
        if (particles != null)
        {
            showing = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
            particles.Play();
        }
    }

    void Hide()
    {
        if (particles != null)
        {
            showing = false;
            this.transform.GetChild(0).gameObject.SetActive(false);
            particles.Stop();
        }
    }

}
