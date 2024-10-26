using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Pong : MonoBehaviour {

    public Borders borders;

    private float XScale = 0.9f;
    private float YScale = 1f;
 
	private Vector3 newPos;
    private bool haveNewPos;

    public float LeftBorder()
    {
        return this.transform.position.x - XScale / 2;
    }
    public float RightBorder()
    {
        return this.transform.position.x + XScale / 2;
    }

    public float Middle()
    {
        return this.transform.position.x;
    }
    public float UpBorder()
    {
        return this.transform.position.y + YScale / 2;
    }

    private Vector3 initPos;

    public void Start()
    {
        initPos = transform.position;
        EventsExecute.Instance.data.SetEnter("start pong move", startMoving);
        EventsExecute.Instance.data.SetEnter("stop pong move", loose);
        EventsExecute.Instance.data.SetEnter("invencible pong", invencible);
    }

    private void invencible()
    {
        XScale = 50;
    }

    private float speed = 0.5f;
    private float repeatRate = 0.025f;

    /*
    public void Continue()
    {
        InvokeRepeating("Move", 0, repeatRate);
        haveNewPos = false;
    }
    */

    public void startMoving()
    {
        InvokeRepeating("Move", 0, repeatRate);
        transform.position = initPos;
		newPos = initPos;
        haveNewPos = false;
    }

    void loose()
    {
        CancelInvoke();
    }

    void Move()
    {
       
        if (Input.GetMouseButton(0))
        {
            haveNewPos = true;
			newPos = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, transform.position.y, transform.position.z);
        }
        if(haveNewPos)
        { 
            if (Vector2.Distance(transform.position, newPos) < 0.1f)
                haveNewPos = false;
            else
                transform.position = Vector3.Lerp(transform.position, newPos, speed);
        }
    }
}
