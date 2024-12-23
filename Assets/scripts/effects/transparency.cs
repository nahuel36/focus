using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour {

    [SerializeField] bool isImage = false;
    [SerializeField] bool isShader = false;
    [SerializeField] bool useCurve = false;
    [SerializeField] AnimationCurve curve;
    

    SpriteRenderer transSpriteRenderer;
    Image transImage;

    [SerializeField]string type;

    private float speed = 0.05f;
    private float repeatRate = 0.025f;
    private Color colorWithAlpha;
    private Color colorWithoutAlpha;
    private MeshRenderer shaderRenderer;
    private float shaderCounter = 0;
    private MaterialPropertyBlock propBlock;
    [SerializeField][Range(0, 1)] float maxAlpha = 1;
    private bool showing;
    private bool hiding;
    private bool isTwirl;

    [SerializeField] AudioSource[] appearSound;

    void Start () {

        transform.GetChild(0).gameObject.SetActive(true);
        if (isShader)
        {
            shaderRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
            propBlock = new MaterialPropertyBlock();
            shaderRenderer.SetPropertyBlock(propBlock);
        }
        else if (!isImage)
        {
            transSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            colorWithAlpha = transSpriteRenderer.color;
            if (colorWithAlpha.a == 0)
                colorWithAlpha.a = maxAlpha;
            colorWithoutAlpha = transSpriteRenderer.color;
            colorWithoutAlpha.a = 0;
        }
        else
        {
            transImage = transform.GetChild(0).GetComponent<Image>();
            colorWithAlpha = transImage.color;
            if (colorWithAlpha.a == 0)
                colorWithAlpha.a = maxAlpha;
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

            EventsExecute.Instance.data.SetEnter("show spin", Show);
            EventsExecute.Instance.data.SetLeave("show spin", Hide);
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);

        }
        else if (type == "smoke")
        {
            EventsExecute.Instance.data.SetLeave("show smoke", Hide);
            EventsExecute.Instance.data.SetEnter("show smoke", Show);
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);

        }
        else if (type == "ball")
        {
            //Debug.Log("activating show " + gameObject.name);
            EventsExecute.Instance.data.SetEnter("show ball", Show);
            EventsExecute.Instance.data.SetEnter("hide ball", Hide);
        }
        else if (type == "pong")
        {
            EventsExecute.Instance.data.SetEnter("show pong", Show);
            EventsExecute.Instance.data.SetEnter("hide pong", Hide);
        }
        else if (type == "swipe")
        {
            EventsExecute.Instance.data.SetEnter("show swipe", Show);
            EventsExecute.Instance.data.SetEnter("hide swipe", Hide);
        }
        else if (type == "border_up")
        {
            EventsExecute.Instance.data.SetEnter("show border up", Show);
            EventsExecute.Instance.data.SetEnter("hide borders", Hide);
        }
        else if (type == "border_left" || type == "border_right")
        {
            EventsExecute.Instance.data.SetEnter("show border side", Show);
            EventsExecute.Instance.data.SetEnter("hide borders", Hide);
        }
        else if (type == "fractal")
        {
            EventsExecute.Instance.data.SetEnter("show fractal", Show);
            EventsExecute.Instance.data.SetLeave("show fractal", Hide);
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);
        }
        else if (type == "kalei")
        {
            EventsExecute.Instance.data.SetEnter("show kalei", Show);
            EventsExecute.Instance.data.SetLeave("show kalei", Hide);
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);
        }
        else if (type == "twirl")
        {
            isTwirl = true;
            EventsExecute.Instance.data.SetEnter("show twirl", Show);
            EventsExecute.Instance.data.SetLeave("show twirl", Hide);
            EventsExecute.Instance.data.SetLeave("hide twirl", HideFast);
            EventsExecute.Instance.data.SetEnter("hide actual fx", HideFast);
        }
    }


    void HideFast()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Show()
    {
        if (this == null) return;
        CancelInvoke();

        if (appearSound != null && appearSound.Length > 0)
            appearSound[Random.Range(0, appearSound.Length)].Play();

        if (isShader && useCurve)
        {
            showing = true;
        }
        else
            InvokeRepeating("Showing", 0, repeatRate);
        transform.GetChild(0).gameObject.SetActive(true);
        if (!isImage && !isShader)
            transSpriteRenderer.color = colorWithoutAlpha;
        else if (!isShader)
            transImage.color = colorWithoutAlpha;
    }

    void Hide()
    {
        if (this == null) return;
        CancelInvoke();
        if (isShader && useCurve)
        {
            hiding = true;
        }
        else
            InvokeRepeating("Hiding", 0, repeatRate);
        transform.GetChild(0).gameObject.SetActive(true);
        if (!isImage && !isShader)
            transSpriteRenderer.color = colorWithAlpha;
        else if (!isShader)
            transImage.color = colorWithAlpha;
    }

    void Showing()
    {
        if (isShader || (!isImage && transSpriteRenderer.color == colorWithAlpha) || (isImage && transImage.color == colorWithAlpha ))
        {
            CancelInvoke();
        }
        if (!isImage)
            transSpriteRenderer.color = Color.Lerp(transSpriteRenderer.color, colorWithAlpha, speed);
        else
            transImage.color = Color.Lerp(transImage.color, colorWithAlpha, speed);
    }

    void Hiding()
    {
        if (isShader || (!isImage && transSpriteRenderer.color == colorWithoutAlpha) || (isImage && transImage.color == colorWithoutAlpha))
        {
          transform.GetChild(0).gameObject.SetActive(false);
          CancelInvoke();
        }
        if (!isImage)
            transSpriteRenderer.color = Color.Lerp(transSpriteRenderer.color, colorWithoutAlpha, speed);
        else
            transImage.color = Color.Lerp(transImage.color, colorWithoutAlpha, speed);
    }

    private void Update()
    {
        if (showing)
        {
            shaderCounter = Mathf.Lerp(shaderCounter, 1, speed*Time.deltaTime*55);
            float alphavalue = curve.Evaluate(shaderCounter)*shaderCounter*shaderCounter;
            propBlock.SetFloat("_Alpha", alphavalue);

            if (alphavalue >= 0.9f)
            {
                propBlock.SetFloat("_Alpha", 1);
                showing = false;
            }
            shaderRenderer.SetPropertyBlock(propBlock);

        }
        if (hiding)
        {
            if (isTwirl)
            {
                shaderCounter = Mathf.Lerp(shaderCounter, 0, speed * Time.deltaTime * 1.5f);
            }
            else 
            {
                shaderCounter = Mathf.Lerp(shaderCounter, 0, speed * Time.deltaTime * 55);
            }

            float alphavalue = curve.Evaluate(shaderCounter) * shaderCounter * shaderCounter;
            propBlock.SetFloat("_Alpha", alphavalue);

            if (alphavalue <= 0.001f)
            {
                propBlock.SetFloat("_Alpha", 0);
                hiding = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            shaderRenderer.SetPropertyBlock(propBlock);
        }
    }

    public void OnDestroy()
    {
        CancelInvoke();
    }
}