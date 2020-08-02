using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{

    public Animator transitionAnimator; 
    // Start is called before the first frame update
    void Start()
    {

        Invoke("FadeOut", 2f);
        Invoke("FadeIn", 4f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        transitionAnimator.SetBool("FadeToBlack", false);
    }

    public void FadeOut()
    {
        transitionAnimator.SetBool("FadeToBlack", true);
    }
}
