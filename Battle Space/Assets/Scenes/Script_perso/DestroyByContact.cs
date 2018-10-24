using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GameObject collided with " + other.name);
        if (other.tag == "Boundary") return;
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
