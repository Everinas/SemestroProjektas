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

    public void doSave()
    {
        save.Save();
        escMenu.Continue();
    }

    public void doLoadContinue()
    {
        SceneManager.LoadScene("HomeForest");
        save.Load();
    }

    public void doStartNewGame()
    {
        gameCompleteMenu.SetActive(false);
        SceneManager.LoadScene("HomeForest");
    }

    public void doGoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
