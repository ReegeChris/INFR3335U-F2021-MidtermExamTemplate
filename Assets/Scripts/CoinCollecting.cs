using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    //Counter that increments when coins are picked up
    private int coinCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set rotation speed for coins
        transform.Rotate(new Vector3(0f, 0f, 1f));
        
    }
}
