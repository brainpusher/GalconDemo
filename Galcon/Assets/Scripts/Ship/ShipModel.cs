using System.Collections;
using UnityEngine;

public class ShipModel : MonoBehaviour
{
    private PlanetModel _destinationPlanet;
    
    public void StartMovement(PlanetModel moveToPlanet)
    {
        _destinationPlanet = moveToPlanet;
        Vector3 pointToMove = moveToPlanet.transform.position;// - moveToPlanet.transform.localScale / 2f;
        Transform lookAt = moveToPlanet.transform;

        StartCoroutine(MovementRoutine(pointToMove,lookAt));
    }

    private IEnumerator MovementRoutine(Vector3 moveTo, Transform lookAt)
    {
        while (Vector3.Distance(this.transform.position,moveTo)>Time.deltaTime)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, moveTo, Time.deltaTime);
            
            float yPosition = lookAt.position.y - transform.position.y;
            float xPosition = lookAt.position.x - transform.position.x;
            float zRotation = Mathf.Atan2(yPosition, xPosition) * Mathf.Rad2Deg - 90;
            
            transform.eulerAngles = new Vector3(0,0,zRotation);
            yield return null;
        }
        transform.position = moveTo;
        _destinationPlanet.ShipArrived();
        Destroy(gameObject);
    }
    
}
