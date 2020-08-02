using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class TransitionHandler : MonoBehaviour
{
    public Animator transitionAnimator; 

    public enum Scene
    {
        TransitionTestStart,
        TransitionTestTarget,
    }


    void Start()
    {
        FadeIn();
        Invoke("Test", 2f);
        
    }

    private void Test()
    {
        StartCoroutine(this.LoadScene(Scene.TransitionTestTarget));
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
