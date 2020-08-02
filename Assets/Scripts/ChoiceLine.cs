using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceLine : MonoBehaviour, IChoiceLine
{
    StoryManager storymanager;
    Text mytext;

    [SerializeField]
    Color IdleColour = Color.blue;
    [SerializeField]
    Color HoverColour = Color.magenta;

    int myindex;
    private void Awake()
    {
        storymanager = FindObjectOfType<StoryManager>();
        mytext = GetComponent<Text>();
        storymanager.onChoiceMade += ChoiceMade;
    }

    private void Start()
    {
        mytext.color = new Color(IdleColour.r, IdleColour.g, IdleColour.b, 0);

    }

    public void SetContent(Ink.Runtime.Choice choice)
    {
        myindex = choice.index;
        mytext.text = choice.text;
    }

    private void Update()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
    }

    private void OnMouseEnter()
    {
        var oldalpha = mytext.color.a;
        mytext.color = new Color(HoverColour.r, HoverColour.g, HoverColour.b, oldalpha);
    }
    private void OnMouseExit()
    {
        var oldalpha = mytext.color.a;
        mytext.color = new Color(IdleColour.r, IdleColour.g, IdleColour.b, oldalpha);
    }

    private void OnMouseDown()
    {
        storymanager.ProceedWithChoice(myindex);
    }

    void ChoiceMade(object sender, Ink.Runtime.Choice choice)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        storymanager.onChoiceMade -= ChoiceMade;
    }
}
