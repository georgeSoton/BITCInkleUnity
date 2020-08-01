using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Runtime.InteropServices;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    TextAsset StoryJson;
    public Story story;
    [SerializeField]
    Color DefaultLineColor = Color.white;
    public StoryManager()
    {
        DontDestroyOnLoad(this.gameObject);
        story = new Story(StoryJson.text);
    }
    /// <summary>
    /// Return the contents of a tag from the current ink where the tag is written in the form:
    /// <para>
    /// #tagname: tag contents
    /// </para>
    /// <para>
    /// Case insensitive.
    /// </para>
    /// If the tag is not present on this line, <see langword="null"/> will be returned.
    /// </summary>
    /// <param name="tagname"></param>
    /// <returns></returns>
    public string GetTag(string tagname)
    {
        var tags = story.currentTags;
        var found = tags.Find(x => x.ToLower().StartsWith(tagname.ToLower()));
        if (found == null)
        {
            return null;
        }
        else
        {
            return found.Substring(tagname.Length + 1).Trim();
        }
    }
}
