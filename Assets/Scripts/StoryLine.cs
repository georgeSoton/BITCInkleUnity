﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLine : MonoBehaviour, IStoryLine
{
    // Start is called before the first frame update
    Text mytext;
    [SerializeField]
    Color PlayerTextColour;
    [SerializeField]
    Color OctoTextColour;
    private void Awake()
    {
        mytext = GetComponent<Text>();
    }
    void Start()
    {
    }

    public void SetContent(StoryManager.line line)
    {
        mytext.text = line.text.Trim();
        if (line.tags.Contains("player"))
        {
            mytext.color = PlayerTextColour;
        }
        if (line.tags.Contains("octopus"))
        {
            mytext.color = OctoTextColour;
        }
        if (line.tags.Contains("action"))
        {
            mytext.fontStyle = FontStyle.Italic;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}