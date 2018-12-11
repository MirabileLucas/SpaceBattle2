/* CreateMatch.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

/// <summary>
/// Provide a functionnal GUI allowing match creation.
/// </summary>
public class CreateMatch : MonoBehaviour {

    // GUI COMPONENTS //
    public GameObject canva_MainMenu, canva_CreateMatch, AUTOSelect_canva_IG_GUI;
    public Button b_Return,b_Start;
    public InputField i_MatchName;
    public Dropdown d_mode,d_NbPlayer;


    /// <summary>
    /// Set up listeners in match creation menu and load GUI.
    /// It's called once by each <see cref="CreateMatch"/> instances.
    /// </summary>
    void Start () {
        b_Return.onClick.AddListener(ReturnonClick);
        b_Start.onClick.AddListener(StartonClick);

        GameObject gameobj_IG_GUI = GameObject.Find("IG_GUI");
        AUTOSelect_canva_IG_GUI = gameobj_IG_GUI.GetComponent<IG_GUI>().Canava_IG_GUI;
        
    }

    /// <summary>
    /// Occurs when a player clicks on "Lancer", load proper map
    /// according to user's choice.
    /// </summary>
    void StartonClick() {     
        if (d_mode.value == 1)
        { 
            // DEATHMATCH LOAD //
            AUTOSelect_canva_IG_GUI.SetActive(true);
            canva_CreateMatch.SetActive(false);
            SceneManager.LoadScene("DeathMatch");

            // ROOM CREATION //
            NetworkManager.singleton.StartMatchMaker();
            if (i_MatchName.text.Length == 0) {
                int i = 1;
                i_MatchName.text = "Room_" + i;

                //TODO : donné un nom qui n'est pas déjà pris si l'utilisateur ne met pas de nom
                //network_script.matches toutes les room
            }

            //d_NbJoueur.value retourne le numéro de l'option choisi donc si le joueur choisi la première option qui est 2, d_NbJoueur.value lui sera 0
            NetworkManager.singleton.matchMaker.CreateMatch(i_MatchName.text,(uint)d_NbPlayer.value+2, true, "", "", "", 0, 0, OnMatchCreate);
            
        }
        else if (d_mode.value == 0) {
            // DEFAULT CHOICE //
        }else if (d_mode.value == 2)
        {
            // TRAINING LOAD //
            AUTOSelect_canva_IG_GUI.SetActive(true);
            canva_CreateMatch.SetActive(false);
            SceneManager.LoadScene("Training");
        }
        
    }

    /// <summary>
    /// Occurs when a player create a networked match, prepare player character
    /// if match creation succeed, else it displays error message.
    /// </summary>
    /// <remarks>For debugging, you can use <paramref name="extendedInfo"/> to help.</remarks>
    /// <seealso cref="NetworkManager.OnMatchCreate(bool, string, MatchInfo)"/>
    /// <param name="success">Indicates if the request succeeded.</param>
    /// <param name="extendedInfo">A text description for the error if success is false.</param>
    /// <param name="matchInfo">The information about the newly created match.</param>
    public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success && matchInfo != null)
        {
            // START SERVER //
            GameObject obj = GameObject.Find("UIPause");
            obj.GetComponent<UIPause>().SetIsServer(true);

            // START HOST //
            NetworkClient myClientHost = NetworkManager.singleton.StartHost(matchInfo);        
            
        }
        else
        {
            Debug.LogError("Create match failed : " + success + ", " + extendedInfo);
        }


    }

    /// <summary>
    /// Occurs when a player clicks on return button.
    /// User is sent back to the main menu.
    /// </summary>
    void ReturnonClick() {
        GameObject obj_main_menu = GameObject.Find("MainMenu");
        canva_MainMenu = obj_main_menu.GetComponent<MainMenu>().canava_MainMenu;

        canva_MainMenu.SetActive(true);
        canva_CreateMatch.SetActive(false);
    }

}
