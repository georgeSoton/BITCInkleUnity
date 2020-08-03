using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWereA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var sm = GameObject.Find("StoryManager").GetComponent<StoryManager>();

        string turtletype = (string)sm.story.variablesState["turtletype"];
        if (turtletype == "") { turtletype = "ordinary"; }

        var article = "a";
        if ("aeiou".Contains(turtletype[0].ToString())) { article = "an";}

        GetComponent<Text>().text = string.Format("Thank you for playing our game.\n You were {0} {1} turtle.", article, turtletype);
    }
}
