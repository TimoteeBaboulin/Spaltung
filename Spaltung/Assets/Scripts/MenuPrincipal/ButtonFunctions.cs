using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
//using Scene = UnityEditor.SearchService.Scene;

public class ButtonFunctions : MonoBehaviour
{
    public AudioMixer Audio;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        SceneManager.UnloadSceneAsync("MenuPrincipal");
    }

    public void Changevolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        Audio.SetFloat("Volume",PlayerPrefs.GetFloat("Volume") - 2);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
