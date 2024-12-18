using UnityEngine;

[System.Serializable]
public enum cheatsActivators
{
    style,
    achiv
}

[System.Serializable]
public class Cheats : MonoBehaviour
{

    [SerializeField] cheatsActivators[] activateCombination;
    [SerializeField] GameObject debugButton;
    int combinationIndex = 0;
    [SerializeField] bool forceDebug = false; 
    private void Start()
    {
        combinationIndex = 0;

        if (forceDebug)
            EnableDebug();

#if UNITY_EDITOR
        EnableDebug();
#endif
    }

    private void EnableDebug()
    { debugButton.SetActive(true); }

    public void CallStyle() {
        CallCombination(cheatsActivators.style);
    }

    public void CallAchiv() {
        CallCombination(cheatsActivators.achiv);
    }

    public void CallCombination(cheatsActivators activator)
    {
        if (activateCombination[combinationIndex] == activator)
            combinationIndex++;
        else if (activateCombination[0] == activator)
            combinationIndex = 1;
        else
            combinationIndex = 0;

        if (combinationIndex >= activateCombination.Length)
            EnableDebug();
    }
    

}
