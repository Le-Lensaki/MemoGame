
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    protected static ItemController controller;
    protected bool isOpen;
    public bool IsOpen { get { return isOpen; } }

    protected int positionItem;
    public int PositionItem { get { return positionItem; } }
    protected int item;
    public int Item { get { return item; } }

    protected bool statusItem;

    public bool StatusItem { get { return statusItem; } }

    private void Awake()
    {
        controller = GetComponent<ItemController>();
        isOpen = false;
        statusItem = true;
    }

    public void ChangeIsOpen()
    {
        isOpen = !IsOpen;
    }
    public void DisableItem()
    {
        statusItem = false;
    }

    public void EnableItem()
    {
        isOpen = false;
        statusItem = true;
    }

    public void SetPositionItem(int position)
    {
        positionItem = position;
    }

    public void SetItem(int item)
    {
        this.item = item;
    }
}
