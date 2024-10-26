using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {

    public enum Mode { 
        normal,
        blue, 
        red, 
        green
    }

    private Mode mode;

    [SerializeField] Color normalModeColor;
    [SerializeField] Color redModeColor;
    [SerializeField] Color blueModeColor;
    [SerializeField] Color greenModeColor;
    SpriteRenderer spriteRenderer;

    [SerializeField] AnimationCurve velocityAument;

    [SerializeField] Pong pong;
    [SerializeField] Borders borders;

    private Vector3 direction;

    [SerializeField] AudioSource wallSound;
    [SerializeField] AudioSource pongSound;
    [SerializeField] AudioSource looseSound;
    
    [SerializeField] GameManager levelMan;
    [SerializeField] AchievementsManager achievements;

    private const float deltaXPosForStart = 2f;

	private bool canMove = false;
    private bool canRebote = false;

    private float velocity;
    private float actualTime;

    private Vector3 initPos;
	[SerializeField] Spin ball_spin;

    private bool ponged;
    private bool ponged2times;
    private float pongedVelocityMultiplier;

    [SerializeField] PointsCounter points;

    void Start()
    {
        EventsExecute.Instance.data.SetEnter("ball start x dir", wind);

        EventsExecute.Instance.data.SetEnter("start ball move", StartGame);

        EventsExecute.Instance.data.SetEnter("initialize ball", InitializeBall);

        EventsExecute.Instance.data.SetEnter("ball continue move", Continue);

        initPos = transform.position;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void changeMode(Mode mode)
    {
        switch (mode)
        {
            case Mode.normal:
                spriteRenderer.color = normalModeColor;
                break;
            case Mode.blue:
                spriteRenderer.color = blueModeColor;
                break;
            case Mode.red:
                spriteRenderer.color = redModeColor;
                break;
            case Mode.green:
                spriteRenderer.color = greenModeColor;
                break;
            default:
                spriteRenderer.color = normalModeColor;
                break;
        }

        this.mode = mode;
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

        if (actualTime > 5)
            actualTime -= 5;
        else
            actualTime = 0;
        velocity = velocityAument.Evaluate(actualTime);
        this.transform.Translate(direction * velocity);

        transform.GetChild(0).gameObject.SetActive(true);
        CancelInvoke("move");
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
            dirX = 0.5f;

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
        if (mode == Mode.blue)
            points.AddPoint(1);
        else if (mode == Mode.red)
            points.AddPoint(3);
        else if (mode == Mode.normal)
            points.AddPoint(2);

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

	void changeDirPong(float relativePos = 1)
	{
        direction.y = 1;
        
        if(direction.x < 0)
            direction.x = direction.x * -relativePos;
        if (direction.x > 0)
            direction.x = direction.x * relativePos;

        if (direction.x > 0 && direction.x < 0.15f)
            direction.x += 0.25f;
        if (direction.x < 0 && direction.x > -0.15f)
            direction.x -= 0.25f;


        if (UnityEngine.Random.Range(0, 10) > 8)
        {
            if (direction.x != 0)
                changeRotation(20);
            playSound("pong2");

            if(ponged2times)
                achievements.setAchievement(AchievementsManager.achievement.ponged3);
            else if(ponged)
                achievements.setAchievement(AchievementsManager.achievement.ponged2);
            else
                achievements.setAchievement(AchievementsManager.achievement.ponged1);
            
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
                        float relative = 1;
                        float middle_left = Mathf.InverseLerp(pong.Middle(),pong.LeftBorder(), transform.position.x);
                        float middle_right = Mathf.InverseLerp(pong.Middle(), pong.RightBorder(), transform.position.x);

                        relative = (-middle_left + middle_right)*1.5f;
                        
                        changeDirPong (relative);
                    }
                    else
                        Loose();
                }
            }

            actualTime += 0.025f * 0.1f;
            velocity = velocityAument.Evaluate(actualTime);

            pongedVelocityMultiplier = 1;
            if (ponged) pongedVelocityMultiplier = 0.7f;

            this.transform.Translate(direction * velocity * pongedVelocityMultiplier);
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

