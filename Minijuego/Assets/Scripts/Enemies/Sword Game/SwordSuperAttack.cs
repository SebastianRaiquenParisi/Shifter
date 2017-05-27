using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSuperAttack : MonoBehaviour {

    public float tiempoDeAdvertencia = 2;
    public float tiempoDeDaño = 1.4f;

    // Use this for initialization
    void Start() {
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        width = width / 2.6f; 
        float heigth = Camera.main.orthographicSize / 2.6f;
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 4:
                gameObject.transform.localScale = new Vector2(width/2, heigth);
                gameObject.transform.position = new Vector3(-width * 1.9f, 0, 0);
                break;
            case 3:
                gameObject.transform.localScale = new Vector2(width/2, heigth);
                gameObject.transform.position = new Vector3(width * 1.9f, 0, 0);
                break;
            case 2:
                gameObject.transform.localScale = new Vector2(width, heigth/2);
                gameObject.transform.position = new Vector3(0, -heigth * 1.9f, 0);
                break;
            case 1:
                gameObject.transform.localScale = new Vector2(width, heigth/2);
                gameObject.transform.position = new Vector3(0, heigth * 1.9f, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		if(tiempoDeAdvertencia > 0)
        {
            gameObject.layer = 10;
        }
        else
        {
            tiempoDeDaño -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.layer = 8;
        }
        tiempoDeAdvertencia -= Time.deltaTime;
        if(tiempoDeDaño <= 0)
        {
            Destroy(gameObject);
        }
	}
}
