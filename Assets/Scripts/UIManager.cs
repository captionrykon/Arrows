using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Rendering.PostProcessing;

public class UIManager : MonoBehaviour
{
    public int scenetoconti;
    public GameObject pausescreen;
    [SerializeField]
    private GameObject joystick;
    public GameObject winningPannel;
    public GameObject graphicpannel;
    [SerializeField]
    private GameObject pausebutton;
    private int currentsceneindex;
    [SerializeField]
    private GameObject clickpartical;
    [SerializeField] private GameObject playbutton;
    [SerializeField] private GameObject soundbutton;
    [SerializeField] private GameObject shopbutton;
    [SerializeField] private GameObject remusedbutton;
    [SerializeField] private GameObject menuebutton;
    [SerializeField] private GameObject boostbutton;
    private Vector3 offset;
    private GameObject clickstance;
    bool testmode = true;
    string GameID = "4412473";
    string VideoAdID = "Interstitial_Android";
    public int adtimer ;
    public int getadtimer;
    public bool adsison = false;
    public offthepost camer;
    public int graphicc;
    
    private void Start()
    {
        Advertisement.Initialize(GameID, testmode);
        camer= GameObject.Find("MainCamera").GetComponent<offthepost>();
    }
    public void displayvideosAd()
    {
        
        Advertisement.Show(VideoAdID);
    }
    public void Playgraphicsettings()
    {
        graphicpannel.SetActive(true);
        camer.postoff = true;
        
    }

    public void PlayGame()
    {
 
        scenetoconti = PlayerPrefs.GetInt("savedscene4");
       
        if (scenetoconti != 0)
        {
            SceneManager.LoadScene(scenetoconti+1);
         
            
        }
        else
        {
            SceneManager.LoadScene(1);
            
          
        }
   
    }
    private void Update()
    {
        offset = new Vector3(0, 0,-20); 
    }
    public void pausegame()
    {
        joystick.SetActive(false);
        pausebutton.SetActive(false);
        pausescreen.SetActive(true);
        boostbutton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void resumegame()
    {
        clickstance = Instantiate(clickpartical, remusedbutton.transform.position + offset, Quaternion.identity);
        Destroy(clickstance, 2);
        pausescreen.SetActive(false);
        joystick.SetActive(true);
        boostbutton.SetActive(true);
        pausebutton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void loadmenu()
    {
       
        clickstance = Instantiate(clickpartical, menuebutton.transform.position + offset, Quaternion.identity);
        Destroy(clickstance, 2);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
    }
    public void replay()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void shopopen()
    {
       
        clickstance =  Instantiate(clickpartical,shopbutton.transform.position + offset, Quaternion.identity);
        Destroy(clickstance, 2);
        SceneManager.LoadScene("SHOP");

    }
    public void levelspannel()
    {
        SceneManager.LoadScene("levels");
    }
    public void gameOver()
    {
        if(adsison == true)
        {
            displayvideosAd();
            adsison = false;
        }
    

        Invoke("gameoverison", 1.5f);

    }
    public void winningison()
    {
        winningPannel.SetActive(true);
     
        LoadNextLevel();

    }
    public void gameoverison()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(graphicpannel);
    }
  
    public void musicToggle()
    {
        clickstance =  Instantiate(clickpartical,soundbutton.transform.position+offset,Quaternion.identity);
        Destroy(clickstance, 2);
        if (backgroundmusic.bginstance.Audio.isPlaying)
        {
            backgroundmusic.bginstance.Audio.Pause();
        }
         else 
         {
            backgroundmusic.bginstance.Audio.Play();
         }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevels(SceneManager.GetActiveScene().buildIndex + 1));
      
    }
    IEnumerator Loadlevels(int levelindex)
    {
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene(levelindex);
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("savedscene4", currentsceneindex);
    }
    public void instagram()
    {
        Application.OpenURL("https://www.instagram.com/rykon09/");
    }
    public void youtube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCh4vZ982gtO1eKmgcBwcttw");
    }
    public void privacy()
    {
        Application.OpenURL("https://dataoptout-ui-prd.uca.cloud.unity3d.com/?token=gk9v0qe2au5eg2mn9sak0tane190eimakmv9ntq302fdhulk");
    }
    public void postison()
    {
        graphicc = 2;
        PlayerPrefs.SetInt("graphic", graphicc);
        graphicpannel.SetActive(false);
        PlayGame();
     
    }
    public void postisoff()
    {
        graphicc = 3;
        PlayerPrefs.SetInt("graphic", graphicc);
        graphicpannel.SetActive(false);
        PlayGame();
    }
    
}
                                                                                    