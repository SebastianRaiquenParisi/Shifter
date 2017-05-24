using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public float tiempoDeAdvertencia = 2;
    public float tiempoDeDaño = 1.4f;

    // Use this for initialization
    void Start () {
        float width = Camera.main.orthographicSize * Screen.width / Screen.height;
        width = width / 2.6f;
        float heigth = Camera.main.orthographicSize / 2.6f;
        Vector3 localScale = gameObject.transform.localScale;
        if(Random.Range(0,2) == 1)
        {
            localScale.x = width*2;
        }
        else
        {
            localScale.y = heigth*2;
        }
        gameObject.transform.localScale = localScale;
    }
	
	// Update is called once per frame
	void Update () {
        if (tiempoDeAdvertencia > 0)
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
        if (tiempoDeDaño <= 0)
        {
            Destroy(gameObject);
        }
    }
}
