using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptVertical : MonoBehaviour {
    public Sprite WarningSprite;
    public float tiempoDeAdvertencia = 2;
    public float tiempoDeDaño = 1.4f;
    Sprite correctSprite;

    // Use this for initialization
    void Start()
    {
        correctSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoDeAdvertencia > 0)
        {
            gameObject.layer = 10;
            gameObject.GetComponent<SpriteRenderer>().sprite = WarningSprite;
            float width = Camera.main.orthographicSize * Screen.width / Screen.height;
            width = width / 2.6f;
            float heigth = Camera.main.orthographicSize / 2.6f;
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x = width * 0.1f;
            localScale.y = heigth * 0.12f;
            gameObject.transform.localScale = localScale;
        }
        else
        {
            tiempoDeDaño -= Time.deltaTime;
            gameObject.layer = 8;
            gameObject.GetComponent<SpriteRenderer>().sprite = correctSprite;
            float width = Camera.main.orthographicSize * Screen.width / Screen.height;
            width = width / 2.6f;
            float heigth = Camera.main.orthographicSize / 2.6f;
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x = width * 1.4f;
            localScale.y = heigth * 2;
            gameObject.transform.localScale = localScale;
        }
        tiempoDeAdvertencia -= Time.deltaTime;
        if (tiempoDeDaño <= 0)
        {
            Destroy(gameObject);
        }
    }
}
