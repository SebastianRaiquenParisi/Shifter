using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text textUI;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;
    //Tenes que poner un bool en el player movement script,
    //en update: if(!canMove){ return; }

    //public Player player, para inhabilitar el movimiento y esa gilada;

    
	void Start () {
        // Buscas el player;
		if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if(endAtLine == 0)
        {
            endAtLine = textLines.Length-1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
	}
	
	void Update () {
        if (!isActive)
        {
            return;
        }
        //textUI.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                currentLine++;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
       
	}

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        textUI.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length-1))
        {
            textUI.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        textUI.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if (stopPlayerMovement)
        {
            //player.canMove = false;
        }
        StartCoroutine(TextScroll(textLines[currentLine]));
    }
    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        //player.canMove = true;
    }

    public void ReloadScript(TextAsset textAsset)
    {
        if(textAsset != null)
        {
            textLines = new string[1];
            textLines = (textAsset.text.Split('\n'));
        }
    }
}
