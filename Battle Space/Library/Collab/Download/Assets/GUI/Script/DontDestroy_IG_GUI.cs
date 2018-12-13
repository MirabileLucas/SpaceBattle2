using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy_IG_GUI : MonoBehaviour
{

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IG_GUI");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }
}
