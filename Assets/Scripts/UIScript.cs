using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private int _levelToLoad;
    // Start is called before the first frame update
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Continue()
    {
        if (PlayerPrefs.HasKey("LastLevel"))
        {
            _levelToLoad = PlayerPrefs.GetInt("LastLevel");
            SceneManager.LoadScene(_levelToLoad);
        }
        else
        {
            PlayGame();
        }
    }
}
