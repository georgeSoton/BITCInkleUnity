using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class StoryLine : MonoBehaviour, IStoryLine
{
    // Start is called before the first frame update
    Text mytext;
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
    public void SetContent(StoryManager.line line)
    {
        mytext.text = "";
        if (line.text.Trim().Length == 0) { Destroy(gameObject); }
        AddContent(line);
    }

    public void AddContent(StoryManager.line line)
    {
        var texttoadd = line.text.Trim();
        if (line.tags.Contains("italic"))
        {
            texttoadd = ItalicTag(texttoadd);
        }
        else if (line.tags.Contains("bold"))
        {
            texttoadd = BoldTag(texttoadd);
        }

        var found = ActorColours.Find(x => line.tags.Contains(x.tag));
        if (found != null)
        {
            mytext.color = found.colour;
        }
        mytext.text = mytext.text + " " + texttoadd;
    }

    string BoldTag(string inp)
    {
        return "<b>" + inp + "</b>";
    }
    string ItalicTag(string inp)
    {
        return "<i>" + inp + "</i>";
    }

}
