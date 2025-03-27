using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
   void Start()
    {
 // Calculate the initial offset between the camera's position and the player's position.
       
    }

 // LateUpdate is called once per frame after all Update functions have been completed.
 void Update()
    {
 // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position;  
    }

}
