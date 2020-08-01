using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Threading;

public class InkExample : MonoBehaviour
{
    public TextAsset inkJSONAsset;
    public const float buttonSpacing = 0.3f;
    [SerializeField] private Text displayText;
    private TextWriter textWriter;
    private Story story;
    private List<Button> buttonList;

    public Button buttonPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        // Load the next story block
        story = new Story(inkJSONAsset.text);
        textWriter = GetComponent<TextWriter>();
        buttonList = new List<Button>();
        // Start the refresh cycle
        refresh();

    }

    // Refresh the UI elements
    //  - Clear any current elements
    //  - Show any text chunks
    //  - Iterate through any choices and create listeners on them
    void refresh()
    {
        //Debug.Log(string.Format("Before {0}",buttonList.Count));
        // Clear the previous choises
        for (int j = buttonList.Count-1; j>-1; j--){
            Debug.Log(j);
            buttonList[j].onClick.RemoveAllListeners();
            Destroy(buttonList[j].gameObject);
            buttonList.RemoveAt(j);
        }
        //Debug.Log(buttonList.Count);
        
        
        //clearUI();

        // Set the text from new story block
        textWriter.AddWriter(displayText, getNextStoryBlock());

        int i = 0;
        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            buttonList.Add(choiceButton);
            choiceButton.transform.SetParent(this.transform, false);

            //offset buttons below each other 
            choiceButton.transform.position += new Vector3(0f,buttonSpacing*i);

            // Gets the text from the button prefab
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            // Set listener
            choiceButton.onClick.AddListener(delegate {
                OnClickChoiceButton(choice);
            });
            
            i++;
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }

    // Clear out all of the UI, calling Destory() in reverse
    void clearUI()
    {
        int childCount = this.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        }
    }


    // Load and potentially return the next story block
    string getNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }

        return text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}