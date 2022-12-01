using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public string SceneNametoLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void changeScene () {
   SceneManager.LoadScene(SceneNametoLoad);

    }
}
