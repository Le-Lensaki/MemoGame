
using System.Collections;
using UnityEngine;

public class ResultsController : MonoBehaviour
{
    protected static ResultsController instance;
    public static ResultsController Instance { get { return instance; } }

    protected ResultsStatus status;
    public ResultsStatus Status { get { return status; } }

    protected ResultsUI uI;
    public ResultsUI UI { get { return uI; } }

    private void Awake()
    {
        ResultsController.instance = this;
        this.status = GetComponent<ResultsStatus>();
        this.uI = GetComponent<ResultsUI>();
    }

    public void CreateResult()
    {
        status.CreateResults();
        uI.ResetItemUI();
        uI.SetItem(status.Results);
    }

    IEnumerator CoroutineShowItem()
    {
        yield return new WaitForSeconds(3);
    }

    public void SearchItem()
    {
        GameObject item1 = uI.GetItemEnableFirst();
        int valueItem = item1.GetComponent<ItemController>().GetValueItem();
        int positionItem = item1.GetComponent<ItemController>().GetPositionItem();
        GameObject item2;
        for (int i = 0; i < status.Size; i++)
        {
            if (i == positionItem) continue;

            if (status.Results[i] == valueItem)
            {
                item2 = uI.GetItemAt(i);
                item1.GetComponent<ItemController>().HoverItem();
                item2.GetComponent<ItemController>().HoverItem();
                break;
            }
        } 
    }
    

    public bool CheckHoverItem()
    {
        return uI.GetItemEnableFirst().GetComponent<ItemController>().CheckHoverItem();
    }    
}
