using UnityEngine;

public class FullscreenDetector : MonoBehaviour
{
    bool isFullScreen = false;
    Vector2 actualResolution;
    FullScreenMode actualmode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFullScreen = Screen.fullScreen;
        actualResolution = new Vector2(Screen.width, Screen.height);
        actualmode = Screen.fullScreenMode;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFullScreen && Screen.fullScreen)
        {
            isFullScreen = true;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else if (isFullScreen && !Screen.fullScreen)
        {
            isFullScreen = false;
            Screen.SetResolution(Mathf.RoundToInt(actualResolution.x), Mathf.RoundToInt(actualResolution.y), false);
            Screen.fullScreenMode = actualmode;
        }
    }
}
