
using UnityEngine;

public class UIManagerStartScene : MonoBehaviour
{
    protected static UIManagerStartScene instance;
    public static UIManagerStartScene Instance { get { return instance; } }

    protected GameObject btnPlay;
    protected GameObject btnRate;
    protected GameObject btnClassic;
    protected GameObject btnSurvival;
    protected GameObject term;

    private void Awake()
    {
        UIManagerStartScene.instance = this;
        SetBtn();
        
    }

    private void Start()
    {
        CheckTerm();
    }
    protected void SetBtn()
    {
        btnPlay = GameObject.Find("BtnPlay");
        term = GameObject.Find("Terms");
    }

    public void CheckTerm()
    {
        if (GameManager.Instance.Player.accept) HideTerm();
        else term.SetActive(true);
    }
    public void HideTerm()
    {
        term.SetActive(false);
    }
}
