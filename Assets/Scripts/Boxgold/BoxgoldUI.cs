using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxgoldUI : MonoBehaviour
{
    protected static BoxgoldController controller;

    private void Awake()
    {
        controller = GetComponent<BoxgoldController>();
    }

    public void PlusHintUI()
    {
        UIManagerMainScene.Instance.PlusHint();
    }    

}
