using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void LoadInitialScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
