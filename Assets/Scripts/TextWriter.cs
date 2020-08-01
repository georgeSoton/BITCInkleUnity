using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int characterIndex;
    private bool invisibleCharacters;
    
    public void AddWriter(Text uiText, string textToWrite, bool invisibleCharacters = true) {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = 0.01f;
        this.invisibleCharacters = invisibleCharacters;
        this.characterIndex = 0;
    }

    private void Update()
    {
        if (uiText != null && textToWrite != "")
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //display next character
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    //Entire string displayed
                    uiText = null;
                    return;
                }
            }
        }
    }

}
