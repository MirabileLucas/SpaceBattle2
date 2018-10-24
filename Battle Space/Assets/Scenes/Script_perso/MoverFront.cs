using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFront : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
