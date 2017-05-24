using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject uI;
    public Text timerText;
    public int publicTopMinutes = 1;
    public int publicTopSeconds = 30;
    public GameObject gameOver;
    int topMinutes;
    int topSeconds;
    private float startTime;
    private bool finished;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        topSeconds = publicTopSeconds;
        topMinutes = publicTopMinutes;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.activeSelf)
        {
            return;
        }
        float t = Time.time - startTime;
        timerText.text = ((int)t / 60).ToString() + ":" + (t % 60).ToString("f0");
        if (topMinutes <= (int)t / 60 && topSeconds-10 <= (t % 60))
        {
            timerText.color = Color.yellow;
        }
        if (topMinutes <= (int)t / 60 && topSeconds <= t % 60)
        {
            Finish();
        }
    }
    void Finish()
    {
        uI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
