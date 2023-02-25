using UnityEngine.SceneManagement;

public class UI : SingletonBehaviour<UI>
{
    public string GameScene = "Testing Scene";
    public string MainMenuScene = "MainMenu";

    public void UserChoice(string choice)
    {
        switch (choice)
        {
            case "quit":
                SceneManager.LoadScene(MainMenuScene);
                break;
            case "retry":
                PlayerManager.Instance.Respawn();
                break;
        }

    }
}
