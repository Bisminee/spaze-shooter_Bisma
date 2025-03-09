using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int pilihan1;
    public int pilihan2;
    public int pilihan3;
    public int pilihan4;
    public void PlayGame()
    {
        SceneManager.LoadScene(pilihan1);
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(pilihan2);
    }
    public void Back()
    {
        SceneManager.LoadScene(pilihan3);
    }

    public void Select()
    {
        SceneManager.LoadScene(pilihan4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
