using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button restartLevelButton;

    private void Awake()
    {
        restartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
