using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    protected PlayerStatus status;
    public PlayerStatus Status { get { return status; } }

    protected PlayerUI uI;
    public PlayerUI UI { get { return uI; } }

    protected float timeLeft = 300f;
    protected bool stopCount = false;
    

    private void Awake()
    {
        PlayerController.instance = this;
        this.status = GetComponent<PlayerStatus>();
        this.uI = GetComponent<PlayerUI>();
    }

    IEnumerator WaitCloseItem()
    {
        yield return new WaitForSeconds(1);
        if(status.ItemOpen.Count == 2)
        {
            int itemA = status.ItemOpen[0].GetComponent<ItemController>().Status.Item;
            int itemB = status.ItemOpen[1].GetComponent<ItemController>().Status.Item;

            if (itemA == itemB)
            {
                status.ItemOpen[0].GetComponent<ItemController>().DisableObject();
                status.ItemOpen[1].GetComponent<ItemController>().DisableObject();
                status.PlusScore();
                AudioManager.Instance.PlaySFX("Right");
            }
            else
            {
                foreach (var item in status.ItemOpen)
                {
                    item.GetComponent<ItemController>().Close();

                }
            }
            status.ClearItemOpen();
        }
        ResultsController.Instance.UI.Chosse();

    }

    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        status.ClearScore();
        uI.ClearScore();
        status.ClearHint();
        status.ClearHint2();   
        uI.ClearHint();
        ResultsController.Instance.CreateResult();
        timeLeft = 300f;
        stopCount = false;
    }

    public void AddItemOpen(GameObject item)
    {
        status.AddItemOpen(item);
        if (status.ItemOpen.Count == 2)
        {
            ResultsController.Instance.UI.StopChosse();
            StartCoroutine(WaitCloseItem());
        }
    }

    public void RemoveItemOpen(GameObject item)
    {
        status.RemoveItemOpen(item);
    }

    public void NewMath()
    {
        stopCount = false;
    }

    public void PlayerSearch()
    {
        if(!ResultsController.Instance.CheckHoverItem())
        {
            if (status.UpdateHint())
            {
                ResultsController.Instance.SearchItem();
                uI.SetHint();
            }
        }    
          
    }


    public void Plushint()
    {
        status.UpdateHint2();
        PlayerSearch();
    }

    public int GetNumberHint()
    {
        return status.Hint;
    }    

    protected void PlayerWin()
    {
        UIManagerMainScene.Instance.ShowWin(status.Score / 14,status.Score);
        stopCount = true;
        GameManager.Instance.UpdateData();
        AudioManager.Instance.PlaySFX("Win");
    }

    protected void PlayerLose()
    {
        UIManagerMainScene.Instance.ShowLose(status.Score / 14,status.Score);
        stopCount = true;
        GameManager.Instance.UpdateData();
        AudioManager.Instance.PlaySFX("Lose");
    }

    public void CountDown()
    {
        timeLeft -= Time.deltaTime;

        if (status.Score == 42)
        {
            PlayerWin();
        }
        else if (timeLeft < 0)
        {
            PlayerLose();
        }
        else
        {
            float minutes = Mathf.FloorToInt(timeLeft / 60);
            float seconds = Mathf.FloorToInt(timeLeft % 60);

            UIManagerMainScene.Instance.SetTiming(string.Format("{0:00}:{1:00}", minutes, seconds));
        }
    }    

    private void Update()
    {
        uI.SetScore(status.Score.ToString());
        if (!stopCount)
        {
            CountDown();
        }
    }

}
