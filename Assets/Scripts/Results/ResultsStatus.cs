
using System.Collections.Generic;
using UnityEngine;

public class ResultsStatus : MonoBehaviour
{
    protected static ResultsController controller;


    [SerializeField] protected List<int> results;

    public List<int> Results { get { return results; } }

    protected int size;
    public int Size { get { return size; } }

    protected List<int> itemCurrent;

    private void Awake()
    {
        controller = GetComponent<ResultsController>();
        size = 84;
        InitializeResults();
    }

    protected void InitializeResults()
    {
        results = new List<int>();
        
        for (int i = 0; i < Size; i++)
        {
            results.Add(-1);
        }
        
    }

    protected void InitializeItemCurrent()
    {
        itemCurrent = new List<int>();
        for (int i = 0; i < Size/2; i++)
        {
            itemCurrent.Add(i);
        }
    }

    public void CreateResults()
    {
        InitializeItemCurrent();
        for (int i = 0; i < Size/2; i++)
        {
            results[i] = RandomResults();
        }
        InitializeItemCurrent();
        for (int i = Size/2; i < Size; i++)
        {
            results[i] = RandomResults();
        }
    }

    protected int RandomResults()
    {
        int item = itemCurrent[Random.Range(0, itemCurrent.Count)];
        itemCurrent.Remove(item);

        return item;
    }


}
