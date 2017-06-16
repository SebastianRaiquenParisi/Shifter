using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    private void Start()
    {
        
    }
    void Update()
    {
        if (GameObject.Find("SuperAttackSword(Clone)") == null)
        {
            Destroy(gameObject);
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
