using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        //Set rotation speed for coins
        transform.Rotate(new Vector3(0f, 0f, 1f));
        
    }
}
