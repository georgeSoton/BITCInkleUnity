using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToScene : MonoBehaviour
{
    [SerializeField]
    string TgtScene;
    // Start is called before the first frame update
    void Start()
    {
        var sm = GameObject.FindObjectOfType<StoryManager>();
        sm.story.ChoosePathString(TgtScene);
        sm.StartCoroutine("AdvanceStory");
    }
}
