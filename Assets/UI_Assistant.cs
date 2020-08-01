using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistant : MonoBehaviour
{
    private Text messageText;
    [SerializeField] private TextWriter textWriter;
    // Start is called before the first frame update
    void Awake()
    {
        messageText = GetComponent<Text>();

    }


    // Update is called once per frame
    void Start()
    {
        //textWriter.AddWriter(messageText, messageText.text, 0.01f);
    }
}
