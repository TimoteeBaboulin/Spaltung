using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Scene = UnityEditor.SearchService.Scene;

public class ButtonFunctions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        SceneManager.UnloadSceneAsync("MenuPrincipal");
    }
}
