using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pong : MonoBehaviour {

    public borders borders;

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
