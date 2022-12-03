using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("GameMusic");

        Debug.Log("Musics");
        foreach (var mo in musicObjs)
        {
            Debug.Log(mo.scene.name);
            if (mo.scene.name == "DontDestroyOnLoad")
            {
                Debug.Log(mo.scene.name + " destroyed");
                Destroy(mo);
            }
        }
        
        if (musicObjs.Length > 1)
        {
            // Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
    }
}
