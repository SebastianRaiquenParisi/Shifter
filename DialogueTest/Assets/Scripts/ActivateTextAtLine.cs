using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset text;

    public int startLine;
    public int endLine;

    public TextBoxManager textBox;

    public bool destroyWhenActivated;

    public bool requireButtonPressed;
    private bool waitForPressed;

	// Use this for initialization
	void Start () {
        textBox = FindObjectOfType<TextBoxManager>();

	}
	
	// Update is called once per frame
	void Update () {
		if(waitForPressed && Input.GetKeyDown(KeyCode.E))
        {
            textBox.ReloadScript(text);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.EnableTextBox();
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player") // "Player" es como se llama el pj obviamente
        {
            if (requireButtonPressed)
            {
                waitForPressed = true;
                return;
            }
            textBox.ReloadScript(text);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.EnableTextBox();
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            waitForPressed = false;
        }
    }
}
