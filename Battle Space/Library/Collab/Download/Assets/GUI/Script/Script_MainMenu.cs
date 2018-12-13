using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Script_MainMenu : MonoBehaviour {

    public GameObject canava_MainMenu, canava_Créer_une_partie, canava_MainMenu_Option, canva_Rejoindre_une_partie;
    public Button b_Créer_partie, b_Option, b_Rejoindre_partie;

    private GameObject gameobj_Creation_partie;
    private GameObject obj_rejoindre_partie;

    private void Start()
    {
        gameobj_Creation_partie = GameObject.Find("GameObject_Création_Partie");
        canava_Créer_une_partie = gameobj_Creation_partie.GetComponent<Script_Création_de_partie>().canva_Créer_une_partie;
        
        //Canava_MainMenu.SetActive(false);
        b_Créer_partie.onClick.AddListener(ButtonCréeronClick);
        b_Option.onClick.AddListener(OptionClick);
        b_Rejoindre_partie.onClick.AddListener(RejoindreonClick);
    }

    public void RejoindreonClick()
    {
        canva_Rejoindre_une_partie.SetActive(true);

        obj_rejoindre_partie = GameObject.Find("GameObject_Rejoindre_partie");
        obj_rejoindre_partie.GetComponent<Script_Rejoindre_partie>().actif = true;

        canava_MainMenu.SetActive(false);
    }
    public void OptionClick()
    {
        canava_MainMenu_Option.SetActive(true);
        canava_MainMenu.SetActive(false);
    }

    void ButtonCréeronClick()
    {
        canava_Créer_une_partie.SetActive(true);
        canava_MainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
