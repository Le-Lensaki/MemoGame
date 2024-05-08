using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMainScene : MonoBehaviour
{
    protected static UIManagerMainScene instance;
    public static UIManagerMainScene Instance { get { return instance; } }

    protected GameObject countTime;
    protected GameObject btnVolume;
    protected GameObject btnPause;
    protected GameObject btnSearch;
    protected GameObject uIWin;
    protected GameObject uILose;
    protected GameObject uIBoxgold;
    protected GameObject uIPlusHint;

    [SerializeField] protected Sprite volumeOff;
    [SerializeField] protected Sprite volumeOn;
    [SerializeField] protected Sprite pause;
    [SerializeField] protected Sprite play;
    [SerializeField] protected Sprite starShow;
    [SerializeField] protected Sprite starHide;



    private void Awake()
    {
        UIManagerMainScene.instance = this;
        SetBtn();
        HideUI();


    }
    private void Start()
    {
       
    }

    protected void SetBtn()
    {
        countTime = GameObject.Find("Timing");
       
        btnVolume = GameObject.Find("BtnVolume");
        btnPause = GameObject.Find("BtnPause");
        uIWin = GameObject.Find("BackgroundWin");
        uILose = GameObject.Find("BackgroundLose");
        uIBoxgold = GameObject.Find("Boxgold");
        uIPlusHint = GameObject.Find("PlusHint");
    }

    public void HideUI()
    {
        uIWin.SetActive(false);
        uILose.SetActive(false);
        uIBoxgold.SetActive(false);
        uIPlusHint.SetActive(false);
    }

    public void OpenBoxgold()
    {
        uIBoxgold.SetActive(true);
    }

    public void PlusHint()
    {
        uIPlusHint.SetActive(true);
    }

    public void ChangeSpriteButtonVolume(float volume)
    {
        if (volume == 0) btnVolume.GetComponent<Image>().sprite = volumeOff;
        else btnVolume.GetComponent<Image>().sprite = volumeOn;
    }
    public void ChangeSpriteButtonPause()
    {
        if (Time.timeScale == 0) btnPause.transform.GetChild(0).GetComponent<Image>().sprite = play;
        else btnPause.transform.GetChild(0).GetComponent<Image>().sprite = pause;
    }

    
    public void SetTiming(string time)
    {
        countTime.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = time;
    }

    public void ShowWin(int star,int score)
    {
        uIWin.SetActive(true);
        ClearStartWin();
        if(star > 0)
        {
            for (int i = 0; i < star; i++)
            {
                uIWin.transform.GetChild(i).GetComponent<Image>().sprite = starShow;
            }
        }    
        uIWin.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void ShowLose(int star,int score)
    {
        uILose.SetActive(true);
        ClearStartLose();
        if(star > 0)
        {
            for (int i = 0; i < star; i++)
            {
                uILose.transform.GetChild(i).GetComponent<Image>().sprite = starShow;
            }
        }
        uILose.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    protected void ClearStartWin()
    {
        for (int i = 0; i < 3; i++)
        {
            uIWin.transform.GetChild(i).GetComponent<Image>().sprite = starHide;

        }
    }
    protected void ClearStartLose()
    {
        for (int i = 0; i < 3; i++)
        {
            uILose.transform.GetChild(i).GetComponent<Image>().sprite = starHide;
        }
    }


}
