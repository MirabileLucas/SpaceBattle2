/* DestroyByBoundary.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides collision system for all entities trying to cross the borders.
/// </summary>
public class DestroyByBoundary : MonoBehaviour {

    /// <summary>
    /// Occurs when an item try to cross the borders, it destroys it.
    /// </summary>
    /// <param name="other">A game obejct with a 2D collider which tried to cross the border</param>
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
