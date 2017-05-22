using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float maxSpeed = 15f;
    public float cooldownRun = 5f;
    public float maxSpeedRun = 20f;
    public float runDuration = 6f;
    Image sprintBar;
    float shipBoundaryRadius = 1.2f;
    float startingCooldownRun;
    float startingSpeed;
    float startingRunDuration;

    void Start()
    {
        sprintBar = GameObject.Find("SprintBar").transform.GetComponent<Image>();
        startingRunDuration = runDuration;
        startingCooldownRun = cooldownRun + runDuration;
        startingSpeed = maxSpeed;
        cooldownRun = 0;
    }

    void Update() {


        if (cooldownRun <= 0 && Input.GetButtonDown("Fire2"))
        {
            maxSpeed = maxSpeedRun;
            cooldownRun = startingCooldownRun;
            runDuration = startingRunDuration;
        }
        runDuration -= Time.deltaTime;
        if(cooldownRun > 0 && runDuration <= 0)
        {
            maxSpeed = startingSpeed;
            cooldownRun -= Time.deltaTime;
        }
        sprintBar.fillAmount = cooldownRun / startingCooldownRun;
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        if(Time.timeScale != 0)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Rotate(90);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Rotate(270);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                Rotate(180);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                Rotate(0);
            }
        }
        if (pos.y+shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }
        transform.position = pos;
    }
    void Rotate(int number)
    {
        Quaternion theRotation = transform.rotation;
        float z = number;
        theRotation = Quaternion.Euler(0, 0, z);
        transform.rotation = theRotation;
    }
}
