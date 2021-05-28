using UnityEngine;

public class WinController : MonoBehaviour
{
    [SerializeField] private WinView winView;
    
    private int _countOfPlanets;
    private int _countOfActivatedPlanets = 0;

    public int CountOfPlanets
    {
        get => _countOfPlanets;
        set => _countOfPlanets = value;
    }

    public void AddActivatedPlanet()
    {
        _countOfActivatedPlanets++;
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (_countOfPlanets == _countOfActivatedPlanets)
        {
            winView.SetActiveWinPanel(true);
        }
    }
}
