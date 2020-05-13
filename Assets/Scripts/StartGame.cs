using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public void ScreenSwitching()
    {
        SceneManager.LoadScene("GameProcess");
    }

}
