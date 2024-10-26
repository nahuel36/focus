using UnityEngine;

public class IngameMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource[] musicIngame;
    void Start()
    {
        EventsExecute.Instance.data.SetEnter("music ingame play", Play);
        EventsExecute.Instance.data.SetEnter("music ingame stop", Stop);
    }

    // Update is called once per frame
    void Play()
    {
        musicIngame[Random.Range(0, musicIngame.Length)].Play();
    }

    private void Stop()
    {
        for (int i = 0; i < musicIngame.Length; i++)
        {
            musicIngame[i].Stop();
        }
    }
}
