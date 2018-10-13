using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.rotation = Quaternion.Inverse(transform.parent.rotation);
        Vector3 vecteurPosition = new Vector3(target.position.x, target.position.y, -20);
        Quaternion quaternion = new Quaternion();
        transform.SetPositionAndRotation(vecteurPosition, quaternion);
        transform.Rotate(0, 0, 0);
    }
}
