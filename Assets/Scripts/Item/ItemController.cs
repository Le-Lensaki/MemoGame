
using UnityEngine;

public class ItemController : MonoBehaviour
{
    protected static ItemController instance;
    public static ItemController Instance { get { return instance; } }

    protected ItemStatus status;
    public ItemStatus Status { get { return status; } }

    protected ItemUI uI;
    public ItemUI UI { get { return uI; } }


    private void Awake()
    {
        ItemController.instance = this;
        this.status = GetComponent<ItemStatus>();
        this.uI = GetComponent<ItemUI>();
    }

    public void SetUIItem(Sprite icon,int position,int item)
    {
        UI.CreateUIItem(icon);
        status.SetPositionItem(position);
        status.SetItem(item);
    }

    public void Chose()
    {
        if(status.StatusItem)
        {
            AudioManager.Instance.PlaySFX("Click");
            if (status.IsOpen)
            {
                Close();
                PlayerController.Instance.RemoveItemOpen(this.gameObject);

            }
            else
            {
                OnlyShowItem();
                status.ChangeIsOpen();
                PlayerController.Instance.AddItemOpen(this.gameObject);

            }
        }    
        
        
    }

    public void OnlyShowItem()
    {
        uI.ShowItem();
    }
    
    public void OnlyHideItem()
    {
        uI.HideItem();
    }    

    public void Close()
    {
        OnlyHideItem();
        status.ChangeIsOpen();
    }

    public void DisableObject()
    {
        uI.HideObject();
        status.DisableItem();
    }

    public void EnableObject()
    {
        uI.ShowObject();
        status.EnableItem();
    }    
    
    public bool GetStatusItem()
    {
        return status.StatusItem;
    }

    public int GetValueItem()
    {
        return status.Item; 
    }
    public int GetPositionItem()
    {
        return status.PositionItem;
    }

    public void HoverItem()
    {
        uI.HoverItem();
    }
    
    public bool CheckHoverItem()
    {
        return uI.CheckHoverItem();
    }    
}
