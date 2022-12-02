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
   
   public void ChangeToCreditsScreen () { 
       SceneManager.LoadScene("Credits");
   }
   
   public void ChangeToGameStartingScreen () { 
       SceneManager.LoadScene("GameStarting");
   }
   
   public void ChangeToLevel1 () { 
       SceneManager.LoadScene("Level1");
   }
}
