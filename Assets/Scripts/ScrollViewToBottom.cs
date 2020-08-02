using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollViewToBottom : MonoBehaviour
{
    StoryManager storymanager;
    [SerializeField]
    ScrollRect myScroller;
    [SerializeField]
    float speed = 0.1f;
    bool userInterrupted = false;
    private void Awake()
    {
        storymanager = FindObjectOfType<StoryManager>();
        storymanager.onNewStoryLineAdded += NewLine;
        storymanager.onNewChoicesAvailable += NewLine;
    }

    void NewLine(object sender, object arg)
    {
        userInterrupted = false;
    }

    public void UserInterrupt()
    {
        userInterrupted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!userInterrupted)
        {
            var vpos = myScroller.verticalNormalizedPosition;
            if (vpos < 0.01) { vpos = -0.05f; }
            else
            {
                myScroller.verticalNormalizedPosition = ((vpos+0.05f) * (1f - speed)) -0.05f;
            }
        }
    }
}
