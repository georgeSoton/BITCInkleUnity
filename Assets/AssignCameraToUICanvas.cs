﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCameraToUICanvas : MonoBehaviour
{
    private Canvas uiCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.Find("UICanvas").GetComponent<Canvas>().worldCamera = GetComponent<Camera>();
    }
}