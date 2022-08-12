using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    AgeManager agemng;

    private void Awake()
    {
        agemng = Object.FindObjectOfType<AgeManager>();
    }

    public void OyunaDevamEt()
    {
        agemng.pausePanel.SetActive(false);
       Time.timeScale = 1;
       agemng.pauseButon.SetActive(true);
    }
    public void YenidenBasla()
    {
        Time.timeScale = 1;
        agemng.pauseButon.SetActive(true);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex); 
    }
    public void OyundanCik()
    {
        SceneManager.LoadScene(0);
    }
}
