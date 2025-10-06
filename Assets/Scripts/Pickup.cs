using UnityEngine;

public class Pickup : MonoBehaviour
{
   

    
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
