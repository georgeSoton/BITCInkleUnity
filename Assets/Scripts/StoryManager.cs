using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
public class StoryManager : MonoBehaviour
{
    [SerializeField]
    TextAsset StoryJson;
    public Story story;
    public StoryManager()
    {
        DontDestroyOnLoad(this.gameObject);
        story = new Story(StoryJson.text);
    }

    public Color linecolour
    {
        get
        {
            story.tag
        }
    }

    string ProcessTag(string input, string tagname)
    {
        if input.StartsWith(tagname + ":"){
            return input.Substring(tagname.Length).Trim()
        }
    }
}
