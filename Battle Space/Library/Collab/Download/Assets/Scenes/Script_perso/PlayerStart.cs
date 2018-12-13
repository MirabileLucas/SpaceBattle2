using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerStart : NetworkBehaviour {
    public Spaceship spaceship;
	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
            spaceship.setLocalPlayer(true);
        else
            spaceship.setLocalPlayer(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
            spaceship.setLocalPlayer(true);
        else
            spaceship.setLocalPlayer(false);

    }
}
