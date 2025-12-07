using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void BlackJack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BlackJack");
    }    
    public void PlusAndLess()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlusAndLess");
    }    
    public void JackPot()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JackPot");
    }    
    public void Slot()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Slot");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
