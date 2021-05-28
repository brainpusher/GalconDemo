using UnityEngine;

//TODO: дописать данный класс, когда пойму как реализовать смещение планет при инстанциировании
public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private GameObject planetPrefab;
    [SerializeField] private int countOfPlanetsToSpawn = 10;
    
    private void Awake()
    {
        for (int i = 0; i < countOfPlanetsToSpawn; i++)
        {
         //   float spawnY = Random.Range
             //   (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
           // float spawnX = Random.Range
              //  (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
              float min = 0.2f;
              float max = 0.8f;
              Vector3 final = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(min, max), Random.Range(min, max), 1));
              Vector2 instantiatePosition = final;
            Instantiate(planetPrefab, final, Quaternion.identity, spawnPosition.transform);
        }
    }
}
