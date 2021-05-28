using UnityEngine;

public class BackgroundClickChecker : MonoBehaviour
{
    [SerializeField] private PlanetController planetController;

    private void OnMouseDown()
    {
        planetController.RemoveOutlineFromPlanets();
    }
}
