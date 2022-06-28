using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables

    [HideInInspector] public bool isGameStarted;

    [Header("GameObjects")]
    [SerializeField] AudioSource[] sound;
    [SerializeField] GameObject[] levelHolder;

    [Header("UI Panel")]
    [SerializeField] GameObject finishPanel;
    [SerializeField] Text levelText;
    [SerializeField] Text coinText;

    [Header(("Variables"))]
    int level;
    int coin;

    public GameObject MainCanvas;
    public GameObject FailCanvas;

    public int easy_tips = 10;
    public int hard_tips = 5;

    public static GameManager Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
    #endregion

    #region MonoBehaviour Callbacks


    private void Start()
    {
        // Application.targetFrameRate = 60;
        //  GetDatas();
        //  LevelGenerator();
    }

    #endregion

    #region GAME EVENTS
    // ---------- GAME EVENTS

    public void FinishLevel()
    {
        isGameStarted = false;
        sound[0].Play();
        StartCoroutine(FinishPanel());
        LevelUp();
    }

    public void GameOver()
    {
        isGameStarted = false;
        sound[1].Play();
        StartCoroutine(OverPanel());
    }

    IEnumerator FinishPanel()
    {
        yield return new WaitForSeconds(3f);
        finishPanel.SetActive(true);
        AddCoin(50);

    }

    IEnumerator OverPanel()
    {
        yield return new WaitForSeconds(3f);
       // gameOverPanel.SetActive(true);

    }
    #endregion

    #region SAVE AND LEVEL SETUP

    private void LevelGenerator()
    {
        int i = level - 1;
        //levelHolder[i].SetActive(true);
        coinText.text = coin.ToString();
        levelText.text = "LEVEL " + level.ToString();
    }

    private void LevelUp()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
    }

    public void SceneLoad(int number)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(number);
        Global.SceneNumber = number;
        //FindObjectOfType<AdManager>().ShowAdmobInterstitial();
    }

    public void GetDatas()
    {
        // LEVEL
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            level = 1;
        }

        // GEM
        if (PlayerPrefs.HasKey("coin"))
        {
            coin = PlayerPrefs.GetInt("coin");
        }
        else
        {
            PlayerPrefs.SetInt("coin", coin);
        }

        // SOUND
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
        }
    }

    public void AddCoin(int newCoin)
    {
        sound[2].Play();
        int prevCoin = PlayerPrefs.GetInt("coin");
        PlayerPrefs.SetInt("coin", prevCoin + newCoin);
        coin = newCoin;
        UpdateCoinText();
    }
    public void ExitApp()
    {
        Application.Quit();
    }
    private void UpdateCoinText()
    {
        coinText.text = coin.ToString();
    }

    #endregion

    #region UI SETUP
    // ---------- UI BUTTON
    public void StartButton()
    {
        isGameStarted = true;
      //  menuPanel.SetActive(false);
     //   gamePanel.SetActive(true);

    }

    public void OpenURLButton(string link)
    {
        Application.OpenURL(link);
    }


    public void RestartButton()
    {
        SceneLoad(0);
    }

    public void toReturn(){
        // print(Global.SceneNumber);
        if(Global.SceneNumber == 2){
            Time.timeScale = 1;
            CenterLineSimulation.Instance.easy_tips = Global.easy;
            SceneLoad(2);
        } else if(Global.SceneNumber == 3){
            Time.timeScale = 1;
            CenterLineSimulation.Instance.hard_tips = Global.hard;
            SceneLoad(3);
        } else if(Global.SceneNumber == 4){
            Time.timeScale = 1;
            MainCanvas.SetActive(true);
            FailCanvas.SetActive(false);
        }
    }

    #endregion

}