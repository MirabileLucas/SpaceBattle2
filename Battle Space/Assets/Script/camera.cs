/* camera.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Provide a camera to the playable spaceship for networked games.
/// Allow the player to follow his spaceship and see his environnement.
/// </summary>
public class camera : NetworkBehaviour {

    // TARGET ATTRIBUTES //
    public Spaceship spaceship;
    public Transform target;
    public Camera cam;

    // AUTHORITY FLAG //
    public bool localPlayer;

    /// <summary>
    /// Allow the identification by the parent (localPlayer or not)
    /// </summary>
    /// <param name="local"> Specifies if his parent is the localPLayer 
    /// (this means running his own game instance)
    /// </param>
    public void setLocalPlayer(bool local)
    {
        this.localPlayer = local;
    }

    /// <summary>
    /// Affect and activate the camera prefab to the right player.
    /// Update <see cref="camera"/> positions according to player position once per frame.
    /// </summary>
    void Update () {
        cam = GetComponent<Camera>();
        if (!localPlayer)
        {
            cam.enabled = false;
            return;
        }
        cam.enabled = true;

        if (target != null && spaceship.localPlayer)
        {
            Vector3 vecteurPosition = new Vector3(target.position.x, target.position.y, -20);
            Quaternion quaternion = new Quaternion();
            transform.SetPositionAndRotation(vecteurPosition, quaternion);
            transform.Rotate(0, 0, 0);
        }

    }
    
}

