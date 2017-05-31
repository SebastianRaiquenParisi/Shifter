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

    public GameObject bulletPrefab;
    public float fireDelay = 1.1f;
    float cooldownTimer = 0;
    int bulletLayer;
    float tiempoAntesDelDisparo;
    bool disparo = false;

    void Start()
    {
        bulletLayer = gameObject.layer;

        sprintBar = GameObject.Find("SprintBar").transform.GetComponent<Image>();
        startingRunDuration = runDuration;
        startingCooldownRun = cooldownRun + runDuration;
        startingSpeed = maxSpeed;
        cooldownRun = 0;
    }

    void Update() {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            //seteas el timer
            tiempoAntesDelDisparo = 0.06f;
            disparo = true;
        }
        if (disparo && tiempoAntesDelDisparo <= 0 && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * new Vector3(0, 1.3f, 0);
            GameObject bulletGO = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
            disparo = false;
        }
        else
        {
            tiempoAntesDelDisparo -= Time.deltaTime;
        }

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
        if (!disparo) {
            Vector3 pos = transform.position;
            pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
            pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
            if (Time.timeScale != 0)
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
            if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
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
    }
    void Rotate(int number)
    {
        Quaternion theRotation = transform.rotation;
        float z = number;
        theRotation = Quaternion.Euler(0, 0, z);
        transform.rotation = theRotation;
    }
}
