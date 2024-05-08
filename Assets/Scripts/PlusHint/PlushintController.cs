using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushintController : MonoBehaviour
{
    protected static PlushintController instance;
    public static PlushintController Instance { get { return instance; } }

    protected PlushintUI uI;
    public PlushintUI UI { get { return uI; } }

    private void Awake()
    {
        PlushintController.instance = this;
        this.uI = GetComponent<PlushintUI>();
    }

    public void Plushint()
    {
        PlayerController.Instance.Plushint();
        UIManagerMainScene.Instance.HideUI();
    }
}
