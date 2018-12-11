/* DontDestroy_UIPause.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provide a user interface when the player clicks on pause button.
/// </summary>
public class DontDestroy_UIPause : MonoBehaviour {

    /// <summary>
    /// Initialize game state before starting Match.
    /// It handles transitions between menu scenes and game scenes.
    /// </summary>
    /// <remarks>
    /// It loads user interface for pause menu during games.
    /// </remarks>
    /// <seealso cref="MonoBehaviour.Awake()"/>
    /// <seealso cref="Object.DontDestroyOnLoad(Object)"/>
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UIPause");

        if (objs.Length > 1)
         {
          Destroy(this.gameObject);
         }
        DontDestroyOnLoad(this.gameObject);

        
    }
}
