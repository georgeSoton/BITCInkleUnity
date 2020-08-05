using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if ("aeiou".Contains(turtletype[0].ToString().ToLower())) { article = "an";}

        string endtext;
        if (turtletype == "lonely")
        {
            endtext = "Thank you for playing our game. \n\n You were a lonely turtle. \n\n If you could only try again, perhaps you could save the other captives...";
        }
        else
        {
            string[] flags = { "convinced_goby", "convinced_mantis", "convinced_young_fish", "convinced_old_fish" };
            if (flags.All(x=> (int)sm.story.variablesState[x]==1))
            {
                endtext = string.Format("Thank you for playing our game.\n\n You were {0} {1} turtle. \n\n You saved everyone you could. Well done!", article, turtletype);
            } else
            {
                endtext = string.Format("Thank you for playing our game.\n\n You were {0} {1} turtle. \n\n You rescued other captives, but could you have convinced more if you had another chance?", article, turtletype);
            }
        }
        GetComponent<Text>().text = endtext;
    }
}
