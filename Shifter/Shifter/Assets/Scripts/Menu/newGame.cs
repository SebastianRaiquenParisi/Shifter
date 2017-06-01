using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class newGame : MonoBehaviour {

	// Use this for initialization
	public void Start (int level) {
        SceneManager.LoadScene(level);
    }
	
}
