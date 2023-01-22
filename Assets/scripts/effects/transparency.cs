using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class transparency : MonoBehaviour {

    [SerializeField] bool isImage = false;

    SpriteRenderer transSpriteRenderer;
    Image transImage;

    [SerializeField]string type;

    private float speed = 0.05f;
    private float repeatRate = 0.025f;
    private Color colorWithAlpha;
    private Color colorWithoutAlpha;

    void Start () {

        transform.GetChild(0).gameObject.SetActive(true);
        if(!isImage)
        { 
            transSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            colorWithAlpha = transSpriteRenderer.color;
            colorWithoutAlpha = transSpriteRenderer.color;
            colorWithoutAlpha.a = 0;
        }
        else
        {
            transImage = transform.GetChild(0).GetComponent<Image>();
            colorWithAlpha = transImage.color;
            colorWithoutAlpha = transImage.color;
            colorWithoutAlpha.a = 0;
        }
        transform.GetChild(0).gameObject.SetActive(false);
        
        if (type == "particles")
        {
            EventsExecute.Instance.data.SetEnter("show particles", Show);
            EventsExecute.Instance.data.SetLeave("show particles", Hide);
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);

        }
        else if (type == "spin")
        {
            gameEvents.effects_hideSpin += Hide;
            gameEvents.effects_showSpin += Show;
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);

        }
        else if (type == "smoke")
        {
            gameEvents.effects_hideSmoke += Hide;
            gameEvents.effects_showSmoke += Show;
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);

        }
        else if (type == "ball")
        {
            EventsExecute.Instance.data.SetEnter("show ball",Show);
            EventsExecute.Instance.data.SetEnter("hide ball", Hide);
        }
        else if (type == "pong")
        {
            EventsExecute.Instance.data.SetEnter("show pong", Show);
            EventsExecute.Instance.data.SetEnter("hide pong", Hide);
        }
        else if( type == "swipe")
        {
            EventsExecute.Instance.data.SetEnter("show swipe",Show);
            EventsExecute.Instance.data.SetEnter("hide swipe", Hide);
        }

    }


    void HideFast()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Show()
    {
        CancelInvoke();
        InvokeRepeating("showing", 0,repeatRate);
        transform.GetChild(0).gameObject.SetActive(true);
        if (!isImage)
            transSpriteRenderer.color = colorWithoutAlpha;
        else
            transImage.color = colorWithoutAlpha;
    }

    void Hide()
    {
        CancelInvoke();
        InvokeRepeating("hiding", 0, repeatRate);
        transform.GetChild(0).gameObject.SetActive(true);
        if (!isImage)
            transSpriteRenderer.color = colorWithAlpha;
        else
            transImage.color = colorWithAlpha;
    }

    void showing()
    {
        if ((!isImage && transSpriteRenderer.color == colorWithAlpha) || (isImage && transImage.color == colorWithAlpha ))
        {
            CancelInvoke();
        }
        if(!isImage)
            transSpriteRenderer.color = Color.Lerp(transSpriteRenderer.color, colorWithAlpha, speed);
        else 
            transImage.color = Color.Lerp(transImage.color, colorWithAlpha, speed);
    }

    void hiding()
    {
        if ((!isImage && transSpriteRenderer.color == colorWithoutAlpha) || (isImage && transImage.color == colorWithoutAlpha))
        {
          transform.GetChild(0).gameObject.SetActive(false);
          CancelInvoke();
        }
        if(!isImage)
            transSpriteRenderer.color = Color.Lerp(transSpriteRenderer.color, colorWithoutAlpha, speed);
        else
            transImage.color = Color.Lerp(transImage.color, colorWithoutAlpha, speed);
    }
}