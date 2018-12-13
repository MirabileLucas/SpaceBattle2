using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy_Creation_Partie : MonoBehaviour {

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Creation_partie");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }
}
