using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public EscMenuManager escMenu;
    public LevelRestart levelRestart;

    public void doRestartCurrentLevel()
    {
        escMenu.Continue();
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
}
