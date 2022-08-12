using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour  //ANA MENÜ KODLARI
{
    public GameObject infoPanel;
    void Start()
    {
        Time.timeScale = 1;
    }

    public void OyunaBasla()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void InfoPanelAc()
    {
        infoPanel.SetActive(true);
    }

    public void InfoPanelKapat()
    {
        infoPanel.SetActive(false);
    }
    public void OyundanCik()
    {    
        Application.Quit();
    }
}
