/* IG_GUI.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represent a user interface used during matches.
/// </summary>
/// <remarks>IG means In Game</remarks>
public class IG_GUI : MonoBehaviour{

    // GUI ATTRIBUTES //
    public Button b_Param_IG;
    public GameObject Canava_UIPause,Canava_IG_GUI;


    /// <summary>
    /// Set up listeners for in game user interface.
    /// It's called once by each <see cref="IG_GUI"/> instances.
    /// </summary>
    private void Start()
    {
        b_Param_IG.onClick.AddListener(ButtonPauseIGonClick);

    }

    /// <summary>
    /// Occurs when a player clicks on pause button.
    /// It Loads and unloads canvas to display pause menu.
    /// </summary>
    public void ButtonPauseIGonClick()
    {
        //enable Canva_UIPause
        Canava_UIPause.SetActive(true);

        //disable Canva_GameController
        Canava_IG_GUI.SetActive(false);


    }
}
