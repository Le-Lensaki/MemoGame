
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    protected static PlayerController controller;

    [SerializeField] protected int score;
    public int Score { get { return score; } }

    [SerializeField] protected int hint;
    public int Hint { get { return hint; } }

    [SerializeField] protected int hint2;
    public int Hint2 { get { return hint2; } }

    protected List<GameObject> itemOpen;
    public List<GameObject> ItemOpen { get { return itemOpen; } }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        score = 0;
        hint = 10;
        hint2 = 20;
        itemOpen = new List<GameObject>();
    }

    public void AddItemOpen(GameObject item)
    {
        if (itemOpen.Contains(item))
        {
            return;
        }
        itemOpen.Add(item);
    }

    public void RemoveItemOpen(GameObject item)
    {
        if(itemOpen.Contains(item))
        {
            itemOpen.Remove(item);
        }
    }

    public void ClearItemOpen()
    {
        itemOpen.Clear();
    }

    public void PlusScore()
    {
        score++;
    }
    public void ClearScore()
    {
        score = 0;
    }

    public bool UpdateHint()
    {
        if (hint > 0)
        {
            hint--;
            return true;
        }
        if(hint2 == 20 && hint == 0)
        {
            
            UIManagerMainScene.Instance.OpenBoxgold();
            AudioManager.Instance.PlaySFX("OpenBoxGold");
            return false;
        } else if (hint2 == 10 && hint == 0)
        {

            UIManagerMainScene.Instance.OpenBoxgold();
            AudioManager.Instance.PlaySFX("OpenBoxGold");
            return false;
        }
        return false;
    }

    public void UpdateHint2()
    {
        hint = 10;
        hint2 -= 10;
    }


    public void ClearHint()
    {
        hint = 10;
    }

    public void ClearHint2()
    {
        hint2 = 20;
    }
}
