using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Runtime.InteropServices;
using System;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    TextAsset StoryJson;
    public Story story;
    private TransitionHandler transitionHandler;

    public class line
    {
        public string text;
        public List<string> tags;
        
        public string GetTagValue(string tagname)
        {
            var found = tags.Find(x => x.StartsWith(tagname));
            if (found == null) { return null; } else
            {
                return found.Substring(tagname.Length + 1).Trim();
            }
        }
    }

    public List<line> LinesSoFar = new List<line>(); 

    public void Awake()
    {
        transitionHandler = GetComponent<TransitionHandler>();
        story = new Story(StoryJson.text);
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator AdvanceStory()
    {
        while (story.canContinue)
        {
            var text = story.Continue();
            var nextline = new line { text = text, tags = story.currentTags };
            if ((nextline.text.Length==0) && (nextline.tags.Count==0)) { continue; }
            var targetScene = nextline.GetTagValue("scene");
            if (targetScene != null)
            {
                Debug.Log(targetScene);
                transitionHandler.isLoading = true;
                var spawner = GameObject.Find("Character Spawner").GetComponentInChildren<CharacterSpawner>();
                spawner.RightRemove();
                spawner.LeftRemove();
                StartCoroutine(transitionHandler.LoadScene(targetScene));
                yield return new WaitUntil(() => transitionHandler.isLoading == false);
            }

            onNewStoryLineAdded.Invoke(this, nextline);
            LinesSoFar.Add(nextline);
        }
        if (story.currentChoices.Count > 0)
        {
            onNewChoicesAvailable.Invoke(this, story.currentChoices);
        }
        else
        {
            transitionHandler.isLoading = true;
            var spawner = GameObject.Find("Character Spawner").GetComponentInChildren<CharacterSpawner>();
            spawner.RightRemove();
            spawner.LeftRemove();
            StartCoroutine(transitionHandler.LoadScene("EndOfGame"));
            yield return new WaitUntil(() => transitionHandler.isLoading == false);
        }
    }

    public void ProceedWithChoice(int idx)
    {
        onChoiceMade.Invoke(this, story.currentChoices[idx]);
        story.ChooseChoiceIndex(idx);
        StartCoroutine("AdvanceStory");
    }
    public delegate void NewStoryLineAddedEventHandler(object sender, line l);
    public event NewStoryLineAddedEventHandler onNewStoryLineAdded;

    public delegate void NewChoicesAvailableEventHandler(object sender, List<Choice> choices);
    public event NewChoicesAvailableEventHandler onNewChoicesAvailable;

    public delegate void ChoiceMadeEventHandler(object sender,  Choice choice);
    public event ChoiceMadeEventHandler onChoiceMade;
}
