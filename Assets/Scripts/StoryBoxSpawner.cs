using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoxSpawner : MonoBehaviour
{
    StoryManager storymanager;

    [SerializeField]
    GameObject StoryLinePrefab;
    [SerializeField]
    GameObject ChoicePrefab;
    [SerializeField]
    GameObject DividerPrefab;

    bool NewBlock = false;

    List<GameObject> storylines = new List<GameObject>();
    void Awake()
    {
        storymanager = FindObjectOfType<StoryManager>();
        storymanager.onNewStoryLineAdded += AddStory;
        storymanager.onNewChoicesAvailable += AddChoices;
    }

    void AddStory(object sender, StoryManager.line line)
    {
        if (NewBlock)
        {    
            foreach (var sline in storylines)
            {
                Destroy(sline.GetComponent<FadeInText>());
                var txt = sline.GetComponent<Text>();
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0.3f);
            }
        }
        NewBlock = false;
        if (line.text.Trim().Length == 0) { return; }
        var newline = Instantiate(StoryLinePrefab, GetComponent<Transform>());
        var stryline = newline.GetComponent<IStoryLine>();
        stryline.SetContent(line);
        storylines.Add(newline);

        if (storylines.Count > 15)
        {
            var rt = (RectTransform)transform;
            var height = ((RectTransform)storylines[0].transform).rect.height;
            rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y - height, rt.localPosition.z);
            Destroy(storylines[0]);
            storylines.RemoveAt(0);
        }
    }

    void AddChoices(object sender, List<Choice> choices)
    {
        NewBlock = true;
        foreach (var ch in choices)
        {
            var newline = Instantiate(ChoicePrefab, GetComponent<Transform>());
            newline.GetComponent<IChoiceLine>().SetContent(ch);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        storymanager.onNewStoryLineAdded -= AddStory;
        storymanager.onNewChoicesAvailable -= AddChoices;
    }
}
