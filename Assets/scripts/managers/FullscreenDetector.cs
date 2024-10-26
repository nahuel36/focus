using UnityEngine;

public class FullscreenDetector : MonoBehaviour
{
    bool isFullScreen = false;
    Vector2 actualResolution;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFullScreen = Screen.fullScreen;
        actualResolution = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFullScreen && Screen.fullScreen)
        {
            isFullScreen = true;
            Screen.SetResolution(Screen.width, Screen.height, true);

        }
        else if (isFullScreen && !Screen.fullScreen)
        {
            isFullScreen = false;
            Screen.SetResolution(Mathf.RoundToInt(actualResolution.x), Mathf.RoundToInt(actualResolution.y), false);
        }
    }
}
