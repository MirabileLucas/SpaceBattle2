/* Panel_text.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

/// <summary>
/// Represent the entity containing all information per match.
/// </summary>
/// <remarks>
/// The script only defines the <see cref="Panel_text"/> class.
/// <seealso cref="Join_Match"/> class in Join_Match.cs to see
/// how it's used.
/// </remarks>
public class Panel_text : MonoBehaviour {

    // GUI COMPONENTS //
    public Text nom_partie, nb_joueur, mode_de_jeu, durée_partie, ping;
    public MatchInfoSnapshot net;
    public Button b_button;
}
