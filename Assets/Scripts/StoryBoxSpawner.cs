using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoxSpawner : MonoBehaviour
{
    StoryManager storymanager;
    Text mytext;

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
        mytext = GetComponent<Text>();
        storymanager.onNewStoryLineAdded += AddStory;
        storymanager.onNewChoicesAvailable += AddChoices;
    }

    void AddStory(object sender, StoryManager.line line)
    {
        if (NewBlock)
        {
            var div = Instantiate(DividerPrefab, GetComponent<Transform>());
            storylines.Add(div);
            NewBlock = false;
        }
        var newline = Instantiate(StoryLinePrefab, GetComponent<Transform>());
        var stryline = newline.GetComponent<StoryLine>();
        stryline.SetContent(line);
        storylines.Add(stryline.gameObject);
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
            newline.GetComponent<ChoiceLine>().SetContent(ch);
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
