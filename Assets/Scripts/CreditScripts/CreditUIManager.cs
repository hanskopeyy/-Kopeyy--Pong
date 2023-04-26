using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditUIManager : MonoBehaviour
{
    public void OpenLinkPorto(){
        Application.OpenURL("https://github.com/hanskopeyy/");
    }
    
    public void ExitToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
