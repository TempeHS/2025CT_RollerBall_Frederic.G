using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
     private Rigidbody rb; 
     private int count;
     private float movementX;
     private float movementY;
     public float speed = 0;
     public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
    }

   void OnMove(InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
   }
   
   
   void SetCountText()
   {
    countText.text =  "Count: " + count.ToString();
   }
   private void FixedUpdate()
   {
     Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
     rb.AddForce(movement*speed);
   }
   private void OnTriggerEnter(Collider other)
   {
    if(other.gameObject.CompareTag("Pickup"))
    {
      other.gameObject.SetActive(false);
      count = count + 1;
      SetCountText();
    }
    
   }

}
