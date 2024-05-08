
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsUI : MonoBehaviour
{
    protected static ResultsController controller;

    [SerializeField] protected List<Sprite> iconItem;
    [SerializeField] protected List<GameObject> item;

    private void Awake()
    {
        controller = GetComponent<ResultsController>();
        GetItem();
    }


    protected void GetItem()
    {
        item = new List<GameObject>();
        for (int i = 0; i < 84; i++)
        {
            item.Add(GameObject.Find("Item ("+i+")"));
        }
    }

    public GameObject GetItemEnableFirst()
    {
        for (int i = 0; i < item.Count; i++)
        {
            if(item[i].GetComponent<ItemController>().GetStatusItem())
            {
                return item[i];
            };
        }
        return null;
    }



    public void PauseGame()
    {
        if(Time.timeScale == 0)
        {
            StopChosse();
        }
        else
        {
            Chosse();
        }
        
    }

    public void StopChosse()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].GetComponent<Button>().enabled = false;
        }
    }

    public void Chosse()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].GetComponent<Button>().enabled = true;
        }
    }

    public void SetItem(List<int> results)
    {
        for (int i = 0; i < controller.Status.Size; i++)
        {
            item[i].GetComponent<ItemController>().SetUIItem(iconItem[results[i]],i,results[i]);
        }
    }
    
    public GameObject GetItemAt(int index)
    {
        return item[index];
    }    


    public void ResetItemUI()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].GetComponent<ItemController>().EnableObject();
        }
    }
    
    public void ShowFullItem()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].GetComponent<ItemController>().OnlyShowItem();
        }
    }

    public void HideFullItem()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].GetComponent<ItemController>().OnlyHideItem();
        }
    }
}
