using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void LoadScene(string name)
    {
        Debug.Log($"Loading scene: {name}");
        SceneManager.LoadScene(name);
    }
}
