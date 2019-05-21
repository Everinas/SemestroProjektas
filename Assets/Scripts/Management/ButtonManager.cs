using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public EscMenuManager escMenu;
    public LevelRestart levelRestart;
    public Saving2 save;

    public void doRestartCurrentLevel()
    {
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
        save.Load();
        escMenu.Continue();
    }

    public void doSave()
    {
        save.Save();
        escMenu.Continue();
    }

    public void doStartNewGame()
    {
        SceneManager.LoadScene("HomeForest");
    }

    public void doGoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
