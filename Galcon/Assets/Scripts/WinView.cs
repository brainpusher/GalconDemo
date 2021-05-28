using UnityEngine;

public class WinView : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        SetActiveWinPanel(false);
    }

    public void SetActiveWinPanel(bool status)
    {
        winPanel.SetActive(status);
    }
}
