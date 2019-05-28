using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public EscMenuManager escMenu;
    public GameObject gameOverMenu;
    public GameObject gameCompleteMenu;
    public LevelRestart levelRestart;
    public Saving2 save;

    public void doRestartCurrentLevel()
    {
        gameOverMenu.SetActive(false);
        gameCompleteMenu.SetActive(false);
        levelRestart.doRestartCurrentLevel();       
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    public void doContinue()
    {
        escMenu.Continue();
    }

    public void doLoad()
    {
        gameOverMenu.SetActive(false);
        gameCompleteMenu.SetActive(false);
        save.Load();       
        escMenu.Continue();      
    }
    public void deathLoad()
    {
        MainMenuLoading.loading = true;
        SceneManager.LoadScene("HomeForest");

    }
    public void doSave()
    {
        save.Save();
        escMenu.Continue();
    }

    public void doLoadContinue()
    {
        SceneManager.LoadScene("HomeForest");
        
    }
    public void mainMenuContinue()
    {
        MainMenuLoading.loading = true;
        SceneManager.LoadScene("HomeForest");
    }
    public void doStartNewGame()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu"){
            SceneManager.LoadScene("HomeForest");
        }
        else{
            gameCompleteMenu.SetActive(false);
            SceneManager.LoadScene("HomeForest");
        }       
    }

    public void doGoToMainMenu()
    {
        MainMenuLoading.loading = false;
        SceneManager.LoadScene("MainMenu");
    }
}
