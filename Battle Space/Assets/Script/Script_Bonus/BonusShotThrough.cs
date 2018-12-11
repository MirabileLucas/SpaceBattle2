/* BonusShotThrough.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resprensent a shot bonus that can cross other entities without
/// being destroyed, it's only removed when getting out of the map.
/// </summary>
public class BonusShotThrough : MonoBehaviour
{
    // BONUS OPTION //
    public float duration;

    /// <summary>
    /// Occurs when there is a collision between the bonus and a spaceship.
    /// The spaceship gets the bonus effect.
    /// </summary>
    /// <param name="other">A game object with a 2d collider.</param>
    /// <seealso cref="Coroutine"/>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Spaceship spaceship = other.GetComponent<Spaceship>();
            if (!spaceship.hasShotBonus)
            {
                StartCoroutine(Pickup(spaceship));
            }
        }
    }

    /// <summary>
    /// Occurs when <param name="other"/> is inside the bonus's detection radius.
    /// The spaceship gets the bonus effect.
    /// </summary>
    /// <param name="other">A game object with a 2d collider.</param>
    /// <seealso cref="Coroutine"/>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Spaceship spaceship = other.GetComponent<Spaceship>();
            if (!spaceship.hasShotBonus)
            {
                StartCoroutine(Pickup(spaceship));
            }
        }
    }

    /// <summary>
    /// Apply bonus effect on <param name="spaceship"/>.
    /// </summary>
    /// <param name="spaceship">The lucky owner of the bonus.</param>
    /// <returns>
    /// A temporary suspension of the StartCoroutine method 
    /// implying the duration of the bonus.
    /// </returns>
    /// <seealso cref="YieldInstruction"/>
    /// <seealso cref="Coroutine"/>
    IEnumerator Pickup(Spaceship spaceship)
    {
        // START EFFECT //
        spaceship.hasShotBonus = true;
        spaceship.shot = spaceship.shotsDico["Through"];
        spaceship.firemode = FireMode.Through;

        // DISABLE BONUS ENTITY //
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        // WAIT DURATION //
        yield return new WaitForSeconds(duration);

        // END EFFECT //
        spaceship.hasShotBonus = false;
        spaceship.shot = spaceship.shotsDico["Default"];
        spaceship.firemode = FireMode.Default;

        Destroy(gameObject);
    }
}