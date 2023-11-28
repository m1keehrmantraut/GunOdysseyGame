using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public UnityEvent OnLose;
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject ShopPanel;
    
    [SerializeField] private AudioMixerGroup Mixer;

    public bool isOnRightPlace;
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenLosePanel()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        OnLose.Invoke();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        if (isOnRightPlace)
        {
            ShopPanel.SetActive(true);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-50, 0, volume));
    }
    
    public void ChangeEffectsVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-50, 0, volume));
    }
}