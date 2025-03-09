using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string nextScene;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(nextScene);
    }
}
