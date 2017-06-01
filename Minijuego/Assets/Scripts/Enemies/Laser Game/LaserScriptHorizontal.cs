using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptHorizontal : MonoBehaviour {
    public Sprite WarningSprite;
    public float tiempoDeAdvertencia = 2;
    public float tiempoDeDaño = 1.4f;
    Sprite correctSprite;

    // Use this for initialization
    void Start() {
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        width = width / 2.6f;
        float heigth = Camera.main.orthographicSize / 2.6f;
        Vector3 localScale = gameObject.transform.localScale;
        localScale.x = width * 2;
        localScale.y = heigth * 0.5f;
        gameObject.transform.localScale = localScale;
        correctSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (tiempoDeAdvertencia > 0)
        {
            gameObject.layer = 10;
            gameObject.GetComponent<SpriteRenderer>().sprite = WarningSprite;
        }
        else
        {
            tiempoDeDaño -= Time.deltaTime;
            gameObject.layer = 8;
            gameObject.GetComponent<SpriteRenderer>().sprite = correctSprite;
        }
        tiempoDeAdvertencia -= Time.deltaTime;
        if (tiempoDeDaño <= 0)
        {
            Destroy(gameObject);
        }
    }
}
