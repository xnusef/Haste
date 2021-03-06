using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        LevelManager.lM.StartAnim(SceneManager.GetActiveScene().buildIndex + 1, true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlaySound(string sound)
    {
        AudioManager.aM.Play(sound);
    }
    public void Credits()
    {
        LevelManager.lM.StartAnim(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Cutscenes/Credits.unity"), true);
    }
}
