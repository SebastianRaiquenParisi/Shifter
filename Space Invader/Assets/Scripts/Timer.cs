using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerText;
    int topMinutes = 1;
    int topSeconds = 0;
    private float startTime;
    private bool finished;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (finished)
        {
            return;
        }
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        timerText.text = minutes + ":" + seconds;
        if (topMinutes <=  (int)t/60 && topSeconds <= t%60)
        {
            Finish();
        }
    }
    void Finish()
    {
        finished = true;
        timerText.color = Color.blue;
    }
}
