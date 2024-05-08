using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] protected GameSO player;
    public GameSO Player { get { return player; } }

    private void Awake()
    {
        GameManager.instance = this;
        player.Initialize();
        GetData();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("AcceptTerms", player.accept ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", player.volume);
    }
    public void GetData()
    {
        int accept = PlayerPrefs.GetInt("AcceptTerms");
        if (accept == 1) player.accept = true;
        else player.accept = false;

        if (player.accept)
        {
            player.volume = PlayerPrefs.GetFloat("Volume");
        }

    }
    IEnumerator LoadSceneMainGame()
    {
        yield return new WaitForSeconds(0.5f);
        Save();
        OpenScene("MainScene");
    }

    IEnumerator LoadSceneStart()
    {
        yield return new WaitForSeconds(0.5f);
        Save();
        OpenScene("Start");
    }

    void OnApplicationQuit()
    {
        Save();
    }

    public void BtnPause()
    {
        AudioManager.Instance.PlaySFX("Click");
             
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ResultsController.Instance.UI.PauseGame();
            UIManagerMainScene.Instance.ChangeSpriteButtonPause();
        }
        else
        {
            Time.timeScale = 1;
            ResultsController.Instance.UI.PauseGame();
            UIManagerMainScene.Instance.ChangeSpriteButtonPause();

        }
    }

    public void BtnReplay()
    {
        AudioManager.Instance.PlaySFX("Click");
        PlayerController.Instance.StartGame();
        UIManagerMainScene.Instance.HideUI();
    }
    public void BtnVolume()
    {
        AudioManager.Instance.PlaySFX("Click");
        if (player.volume != 0) player.volume = 0;
        else player.volume = 0.5f;
        UIManagerMainScene.Instance.ChangeSpriteButtonVolume(player.volume);

    }
    public void BtnAccept()
    {
        AudioManager.Instance.PlaySFX("Click");
        Player.accept = true;
        UIManagerStartScene.Instance.HideTerm();
    }

    public void BtnPlay()
    {
        AudioManager.Instance.PlaySFX("Click");
        StartCoroutine(LoadSceneMainGame());
    }
    public void BtnSearch()
    {
        AudioManager.Instance.PlaySFX("Click");
        PlayerController.Instance.PlayerSearch();
    }
    public void UpdateData()
    {
        Save();
    }
    public static void OpenScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
