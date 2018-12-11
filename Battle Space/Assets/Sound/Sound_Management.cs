using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Management : MonoBehaviour {

    //b_XXX == button_XXX
    //s_XXX == slider_XXX
    //a_XXX == audio_XXX
    //i_XXX == image_XXX

    public Button b_Sound;
    public Slider s_Sound;
    public AudioSource a_Sound;
    public Sprite i_Sound_on, i_Sound_off;

    // Use this for initialization
    void Start ()
    {
        a_Sound = AudioSource.FindObjectOfType<AudioSource>();
        b_Sound.onClick.AddListener(OnClick);
        s_Sound.onValueChanged.AddListener(delegate { ChangeSlider(); });
    }


    public void ChangeSlider() {
        a_Sound.GetComponent<AudioSource>().volume = s_Sound.value;
    }

    public void OnClick() {
        //Handheld.Vibrate();
        a_Sound.mute = !a_Sound.mute;

        if(b_Sound.GetComponent<Image>().sprite != i_Sound_off)
        {
            b_Sound.GetComponent<Image>().sprite = i_Sound_off;
        }
        else
        {
            b_Sound.GetComponent<Image>().sprite = i_Sound_on;
        }
        
    }
	// Update is called once per frame
	void Update () {
        s_Sound.value = a_Sound.volume;
        if (a_Sound.mute)
        {
            b_Sound.GetComponent<Image>().sprite = i_Sound_off;
        }
        else {
            b_Sound.GetComponent<Image>().sprite = i_Sound_on;
        }
    }
}
