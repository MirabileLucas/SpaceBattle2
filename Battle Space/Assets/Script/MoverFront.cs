/* MoverFront.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Provides speed for projectiles, allow projectiles to move.
/// </summary>
public class MoverFront : NetworkBehaviour {
    
    // SPEED ATTRIBUTE //
    public float speed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MoverFront"/> class.
    /// Set up shot velocity.
    /// </summary>
    void Start () {
        //Set up of velocity
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
	
}
