using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

   void Onmove(InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>();
   }
}
