using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonController : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
