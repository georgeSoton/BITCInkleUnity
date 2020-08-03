using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    StoryManager storymanager;

    [SerializeField]
    GameObject LeftBase;
    [SerializeField]
    GameObject RightBase;

    GameObject LeftCharacter;
    string leftName;
    GameObject RightCharacter;
    string rightName;
    // Start is called before the first frame update
    private void Awake()
    {
        storymanager = FindObjectOfType<StoryManager>();
        storymanager.onNewStoryLineAdded += SpawnCharacters;
    }
    
    void SpawnCharacters(object sender, StoryManager.line line)
    {
        var right = line.GetTagValue("right");
        var left = line.GetTagValue("left");
        
        if (right != null)
        {
            if ((rightName == null) || (rightName != right.ToLower()))
            {
                RightRemove();
                GameObject prefab = (GameObject)Resources.Load(string.Format("Characters/{0}", right));
                if (prefab != null) { RightSpawn(prefab); }
                rightName = right.ToLower();
            }
        }
        if (left != null)
        {
            if ((leftName == null) || (leftName != left.ToLower()))
            {
                LeftRemove();
                GameObject prefab = (GameObject)Resources.Load(string.Format("Characters/{0}", left));
                if (prefab != null) { LeftSpawn(prefab); }
                leftName = left.ToLower();
            }
        }
    }

    public void RightRemove()
    {
        rightName = null;
        if (RightCharacter != null) { RightCharacter.GetComponentInChildren<IExitCharacter>()?.Exit(); RightCharacter = null; }
    }
    public void LeftRemove()
    {
        leftName = null;
        if (LeftCharacter != null) { LeftCharacter.GetComponentInChildren<IExitCharacter>()?.Exit(); LeftCharacter = null; }
    }
    void RightSpawn(GameObject prefab)
    { 
        RightCharacter = GameObject.Instantiate(prefab, RightBase.transform);
        var crntScale = RightCharacter.transform.localScale;
        RightCharacter.transform.localScale = new Vector3(-crntScale.x, crntScale.y, crntScale.z);
    }

    void LeftSpawn(GameObject prefab)
    {
        LeftCharacter = GameObject.Instantiate(prefab, LeftBase.transform);
    }
    private void OnDestroy()
    {
        storymanager.onNewStoryLineAdded -= SpawnCharacters;
    }
}

