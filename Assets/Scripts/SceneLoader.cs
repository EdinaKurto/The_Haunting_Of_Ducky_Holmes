using UnityEngine.SceneManagement;

public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
