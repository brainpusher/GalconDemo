using Random = System.Random;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private ShipsController shipsController;
    [SerializeField] private WinController winController;
    
    private Random _random = new Random();
    
    private List<PlanetModel> _planetModels = new List<PlanetModel>();
    private List<PlanetModel> _clickedPlanets = new List<PlanetModel>();
    
    private static PlanetController _instance;
    public static PlanetController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PlanetController>();

            if (_instance == null)
                Debug.Log("There is no PlanetController!");

            return _instance;
        }
    }
    
    public void AddPlanet(PlanetModel planetModel)
    { 
        _planetModels.Add(planetModel);
    }

    private void Start()
    {
        FillPlanetsWithRandomValues();
        Subscribe();
        winController.CountOfPlanets = _planetModels.Count;
        MakeRandomPlanetActive();
    }

    private void FillPlanetsWithRandomValues()
    {
        foreach (var planetModel in _planetModels)
        {
            planetModel.GenerateRandomShipsCount(_random);
        }
    }

    private void MakeRandomPlanetActive()
    {
        int randomPlanetIndex = new Random().Next(0, _planetModels.Count);
        _planetModels[randomPlanetIndex].SetCountOfShipsForStartPlanet();
        _planetModels[randomPlanetIndex].SetPlanetActive(true);
    }

    private void Subscribe()
    {
        foreach (var planetModel in _planetModels)
        {
            planetModel.OnPlanetClicked += PlanetClick;
            planetModel.OnPlanetActivated += AddOneMoreActivePlanet;
        }
    }

    private void Unsubscribe()
    {
        foreach (var planetModel in _planetModels)
        {
            planetModel.OnPlanetClicked -= PlanetClick;
            planetModel.OnPlanetActivated -= AddOneMoreActivePlanet;
        }
    }

    private void AddOneMoreActivePlanet()
    {
        winController.AddActivatedPlanet();
    }

    private void PlanetClick(PlanetModel planetModel)
    {
        _clickedPlanets.Add(planetModel);

        if (_clickedPlanets.Count >= 2)
        {
            PlanetModel firstClickedPlanet = _clickedPlanets[0];
            PlanetModel secondClickedPlanet = _clickedPlanets[1];
            
            if (firstClickedPlanet.IsPlanetActive)
            {
                //проверка на клик по уже выбранной планете
                if (!firstClickedPlanet.Equals(secondClickedPlanet))
                {
                    firstClickedPlanet.RemoveShipsFromPlanet();
                    shipsController.SpawnAndSendShips(firstClickedPlanet, secondClickedPlanet);
                }
                RemoveOutlineFromPlanets();
            }
            else
                RemoveOutlineFromPlanets();
        }
    }

    public void RemoveOutlineFromPlanets()
    {
        if (_clickedPlanets.Count <= 0) return;
        
        foreach (PlanetModel clickedPlanet in _clickedPlanets)
        {
            clickedPlanet.RemoveOutline();
        }
        _clickedPlanets.Clear();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }
}
