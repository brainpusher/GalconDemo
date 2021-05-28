using Random = UnityEngine.Random;
using TMPro;
using UnityEngine;

public class PlanetView : MonoBehaviour
{
    [Header("Planet visual settings")]
    [SerializeField] private TextMeshPro shipsCountText;
    [SerializeField] private GameObject planetOutline;
    [SerializeField] private Material bluePlanetMaterial;
    [SerializeField] private SpriteRenderer planetSpriteRenderer;
    
    [Header("Planet size settings")]
    [SerializeField] private Transform planetTransform;
    [SerializeField] private float minPlanetSize = 0.6f;
    [SerializeField] private float maxPlanetSize = 1f;

    private void Awake()
    {
        float randomSize = Random.Range(minPlanetSize,maxPlanetSize);
        Vector3 newScale = new Vector3(randomSize, randomSize, planetTransform.localScale.z);
        planetTransform.localScale = newScale;
    }

    public void UpdateShipsCount(int shipsCount)
    {
        shipsCountText.text = shipsCount.ToString();
    }

    public void SetActiveOutline(bool status)
    {
        planetOutline.SetActive(status);
    }

    public void ChangePlanetToBlue()
    {
        planetSpriteRenderer.material = bluePlanetMaterial;
    }
}
