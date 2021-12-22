using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    [SerializeField] private Transform _settingsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Button(transform);
    }

    public void Settings()
    {
        Button(transform, _settingsMenu);
    }
}
