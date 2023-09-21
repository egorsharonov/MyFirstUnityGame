using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject winPanel;
    public static GameInterface Instance { get; private set; }
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        menu.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex==0)
            AudioManager.instance.Play("MainMenu");
    }

    public void onClickExitGame() => Application.Quit();
    public void onClickChangeLevel(Button btn)
    {
        AudioManager.instance.Stop("MainMenu");
        SceneManager.LoadScene(btn.name);
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex!=0)
            switchMenu(menu);
    }
    private void PauseGame(bool isPause)
    {
        Time.timeScale = (isPause) ? 0 : 1f;
        // get player and close components
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerStats>().DisableMovement(isPause);
    }
    public void switchMenu(GameObject menu)
    {
        bool isPause = menu.activeSelf;

        menu.SetActive(!isPause);
        Cursor.visible = !isPause;
        PauseGame(!isPause);

    }
    public void onClickNext() {
        switchMenu(winPanel);
        SceneManager.LoadScene(Mathf.Min(SceneManager.GetActiveScene().buildIndex + 1, SceneManager.sceneCountInBuildSettings - 1));
    }
    public void onClickReturnToMainMenu()
    {
        AudioManager.instance.Stop("Ambient");
        PauseGame(false);
        SceneManager.LoadScene(0);
    }
    public void onClickReloadLevel()
    {
        switchMenu(menu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowWinPanel()
    {
        switchMenu(winPanel);
    }
}
