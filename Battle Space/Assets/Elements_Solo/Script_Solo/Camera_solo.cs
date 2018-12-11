/* Camera_solo.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Provides a camera to the playable spaceship.
/// Allow the player to follow his spaceship and see his environnement.
/// </summary>
public class Camera_solo : MonoBehaviour
{
    // TARGET ATTRIBUTES //
    public Transform target;

    /// <summary>
    /// Affect and activate the camera prefab to the player.
    /// Update <see cref="Camera_solo"/> positions according to player position once per frame.
    /// </summary>
    void Update()
    {
        if (target != null)
        {
            Vector3 vecteurPosition = new Vector3(target.position.x, target.position.y, -20);
            Quaternion quaternion = new Quaternion();
            transform.SetPositionAndRotation(vecteurPosition, quaternion);
            transform.Rotate(0, 0, 0);
        }

    }
}
