using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Exit : MonoBehaviour {

    public GameObject messageBox;
    public void message() {
        messageBox.SetActive(true);
    }
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        messageBox.SetActive(false);
    }
}
