using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_IG_GUI : MonoBehaviour{

    public Button b_Param_IG;
    public GameObject Canava_UIPause,Canava_IG_GUI;



    private void Start()
    {
        b_Param_IG.onClick.AddListener(ButtonPauseIGonClick);

    }

    public void ButtonPauseIGonClick()
    {
        //enable Canva_UIPause
        Canava_UIPause.SetActive(true);

        //disable Canva_GameController
        Canava_IG_GUI.SetActive(false);


    }

    void Update()
    {

    }
}
