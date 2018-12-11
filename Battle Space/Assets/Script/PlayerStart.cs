/* PlayerStart.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Reprensents the player entity, gives authority for spaceship.
/// </summary>
public class PlayerStart : NetworkBehaviour {

    // PLAYABLE SPACESHIP //
    public Spaceship spaceship;
    public camera camera;

    /// <summary>
    /// Set the authority to the spaceship and the camera according to 
    /// <see cref="isLocalPlayer"/> result.
    /// </summary>
    private void SetAuthority() {
        spaceship.setLocalPlayer(isLocalPlayer);
        camera.setLocalPlayer(isLocalPlayer);
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerStart"/> class.
    /// </summary>
    /// <remarks>It only calls <see cref="SetAuthority"/> method.</remarks>
    void Start () {
        SetAuthority();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerStart"/> class.
    /// </summary>
    /// <remarks>It only calls <see cref="SetAuthority"/> method.</remarks>
    void Update () {
        SetAuthority();
    }
}
