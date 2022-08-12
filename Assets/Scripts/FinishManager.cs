using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinishManager : MonoBehaviour
{
    public Text puanText, yuzdeText;

    AgeManager agemng;
    private void Awake()
    {
        agemng = Object.FindObjectOfType<AgeManager>();
    }
    void Start() //finish ekranýna istatistikleri yazdýrýr.
    {
        agemng.pauseButon.SetActive(false);
        puanText.text = agemng.toplamPuan.ToString();
        yuzdeText.text = "%" + agemng.score.ToString();
        Time.timeScale = 0;
        if (agemng.score == 100) //skorun yüksekliðine göre renk deðiþimi.
        {
            yuzdeText.color = Color.green;
        }
        else if (agemng.score >= 90)
        {
            yuzdeText.color = Color.green;
        }
        else if (agemng.score >= 70)
        {
            yuzdeText.color = Color.blue;
        }
        else if (agemng.score >= 50)
        {
            yuzdeText.color = Color.cyan;
        }
        else if (agemng.score >=30)
        {
            yuzdeText.color = Color.red;
        }
        else if (agemng.score >= 20)
        {
            yuzdeText.color = Color.HSVToRGB(1f, 1f, 1f);
        }
        else if (agemng.score < 20)
        {
            yuzdeText.color = Color.gray;
        }
    }

    public void SonrakiLeveleGec()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void TekrarDene()
    {
        agemng.genelToplamPuan=- agemng.toplamPuan; //eðer tekrar deneyecekse o levelde kazandýðý puan playerprefs'e gitmemeli.
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void AnaMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
