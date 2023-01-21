using UnityEngine;
using System.Collections;

public class borders : MonoBehaviour {

   public Transform LeftTransform;
   public Transform RightTransform;
   public Transform UpTransform;

    private const float delta = 0.27f;
    private Vector3 initPos;

    private bool moving;
    private bool paused;

    void Start()
    {
        EventsExecute.Instance.data.SetEnter("move border to init", setInitPos);

        EventsExecute.Instance.data.SetEnter("move_border_down", StartMove);
        EventsExecute.Instance.data.SetLeave("move_border_down", StopMove);

        EventsExecute.Instance.data.SetEnter("move_border_pause", pause);
        EventsExecute.Instance.data.SetEnter("move_border_resume", continue_pressed);

        initPos = UpTransform.position;
    }

    private void Update()
    {
        if(moving && !paused)
        {
            UpTransform.Translate(Vector3.down * 0.05f * Time.deltaTime);
        }
    }

    void setInitPos()
    {
        moving = false;
        UpTransform.position = initPos;
    }

    void StartMove()
    {
        moving = true;
        paused = false;
    }


    void StopMove()
    {
        moving = false;
    }

    void continue_pressed()
    {
        paused = false;

    }
    void pause()
    {
        paused = true;
    }






    public float Left() {
        return LeftTransform.position.x + delta;
    }

    public float Right()
    {
        return RightTransform.position.x - delta;

    }

    public float Up()
    {
        return UpTransform.position.y - delta;

    }
    
    
}
