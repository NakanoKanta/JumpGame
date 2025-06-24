using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject C_Menu;
    [SerializeField] GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(true);
        C_Menu.SetActive(false);
        Title.SetActive(false);
    }

    public void GoMenu()
    {
        Menu.SetActive(false);
        C_Menu.SetActive(true);
        Title.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(true);
        C_Menu.SetActive(false);
        Title.SetActive(false);
    }
}
