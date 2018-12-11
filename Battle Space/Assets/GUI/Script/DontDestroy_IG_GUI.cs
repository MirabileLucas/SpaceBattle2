/* DontDestroy_IG_GUI.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provide a user interface in game.
/// </summary>
public class DontDestroy_IG_GUI : MonoBehaviour
{
    /// <summary>
    /// Initialize game state before starting Match.
    /// It handles transitions between menu scenes and game scenes.
    /// </summary>
    /// <remarks>
    /// It loads the game UI allowing player to quit match, disable sound...
    /// </remarks>
    /// <seealso cref="MonoBehaviour.Awake()"/>
    /// <seealso cref="Object.DontDestroyOnLoad(Object)"/>
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IG_GUI");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }
}
