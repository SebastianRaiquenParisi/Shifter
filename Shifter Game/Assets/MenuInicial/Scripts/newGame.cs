using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class newGame : MonoBehaviour {

	// Use this for initialization
	public void LoadScene (int level) {
        SceneManager.LoadScene(level);
    }
	
}
