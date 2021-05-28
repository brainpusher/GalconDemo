using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsController : MonoBehaviour
{
    [SerializeField] private ShipModel shipModel;
    [SerializeField] private GameObject spawnPosition;
    
    public void SpawnAndSendShips(PlanetModel firstCLickedPlanet, PlanetModel secondClickedPlanet)
    {
        int amountToSend = firstCLickedPlanet.PlanetShipsCount;

        Vector3 planetCenter = firstCLickedPlanet.transform.position;
        for (int i = 0; i < amountToSend; i++)
        {
            Vector3 instantiatePosition = RandomCirclePosition(planetCenter, firstCLickedPlanet.transform.localScale.x);

            StartCoroutine(InstantiateShipWithDelay(instantiatePosition,secondClickedPlanet,0.1f));
        }
    }

    private IEnumerator InstantiateShipWithDelay(Vector3 instantiatePosition,PlanetModel secondClickedPlanet,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        ShipModel shipInstance = Instantiate(shipModel, instantiatePosition, Quaternion.identity, spawnPosition.transform);
        shipInstance.StartMovement(secondClickedPlanet);
    }
    
    Vector3 RandomCirclePosition( Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 position;
        position.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        position.z = center.z;
        return position;
    }

}
