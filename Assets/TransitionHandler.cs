using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionDelaySeconds;

    StoryManager storymanager;
    public bool isLoading;

    //public enum Scene
    //{
    //    TransitionTestStart,
    //    TransitionTestTarget,
    //}

    //public Dictionary<string, Scene> sceneNameToEnum = new Dictionary<string, Scene>()
    //{
    //    {"PrologueStart", Scene.TransitionTestStart},
    //    {"PrologueNet", Scene.TransitionTestTarget},
    //};

    
    private void Awake()
    {
        isLoading = false;
        //storymanager = FindObjectOfType<StoryManager>();
        //storymanager.onNewStoryLineAdded += SceneTransition;
    }
    /*
    void SceneTransition(object sender, StoryManager.line line)
    {
        var targetScene = line.GetTagValue("scene");
        if(targetScene!= null)
        {
            Debug.Log(targetScene);
            StartCoroutine(this.LoadScene(sceneNameToEnum[targetScene]));
        }
        
    }
    */
    public void FadeIn()
    {
        transitionAnimator.SetBool("FadeToBlack", false);
    }

    public void FadeOut()
    {
        transitionAnimator.SetBool("FadeToBlack", true);
    }

    public IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(transitionDelaySeconds);
        FadeOut();
        yield return new WaitUntil(() => transitionAnimator.GetBool("Faded") == true);
        Debug.Log(string.Format("Loading Scene {0}", scene));
        SceneManager.LoadScene(scene);
        FadeIn();
        isLoading = false;
    }

}
