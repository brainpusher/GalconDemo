using System;
using Random = System.Random;
using UnityEngine;

public class PlanetModel : MonoBehaviour
{
    public event Action<PlanetModel> OnPlanetClicked = delegate {  };
    public event Action OnPlanetActivated = delegate {  };
    
    [SerializeField] private PlanetView planetView;

    [SerializeField] private int countOfShipsForStartPlanet = 50;
    [SerializeField] private int minShipsCount = 10;
    [SerializeField] private int maxShipsCount = 40;
    
    [SerializeField] private int amountOfShipsToAdd = 5;
    [SerializeField] private int delayAmount = 1;

    [SerializeField] private int amountOfShipsToSendDivider = 2;
    
    private int _planetShipsCount;
    private bool _isPlanetActive;
    private float _timer;
    private bool _onPlanetClicked;

    public bool IsPlanetActive => _isPlanetActive;

    private void Awake()
    {
        _isPlanetActive = false;
        _onPlanetClicked = false;
        PlanetController.Instance.AddPlanet(this);
    }

    private void Update()
    {
        if (_isPlanetActive)
            AddShipsAmountWithDelay();
    }

    public void SetCountOfShipsForStartPlanet()
    {
        _planetShipsCount = countOfShipsForStartPlanet;
        planetView.UpdateShipsCount(_planetShipsCount);
    }

    public void SetPlanetActive(bool status)
    {
        _isPlanetActive = status;
        if (status)
        {
            planetView.ChangePlanetToBlue();
            OnPlanetActivated?.Invoke();
        }
    }

    public void ShipArrived()
    {
        if (!_isPlanetActive)
        {
            _planetShipsCount -= 1;
            if (_planetShipsCount <= 0)
                SetPlanetActive(true);
        }
        else
            _planetShipsCount += 1;
        planetView.UpdateShipsCount(_planetShipsCount);
    }
    
    public void RemoveShipsFromPlanet()
    {
        _planetShipsCount -= _planetShipsCount / amountOfShipsToSendDivider;
        planetView.UpdateShipsCount(_planetShipsCount);
    }

    public int PlanetShipsCount => _planetShipsCount;

    public  void GenerateRandomShipsCount(Random random)
    {
        _planetShipsCount =  random.Next(minShipsCount, maxShipsCount);
        planetView.UpdateShipsCount(_planetShipsCount);
    }

    private void AddShipsAmountWithDelay()
    {
        _timer += Time.deltaTime;

        if (_timer >= delayAmount)
        {
            _timer = 0f;
            _planetShipsCount += amountOfShipsToAdd;
            planetView.UpdateShipsCount(_planetShipsCount);
        }
    }

    private void OnMouseEnter()
    {
        planetView.SetActiveOutline(true);
    }
    
    private void OnMouseExit()
    {
        if(!_onPlanetClicked)
            planetView.SetActiveOutline(false);
    }

    public void RemoveOutline()
    {
        planetView.SetActiveOutline(false);
        _onPlanetClicked = false;
    }

    private void OnMouseDown()
    {
        _onPlanetClicked = true;
        OnPlanetClicked?.Invoke(this);
    }
}
