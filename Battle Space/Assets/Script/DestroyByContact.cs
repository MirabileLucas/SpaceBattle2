/* DestroyByContact.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Provides collision system for all entities in the map in networked games.
/// </summary>
public class DestroyByContact : NetworkBehaviour {

    // SHOOTER ATTRIBUTE //
    public Spaceship shooter;

    /// <summary>
    /// Occurs when there is a collision between a projectile shot by
    /// the shooter and a interactive game object.
    /// It destroys the <param name="other"/> collider if it's an
    /// ennemy spaceship.
    /// Projectile destroys himself by encountering another collider.
    /// </summary>
    /// <param name="other">A game object with a 2D collider which got hit by a projectile.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary") return;
        if (other.tag == "Bonus") return;
        if (other.tag == "Player")
        {
            Spaceship spaceship = other.GetComponent<Spaceship>();
            if (spaceship == shooter)
            {
                Destroy(gameObject);
                return;
            }

            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
