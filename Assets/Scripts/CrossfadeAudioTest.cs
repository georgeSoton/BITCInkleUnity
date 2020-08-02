using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfadeAudioTest : MonoBehaviour
{
    [SerializeField]
    AudioSource StartingTrack;
    [SerializeField]
    AudioSource CrossFadeTrack;

    [SerializeField]
    float transitionSpeed = 1;
    float normFactor;

    string nowplaying;

    AudioSource currentTrack;
    AudioSource otherTrack;

    StoryManager storymanager;

    // Start is called before the first frame update
    private void Awake()
    {
        storymanager = FindObjectOfType<StoryManager>();
        storymanager.onNewStoryLineAdded += StoryLineAdded;
        normFactor = (1f / (1 + transitionSpeed * 0.01f));
    }
    
    void Start()
    {
        currentTrack = StartingTrack;
        otherTrack = CrossFadeTrack;
    }
    void StoryLineAdded(object sender, StoryManager.line line)
    {
        var trackname = line.GetTagValue("track");
        if ((trackname != null) && (trackname != nowplaying))
        {
            AudioClip trackfile = (AudioClip)Resources.Load(string.Format("Tracks/{0}", trackname));
            
            otherTrack.clip = trackfile;
            otherTrack.time = currentTrack.time;
            otherTrack.volume = 0;
            otherTrack.Play();

            var placeholder = otherTrack;
            otherTrack = currentTrack;
            currentTrack = placeholder;
        }
    }

    private void FixedUpdate()
    {
        currentTrack.volume = 1 - ((1 - currentTrack.volume) * normFactor);
        otherTrack.volume = otherTrack.volume * normFactor;
    }
}
