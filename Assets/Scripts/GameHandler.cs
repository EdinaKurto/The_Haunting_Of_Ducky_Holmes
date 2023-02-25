using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class GameHandler : SingletonBehaviour<GameHandler>
{
    PlayerManager PlayerManager;
    UI UI;

    public string MainMenuScene;

    public bool HasReachedCheckPoint;
    public Transform CheckpointSpawnPivot;
    public Transform DefaultSpawnPivot;

    public VideoPlayer VideoPlayer;

    void Start()
    {
        UI = UI.Instance;
        PlayerManager = PlayerManager.Instance;
    }

    public void OnCaught()
    {
        UI.Instance.InitGameOver();
    }

    public void Respawn()
    {
        PlayerManager.gameObject.transform.position = HasReachedCheckPoint ? CheckpointSpawnPivot.position : DefaultSpawnPivot.position;
        PlayerManager.Out();
    }

    public void MainMenu()
    {
        SceneLoader.Instance.LoadScene(MainMenuScene);
    }

    public void OnCheckpointReach()
    {
        HasReachedCheckPoint = true;
    }

    public void OnEndReach()
    {
        VideoPlayer.gameObject.SetActive(true);
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        VideoPlayer.Play();
        yield return new WaitForSeconds(2);
        yield return new WaitUntil(() => !VideoPlayer.isPlaying);

        SceneLoader.Instance.LoadScene(MainMenuScene);
    }
}
