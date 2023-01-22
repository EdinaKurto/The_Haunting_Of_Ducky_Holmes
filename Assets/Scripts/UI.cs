using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public string GameScene = "Testing Scene";
    public string MainMenuScene = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UserChoice(string choice)
    {
        switch (choice)
        {
            case "quit":
                SceneManager.LoadScene(MainMenuScene);
                break;
            case "retry":
                SceneManager.LoadScene(GameScene);
                break;
        }

    }
}
