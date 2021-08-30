using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : Menu
{
    [SerializeField] Transform _mainMenu;

    [SerializeField]  AudioSource _soundVolume;
    public void Cancel()
    {
        Button(transform, _mainMenu);
        
    }
    public void Volume()
    {
        if (_soundVolume.volume == 1)
        {
            _soundVolume.volume = 0;
        }
        else
            _soundVolume.volume = 1;
    }
}
