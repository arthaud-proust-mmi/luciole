using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToCreditsScreen () { 
       SceneManager.LoadScene("Credits");
   }
   
   public void ChangeToHome () { 
          SceneManager.LoadScene("Home");
      }
   
   public void ChangeToGameStart () { 
       SceneManager.LoadScene("GameStart");
   }
   
   public void ChangeToGameHelp () { 
       SceneManager.LoadScene("GameHelp");
   }
   
   public void ChangeToLevel1 () { 
       SceneManager.LoadScene("Level1");
   }
   
   public void ChangeToLevel3 () { 
       SceneManager.LoadScene("Level3");
   }
}
