/* Join_match.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

/// <summary>
/// Represent a user interface to join matches.
/// </summary>
public class Join_Match : MonoBehaviour {

    // GUI ATTRIBUTES //
    public GameObject canvas_mainmenu, canvas_Join_Match;
    public Button b_return;
    public GameObject panel;

    // GUI FLAGS //
    public bool actif;
    private bool refreshDone;

    // MATCH LISTS //
    protected List<GameObject> panels = new List<GameObject>();

    /// <summary>
    /// Set up listeners in joining match menu and set up match making.
    /// It's called once by each <see cref="Join_Match"/> instances.
    /// </summary>
    void Start () {
        b_return.onClick.AddListener(RetunonClick);
        refreshDone = false;
        actif = false;
        NetworkManager.singleton.StartMatchMaker();

    }

    /// <summary>
    /// Update the state and behaviour of <see cref="Join_Match"/> instances.
    /// </summary>
    /// <remarks>Refresh match list.</remarks>
    void Update()
    {
        if (actif && !refreshDone) {
            //Debug.Log("Refresh List");
            NetworkManager.singleton.matchMaker.ListMatches(0, 2, "", false, 0, 0, OnMatchList);
            refreshDone = true;
        }  
    }


    /// <summary>
    /// Occurs when match list is refreshed. It displays all matches info for each matches.
    /// If there is an error, an error message is displayed.
    /// </summary>
    /// <remarks>For debugging, you can use <paramref name="extendedInfo"/> to help.</remarks>
    /// <param name="success">Indicates if the request succeeded.</param>
    /// <param name="extendedInfo">
    /// A text description for the error if success is false.
    /// </param>
    /// <param name="matches">
    /// A list of matches corresponding to the filters set in the initial list request.
    /// </param>
    /// <seealso cref="NetworkMatch.ListMatches(int, int, string, bool, int, int, NetworkMatch.DataResponseDelegate{List{MatchInfoSnapshot}})"/>
    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {

        if (success)
        {
            if (matches.Count != 0)
            {

                int num_panel = 0;
                matches.ForEach(delegate (MatchInfoSnapshot matchinfo)
                {
                    // MATCH GUI POSITION//
                    GameObject p = Instantiate(panel, canvas_Join_Match.transform);
                    //p.transform.parent = canvas_rejoindre_partie.transform;
                    p.transform.localScale = new Vector3(1, 1, 1);
                    p.transform.localPosition = new Vector3(0.0f, 210.0f - 100 * num_panel, 0.0f);
                    p.transform.SetAsFirstSibling();

                    // MATCH INFO FILLING //
                    p.GetComponent<Panel_text>().nom_partie.text = matchinfo.name;
                    p.GetComponent<Panel_text>().nb_joueur.text = matchinfo.currentSize.ToString() + " / " + matchinfo.maxSize.ToString();
                    p.GetComponent<Panel_text>().mode_de_jeu.text = "DeathMatch";
                    /*
                    p.GetComponent<Panel_text>().durée_partie.text = ;
                    p.GetComponent<Panel_text>().ping.text = ;
                    */

                    // SET UP LISTENER //
                    p.GetComponent<Panel_text>().net = matchinfo;
                    p.GetComponent<Panel_text>().b_button.onClick.AddListener(delegate { MatchSelected(p); });

                    panels.Add(p);
                    num_panel++;


                }
                    ); //ForEach liste_matches

            }
            else
            {
                Debug.Log("No matches in requested room!");
            }
        }
        else
        {
            Debug.LogError("Couldn't connect to match maker");
        }
    }

    /// <summary>
    /// Occurs when a player choose a match to join.
    /// </summary>
    /// <param name="panel">The panel containing all matchs info.</param>
    void MatchSelected(GameObject panel)
    {
        // PREPARE GAME UI //
        GameObject gameobj_IG_GUI = GameObject.Find("IG_GUI");
        GameObject canva_IG_GUI_AUTOSelect = gameobj_IG_GUI.GetComponent<IG_GUI>().Canava_IG_GUI;

        // CHANGING CANVAS //
        canva_IG_GUI_AUTOSelect.SetActive(true);
        canvas_Join_Match.SetActive(false);

        // JOIN MATCH //
        SceneManager.LoadScene("DeathMatch");
        NetworkManager.singleton.matchMaker.JoinMatch(panel.GetComponent<Panel_text>().net.networkId, "", "", "", 0, 0, OnMatchJoined);
    }

    /// <summary>
    /// Occurs when a player tries to join a match.
    /// </summary>
    /// <remarks>For debugging, you can use <paramref name="extendedInfo"/> to help.</remarks>
    /// <param name="success">Indicates if the request succeeded.</param>
    /// <param name="extendedInfo">A text description for the error if success is false.</param>
    /// <param name="matchInfo">The info for the newly joined match.</param>
    /// <seealso cref="NetworkManager.OnMatchJoined(bool, string, MatchInfo)"/>
    public void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            //Debug.Log("Able to join a match");
            NetworkClient myclient = NetworkManager.singleton.StartClient(matchInfo);
            
            myclient.Connect(matchInfo);
        }
        else
        {
            Debug.LogError("Join match failed");
        }
    }

    /// <summary>
    /// Occurs when a player clicks on return button.
    /// It send the user back to the main menu.
    /// </summary>
    /// <remarks>It also reset the <see cref="Join_Match"/> instance.</remarks>
    void RetunonClick() {
        actif = false;
        refreshDone = false;

        foreach (GameObject x in panels)
        {
            Destroy(x);
        }
        canvas_mainmenu.SetActive(true);
        canvas_Join_Match.SetActive(false);
    }

}
