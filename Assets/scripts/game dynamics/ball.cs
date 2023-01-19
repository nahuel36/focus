using UnityEngine;
using System.Collections;
using System;

public class ball : MonoBehaviour {

    public AnimationCurve velocityAument;

    public pong pong;
    public borders borders;

    private Vector3 direction;

    public AudioSource wallSound;
    public AudioSource pongSound;
    public AudioSource looseSound;
    
    public gameManager levelMan;
    public achievementsManager achievements;

    private const float deltaXPosForStart = 2f;

	public bool canMove = false;
    public bool canRebote = false;

    private float velocity;
    private float actualTime;

    private Vector3 initPos;
	public spin ball_spin;

    public bool ponged;
    public bool ponged2times;
    private float ifponged;

    void Start()
    {
        EventsExecute.Instance.data.SetEnter("ball start x dir", wind);

        EventsExecute.Instance.data.SetEnter("start ball move", StartGame);

        EventsExecute.Instance.data.SetEnter("initialize ball", InitializeBall);

        EventsExecute.Instance.data.SetEnter("ball continue move", Continue);

        initPos = transform.position;
    }

    void Continue()
    {
        canMove = true;
        canRebote = true;
        ponged = false;
        ponged2times = false;

        Vector2 newPos = transform.position;
        newPos.y = pong.UpBorder();
        transform.position = newPos;
        
        changeDirPong();

        actualTime -= 5;
        velocity = velocityAument.Evaluate(actualTime);
        this.transform.Translate(direction * velocity);

        transform.GetChild(0).gameObject.SetActive(true);

        InvokeRepeating("move", 0.5f, 0.025f);
    }


    void InitializeBall()
    {
        transform.position = initPos;
        
        canMove = false;
        canRebote = true;
        ponged = false;
        ponged2times = false;
    }

    

    void wind()
    {
        float dirY = direction.y;
                
        float dirX = 0.65f; 
        if (UnityEngine.Random.Range(0, 2) == 0)
            dirX = 0.45f;
                
        if (UnityEngine.Random.Range(0, 2) == 0)
            dirX = -dirX; 

        Vector2 newDir = new Vector2(dirX, dirY);
        newDir.Normalize();
        direction = newDir;
        
    }


    void StartGame()
    {
        direction = new Vector3(0, -1, 0);
        canMove = true;
        InvokeRepeating("move", 0.5f, 0.025f);
        transform.GetChild(0).gameObject.SetActive(true);
        actualTime = 0;
    }


    void playSound(string what)
    {
        if (what == "loose")
            looseSound.Play();
        else if (what == "wall_up" || what == "wall" || what == "pong")
            pongSound.Play();
        else if (what == "pong2")
            wallSound.Play();
    }

    void changeRotation(int amount)
    {
        int sign = -1;
        if (direction.normalized.x < 0)
            sign = 1;

        ball_spin.velocity = sign * velocity * amount;
    }

    void changeDirHoriz(string dir)
	{
        if (dir == "left")
            direction.x =  Mathf.Abs(direction.x);
        else
            direction.x = -Mathf.Abs(direction.x);

        if (direction.x != 0)
        {
            if (ponged)
                changeRotation(10);
            else
                changeRotation(20);
        }

        playSound("wall");
	}

	void changeDirVert()
	{
        direction.y = -1;

        if (direction.x == 0)
            EventsExecute.Instance.ExecuteConditional( FocusEventConditional.Condition.ball_dirx_zero_and_collide_with_top);
            
        
        if (direction.x != 0)
        { 
            if(ponged)
                changeRotation(10);
            else
                changeRotation(30);
        }

        playSound("wall_up");
    }

	void changeDirPong()
	{
        direction.y = 1;
        
        if (UnityEngine.Random.Range(0, 10) > 8)
        {
            if (direction.x != 0)
                changeRotation(20);
            playSound("pong2");

            if(ponged2times)
                achievements.setAchievement(achievementsManager.achievement.ponged3);
            else if(ponged)
                achievements.setAchievement(achievementsManager.achievement.ponged2);
            else
                achievements.setAchievement(achievementsManager.achievement.ponged1);
            
            if (ponged)
               ponged2times = true;
               
            ponged = true;
        }
        else
        {
            if (direction.x != 0)
                changeRotation(45);
            playSound("pong");
            ponged = false;
            ponged2times = false;
        }

    }

    void move()
    {
        if (canMove)
        {
            if (canRebote)
            { 
                if (transform.position.x > borders.Right() || transform.position.x < borders.Left())
                {
                    if (transform.position.x > borders.Right())
                        changeDirHoriz("right");
                    else
                        changeDirHoriz("left");
                }

                if (transform.position.y > borders.Up())
                {
					changeDirVert ();
                }

                if (transform.position.y < pong.UpBorder())
                {
                    if (transform.position.x > pong.LeftBorder() && transform.position.x < pong.RightBorder())
                    {
						changeDirPong ();
                    }
                    else
                        Loose();
                }
            }

            actualTime += 0.025f * 0.1f;
            velocity = velocityAument.Evaluate(actualTime);

            ifponged = 1;
            if (ponged) ifponged = 0.7f;

            this.transform.Translate(direction * velocity * ifponged);
        }
    }

    private void Loose()
    {
        playSound("loose");
        canRebote = false;
        canMove = false;
        levelMan.Loose();
        transform.GetChild(0).gameObject.SetActive(false);
        CancelInvoke();
    }
}
