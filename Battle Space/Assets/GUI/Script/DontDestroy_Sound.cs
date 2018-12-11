/* DontDestroy_Sound.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provide sound manager during games.
/// </summary>
public class DontDestroy_Sound : MonoBehaviour
{
    /// <summary>
    /// Initialize game state before starting Match.
    /// It handles transitions between menu scenes and game scenes.
    /// </summary>
    /// <remarks>
    /// It activates sound tracks on games or menu...
    /// </remarks>
    /// <seealso cref="MonoBehaviour.Awake()"/>
    /// <seealso cref="Object.DontDestroyOnLoad(Object)"/>
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Sound");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }
}
