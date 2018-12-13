using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy_UIPause : MonoBehaviour {

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UIPause");

        if (objs.Length > 1)
         {
          Destroy(this.gameObject);
         }
        DontDestroyOnLoad(this.gameObject);

        
    }
}
