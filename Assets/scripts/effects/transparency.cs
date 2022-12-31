using UnityEngine;
using System.Collections;

public class transparency : MonoBehaviour {

    SpriteRenderer transMaterial;

    public string type;

    private float speed = 0.05f;
    private float repeatRate = 0.025f;
    private Color colorWithAlpha;
    private Color colorWithoutAlpha;
    private EventsExecute eventsEx;

    void Start () {

        eventsEx = FindObjectOfType<EventsExecute>();
        transform.GetChild(0).gameObject.SetActive(true);
        transMaterial = transform.GetChild(0).GetComponent<SpriteRenderer>();
        colorWithAlpha = transMaterial.color;
        colorWithoutAlpha = transMaterial.color;
        colorWithoutAlpha.a = 0;
        transform.GetChild(0).gameObject.SetActive(false);
        
        if (type == "particles")
        {
            gameEvents.effects_hideParticles += Hide;
            gameEvents.effects_showParticles += Show;

        }
        else if (type == "spin")
        {
            gameEvents.effects_hideSpin += Hide;
            gameEvents.effects_showSpin += Show;

        }
        else if (type == "smoke")
        {
            gameEvents.effects_hideSmoke += Hide;
            gameEvents.effects_showSmoke += Show;

        }
        else if (type == "ball")
        {
            eventsEx.data.OnStartPressedEvents["show ball"].OnEnter += Show;
            gameEvents.ball_hide += Hide;
        }
        else if (type == "pong")
        {
            gameEvents.pong_show += Show;
            gameEvents.ball_hide += Hide;
        }

    }


    void Show()
    {
        CancelInvoke();
        InvokeRepeating("showing", 0,repeatRate);
        transform.GetChild(0).gameObject.SetActive(true);
        transMaterial.color = colorWithoutAlpha;
    }

    void Hide()
    {
        CancelInvoke();
        InvokeRepeating("hiding", 0, repeatRate);
        transform.GetChild(0).gameObject.SetActive(true);
        transMaterial.color = colorWithAlpha;
    }

    void showing()
    {
        if (transMaterial.color == colorWithAlpha)
        {
            CancelInvoke();
        }
        transMaterial.color = Color.Lerp(transMaterial.color, colorWithAlpha, speed);
    }

    void hiding()
    {
        if (transMaterial.color == colorWithoutAlpha)
        {
          transform.GetChild(0).gameObject.SetActive(false);
          CancelInvoke();
        }
        transMaterial.color = Color.Lerp(transMaterial.color, colorWithoutAlpha, speed);
    }
}