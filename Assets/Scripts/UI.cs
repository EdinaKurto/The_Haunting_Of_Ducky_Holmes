using UnityEngine;

public class UI : SingletonBehaviour<UI>
{
    public GameObject GameOverMenu;

    public void InitGameOver()
    {
        GameOverMenu.SetActive(true);
    }

    public void UserChoice(string choice)
    {
        switch (choice)
        {
            case "quit":
                GameHandler.Instance.MainMenu();
                break;
            case "retry":
                GameHandler.Instance.Respawn();
                break;
        }

    }
}
