using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private void DisableMenu(Transform transform)
    {
        //foreach (Transform child in transform)
        //    child.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
    }

    private void ActiveMenu(Transform transform)
    {
        //foreach (Transform child in transform)
        //    child.gameObject.SetActive(true);
        transform.gameObject.SetActive(true);
    }

    public void Button(Transform currentMenu, Transform nextMenu = null)
    {
        if (currentMenu != null) 
            DisableMenu(currentMenu);
        if (nextMenu != null)
            ActiveMenu(nextMenu);
    }
}
