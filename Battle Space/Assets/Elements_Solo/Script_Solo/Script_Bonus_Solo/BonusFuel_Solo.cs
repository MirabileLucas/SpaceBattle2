/* BonusFuel_Solo.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represent a fuel bonus that restore a part of fuel tank.
/// </summary>
public class BonusFuel_Solo : MonoBehaviour {

    // BONUS OPTION //
    public float quantity;

    /// <summary>
    /// Occurs when there is a collision between the bonus and a spaceship.
    /// The spaceship gets the bonus effect.
    /// </summary>
    /// <remarks>
    /// Contrary to other bonuses based on duration,
    /// that one has an instant effect. Thus there's no need for a coroutine call
    /// in order to handle bonus activation and entity cleaning.
    /// </remarks>
    /// <param name="other">A game object with a 2d collider.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Spaceship_solo spaceship = other.GetComponent<Spaceship_solo>();

            // START EFFECT //
            spaceship.fuel += quantity;
            if (spaceship.fuel > 100) spaceship.fuel = 100;
            spaceship.fuelBar.UpdateBar(spaceship.fuel, 100);
            // END EFFECT //

            // DISABLE BONUS ENTITY //
            Destroy(gameObject);
        }
    }
}
