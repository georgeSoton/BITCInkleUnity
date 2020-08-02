using System;
using System.Collections;
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
    [SerializeField]
    List<ColourPairing> ActorColours;

    [Serializable]
    public class ColourPairing
    {
        public string tag;
        public Color colour = Color.white;
    }
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
        if (line.tags.Contains("italic"))
        {
            if (line.tags.Contains("bold"))
            { 
                mytext.fontStyle = FontStyle.BoldAndItalic;
            } else
            {
                mytext.fontStyle = FontStyle.Italic;
            }
        } else if (line.tags.Contains("bold"))
        {
            mytext.fontStyle = FontStyle.Bold;
        }

        var found = ActorColours.Find(x => line.tags.Contains(x.tag));
        if (found != null)
        {
            mytext.color = found.colour;
        }
    }

    public void AddContent(StoryManager.line line)
    {

    }

}
