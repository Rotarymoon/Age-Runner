using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AgeManager : MonoBehaviour
{
    public int age;
    int beklenenAge;
    public TMP_Text tmpYas, tmpHedefMekan, tmpGenelToplamPuan;
    public int score, toplamPuan, genelToplamPuan;
    public string hedefMekan;
    RunnerController runner;
    public GameObject death, bebek, cocuk, genc, yetiskin, ebeveyn, yasli;
    public GameObject finishPanel,pausePanel, pauseButon, deathPanel;
    public GameObject particleObj;
    int levelSayi;

    private void Awake()
    {
        runner = Object.FindObjectOfType<RunnerController>();
    }
    private void Start()
    {
        //PlayerPrefs.SetString("PlayerName", "Talha");
        GameSceneStartCheck();
        Debug.Log("Yaþýn: " + age + " Hedefin: " + beklenenAge + " Mekan: " + hedefMekan);
    }

    private void FixedUpdate()
    {
        CheckDeath(); //her an ölme ihtimailne karþý kontrol. 
        YasaGoreInsanTipi(); //her yaþ grubunun kendine özel karakteri var. bunlar tanýmlanýyor.
        tmpYas.text = "Level: " + levelSayi + "     " + "Yaþ: " + age;                          //þuanki yaþ ekranda gözüksün.
        tmpHedefMekan.text = "Hedef Mekân: " + hedefMekan;   //þuanki hedef mekan gözüksün
        genelToplamPuan = PlayerPrefs.GetInt("Highscore"); //genel toplam puaný player prefsten çek.
        tmpGenelToplamPuan.text = "Genel Toplam Puan: " + genelToplamPuan.ToString(); //ekranda genel toplam puana yaz.
    }

    private void OnTriggerEnter(Collider other) //her bir gate kendine ait tag'e sahip. Her trigger'da sayýya göre yaþ artýyor ya da eksiliyor. 
    {
                    //GATES
        if (other.transform.CompareTag("-2"))
        {
            age -= 2;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else  if (other.transform.CompareTag("-3"))
        {
            age -= 3;
            Destroy(other.gameObject);

            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("-5"))
        {
            age -= 5;
            Destroy(other.gameObject);

            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("-8"))
        {
            age -= 8;
            Destroy(other.gameObject);

            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("-10"))
        {
            age -= 10;
            Destroy(other.gameObject);

            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("+2"))
        {
            age += 2;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("+3"))
        {
            age += 3;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("+5"))
        {
            age += 5;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("+8"))
        {
            age += 8;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("+10"))
        {
            age += 10;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
                    //PROPS
        else if (other.transform.CompareTag("sigara")) //sigara kötü alýþkanlýðý temsil ediyor. Yaþlandýrýyor!
        {
            age += 15;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("fastfood")) //fastfood zararý temsil ediyor. Gençleþtiriyor.
        {
            age += 7;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("elma")) //elma saðlýðý temsil ediyor. Gençleþtiriyor.
        {
            age -= 6;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("muz")) //muz saðlýðý temsil ediyor. Gençleþtiriyor.
        {
            age -= 4;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        else if (other.transform.CompareTag("portakal")) //portakal saðlýðý temsil ediyor. Gençleþtiriyor.
        {
            age -= 2;
            Destroy(other.gameObject);
            particleObj.GetComponent<ParticleSystem>().Play();
        }
        //OYUN BÝTÝÞÝ
        else if (other.CompareTag("FinishEdge")) //bitiþ çizgisini geçtiði anda oyun duruyor ve puan hesaplanýyor.
        {
            finishPanel.SetActive(true);
            CheckAge();
        }
    }

    void CheckAge() //player finish çizgisinden geçince çalýþacak. Level sonunda yaþýn, istenen yaþa yakýnlýðýna göre puan veriliyor.
    {
        int mutlakAge; //yaþ ve beklenen yaþ arasýndaki fark.
        mutlakAge = age - beklenenAge; //bu fark mutlak deðer alýyor. Çünkü - deðer de çýkabilir. bize mutlak lazým fark için.
        if (Mathf.Abs(mutlakAge) == 0)
        {
            score = 100;
            Debug.Log("skorun: " + score);
        }
        else if (Mathf.Abs(mutlakAge) < 4)
        {
            score = 99;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 6)
        {
            score = 95;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 10)
        {
            score = 90;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 12)
        {
            score = 85;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 15)
        {
            score = 80;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 18)
        {
            score = 75;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 21)
        {
            score = 70;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 24)
        {
            score = 65;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 28)
        {
            score = 60;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 31)
        {
            score = 55;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 37)
        {
            score = 50;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 43)
        {
            score = 40;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 49)
        {
            score = 45;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 55)
        {
            score = 30;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 60)
        {
            score = 20;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 65)
        {
            score = 10;
            Debug.Log(score);
        }
        else if (Mathf.Abs(mutlakAge) < 75)
        {
            score = 5;
            Debug.Log(score);
        }
        toplamPuan = score * 15;               //leveldaki toplam puan, 15 ile skorun çarpýmý oluyor.
        Debug.Log("bölüm sonu toplam puan: " + toplamPuan);
        int toplanacakPuan = PlayerPrefs.GetInt("Highscore"); //önceki seviyedeki puanla bunu topluyoruz. çünkü toplam puaný ancak böyle gösterebiliriz.
        PlayerPrefs.SetInt("Highscore", toplamPuan+toplanacakPuan); //puaný playerprefs'e gönderiyoruz.
        genelToplamPuan = PlayerPrefs.GetInt("Highscore"); //ve bunu kullanmak üzere bir deðiþkene atýyoruz.
    }

    void GameSceneStartCheck() //oyunun leveline göre oyuncunun hedef mekaný ve baþlangýç yaþý deðiþiyor. beklenen yaþý oyuncu bilmeyecek. tahmini ilerleyecek.
    {
        if (this.gameObject.name == "Player1") //player1, 1. level'ý belirtir.
        {
            levelSayi = 1;
            age = 2;
            beklenenAge = 65;
            hedefMekan = "Huzurevi";
        }
        else if (this.gameObject.name == "Player2")
        {
            levelSayi = 2;
            age = 25;
            beklenenAge = 8;
            hedefMekan = "Ýlkokul";
        }
        else if (this.gameObject.name == "Player3")
        {
            levelSayi = 3;
            age = 39;
            beklenenAge = 20;
            hedefMekan = "Üniversite";
        }
        else if (this.gameObject.name == "Player4")
        {
            levelSayi = 4;
            age = 30;
            beklenenAge = 12;
            hedefMekan = "Ortaokul";
        }
        else if (this.gameObject.name == "Player5")
        {
            levelSayi = 5;
            age = 50;
            beklenenAge = 12;
            hedefMekan = "Lunapark";
        }
        else if (this.gameObject.name == "Player6")
        {
            levelSayi = 6;
            age = 23;
            beklenenAge = 2;
            hedefMekan = "Kreþ";
        }
        else if (this.gameObject.name == "Player7")
        {
            levelSayi = 7;
            age = 54;
            beklenenAge = 16;
            hedefMekan = "Lise";
        }
        else if (this.gameObject.name == "Player8")
        {
            levelSayi = 8;
            age = 8;
            beklenenAge = 55;
            hedefMekan = "Kýraathane";
        }
        else if (this.gameObject.name == "Player9")
        {
            levelSayi = 9;
            age = 16;
            beklenenAge = 18;
            hedefMekan = "Konser";
        }
        else if (this.gameObject.name == "Player10")
        {
            levelSayi = 10;
            age = 36;
            beklenenAge = 6;
            hedefMekan = "Anaokulu";
        }
    }

    void YasaGoreInsanTipi() //karakterin yaþýna göre hýz ve scale deðiþimi oluyor. Farklý karakterler ve farklý animasyonlar oynayacak.
    {
        if (age < 0) //KARAKTERÝN YAÞI SIFIRIN ALTINA ÝNERSE ÖLÜR.
        {
            if (runner.isRunning)
            {
                runner.isRunning = false;
                //bebek.SetActive(false);
                //cocuk.SetActive(false);
                //genc.SetActive(false);
                //yetiskin.SetActive(false);
                //ebeveyn.SetActive(false);
                //yasli.SetActive(false);
                //death.SetActive(true);
                bebek.GetComponent<Transform>().DOScale(0, 2f);
                cocuk.GetComponent<Transform>().DOScale(0, 2f);
                genc.GetComponent<Transform>().DOScale(0, 2f);
                yetiskin.GetComponent<Transform>().DOScale(0, 2f);
                ebeveyn.GetComponent<Transform>().DOScale(0, 2f);
                yasli.GetComponent<Transform>().DOScale(0, 2f);
            }
        }
        if(age >= 0 && age < 4) //bebek - emekliyor
        {
            runner.speed = 150;
            if (runner.isRunning)
            {
                bebek.SetActive(true);
                cocuk.SetActive(false);
                genc.SetActive(false);
                yetiskin.SetActive(false);
                ebeveyn.SetActive(false);
                yasli.SetActive(false);
            }
        }
        else if (age >= 4 && age < 14) //çocuk - yavaþ koþuyor
        {
            runner.speed = 300;
            if (runner.isRunning)
            {
                bebek.SetActive(false);
                cocuk.SetActive(true);
                genc.SetActive(false);
                yetiskin.SetActive(false);
                ebeveyn.SetActive(false);
                yasli.SetActive(false);
            }
        }
        else if (age >= 14 && age < 22) //genç - hýzlý koþuyor
        {
            runner.speed = 450;
            if (runner.isRunning)
            {
                bebek.SetActive(false);
                cocuk.SetActive(false);
                genc.SetActive(true);
                yetiskin.SetActive(false);
                ebeveyn.SetActive(false);
                yasli.SetActive(false);
            }
        }
        else if (age >=22 && age < 41) //yetiþkin - çok hýzlý koþuyor
        {
            runner.speed = 650;
            if (runner.isRunning)
            {
                bebek.SetActive(false);
                cocuk.SetActive(false);
                genc.SetActive(false);
                yetiskin.SetActive(true);
                ebeveyn.SetActive(false);
                yasli.SetActive(false);
            }
        }
        else if (age >= 41 && age < 60) //ebeveyn - yorgun koþuyor
        {
            runner.speed = 450;
            if (runner.isRunning)
            {
                bebek.SetActive(false);
                cocuk.SetActive(false);
                genc.SetActive(false);
                yetiskin.SetActive(false);
                ebeveyn.SetActive(true);
                yasli.SetActive(false);
            }
        }
        else if (age >= 60) //yaþlý - koþamýyor
        {
            runner.speed = 250;
            if (runner.isRunning)
            {
                bebek.SetActive(false);
                cocuk.SetActive(false);
                genc.SetActive(false);
                yetiskin.SetActive(false);
                ebeveyn.SetActive(false);
                yasli.SetActive(true);
            }
        }
    }
    public void OyunuDurdur() //pause butonu
    {
        pauseButon.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void CheckDeath() //yaþ -1 ve daha az olursa oyuncu ölecek.
    {
        if (age < 0)
        {
           StartCoroutine(InitDeath());
        }
    }

    IEnumerator InitDeath() //ölüm animasyonu için geçmesi gereken süreden sonra ölüm ekraný çýkýyor.
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        pauseButon.SetActive(false);
        deathPanel.SetActive(true);
        StopCoroutine(InitDeath()); //bir kere çalýþmasý için coroutine'i durdur.
    }
}
