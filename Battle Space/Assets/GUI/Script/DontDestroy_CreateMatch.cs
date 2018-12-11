/* DontDestroy_CreateMatch.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provide a match entity to play in network. 
/// </summary>
public class DontDestroy_CreateMatch : MonoBehaviour {

    /// <summary>
    /// Initialize game state before starting match.
    /// It handles transitions between menu scenes and game scenes.
    /// </summary>
    /// <remarks>It loads the network entity of the match</remarks>
    /// <seealso cref="MonoBehaviour.Awake()"/>
    /// <seealso cref="Object.DontDestroyOnLoad(Object)"/>
    void Awake()
    {   
        // DESTROY GUI //
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Creation_partie");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // KEEP MATCH ENTITY ALIVE //
        DontDestroyOnLoad(this.gameObject);


    }
}
