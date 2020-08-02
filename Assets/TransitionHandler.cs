using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class TransitionHandler : MonoBehaviour
{
    public Animator transitionAnimator;

    StoryManager storymanager;

    public enum Scene
    {
        TransitionTestStart,
        TransitionTestTarget,
    }

    public Dictionary<string, Scene> sceneNameToEnum = new Dictionary<string, Scene>()
    {
        {"PrologueStart", Scene.TransitionTestStart},
        {"PrologueNet", Scene.TransitionTestTarget},
    };

    private void Awake()
    {
        storymanager = FindObjectOfType<StoryManager>();
        storymanager.onNewStoryLineAdded += SceneTransition;
    }

    void SceneTransition(object sender, StoryManager.line line)
    {
        var targetScene = line.GetTagValue("scene");
        if(targetScene!= null)
        {
            Debug.Log(targetScene);
            StartCoroutine(this.LoadScene(sceneNameToEnum[targetScene]));
        }
        
    }

    public void FadeIn()
    {
        transitionAnimator.SetBool("FadeToBlack", false);
    }

    public void FadeOut()
    {
        transitionAnimator.SetBool("FadeToBlack", true);
    }

    public IEnumerator LoadScene(Scene scene)
    {
        FadeOut();
        yield return new WaitUntil(() => transitionAnimator.GetBool("Faded") == true);
        Debug.Log(string.Format("Loading Scene {0}", scene));
        SceneManager.LoadScene(scene.ToString());
        FadeIn();
    }

}
