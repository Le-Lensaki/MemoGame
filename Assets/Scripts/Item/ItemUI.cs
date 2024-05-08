
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    protected static ItemController controller;
    [SerializeField] protected Sprite itemShow;
    [SerializeField] protected Sprite itemHide;

    private void Awake()
    {
        controller = GetComponent<ItemController>();   
    }
    
    public void CreateUIItem(Sprite icon)
    {
        this.transform.GetChild(0).GetComponent<Image>().sprite = icon;
        HideItem();
    }


    public void ShowItem()
    {
        this.transform.GetComponent<Image>().sprite = itemShow;
        this.transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1);
        
    }

    public void HideItem()
    {
        this.transform.GetComponent<Image>().sprite = itemHide;
        this.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    public void HideObject()
    {
        this.transform.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        HideItem();
        this.transform.GetComponent<Button>().enabled = false;
    }

    public void ShowObject()
    {
        this.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        this.transform.GetComponent<Image>().sprite = itemHide;
        this.transform.GetComponent<Button>().enabled = true;
        this.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }    

    public void HoverItem()
    {
        this.transform.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
    }

    public bool CheckHoverItem()
    {
        if(this.transform.GetComponent<Image>().color != new Color(1,1,1,1))
        {
            return true;
        }
        return false;
    }    
}
