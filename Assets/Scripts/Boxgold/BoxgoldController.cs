using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxgoldController : MonoBehaviour
{
    protected static BoxgoldController instance;
    public static BoxgoldController Instance { get { return instance; } }

    protected BoxgoldUI uI;
    public BoxgoldUI UI { get { return uI; } }

    private void Awake()
    {
        BoxgoldController.instance = this;
        this.uI = GetComponent<BoxgoldUI>();
    }

    public void PlusHint()
    {
        uI.PlusHintUI();
    }
    

}
