using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync("lxz", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("zy", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("lyk", LoadSceneMode.Additive);
    }
}
