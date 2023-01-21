using UnityEngine;
using System.Collections;

public class borders : MonoBehaviour {

   public Transform LeftTransform;
   public Transform RightTransform;
   public Transform UpTransform;

    private const float delta = 0.27f;
    private Vector3 initPos;

    private bool moving;

    void Start()
    {
        gameManager.startPressed += setInitPos;

        EventsExecute.Instance.data.SetEnter("move_border_down", StartMove);
        EventsExecute.Instance.data.SetLeave("move_border_down", StopMove);
        
        gameManager.loose += loose;
        gameManager.continue_pressed += continue_pressed;

        initPos = UpTransform.position;
    }

    void setInitPos()
    {
        moving = false;
        UpTransform.position = initPos;
    }

    void StartMove()
    {
        moving = true;
        InvokeRepeating("move", 0, 2f);
    }


    void StopMove()
    {
        moving = false;
        CancelInvoke();
    }

    void continue_pressed()
    {
        if (moving)
            StartMove();

    }
    void loose()
    {
        CancelInvoke();
    }

    void move()
    {
        UpTransform.Translate(Vector3.down * 0.05f);
            
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
