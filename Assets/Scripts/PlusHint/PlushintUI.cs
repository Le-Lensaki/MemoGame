using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushintUI : MonoBehaviour
{
    protected static PlushintController controller;

    private void Awake()
    {
        controller = GetComponent<PlushintController>();
    }
}
