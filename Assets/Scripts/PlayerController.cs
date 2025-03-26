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
     public GameObject winTextObject;

     public float leap = 5;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      winTextObject.SetActive(false);
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
    if(count >= 12)
    {
      winTextObject.SetActive(true);

      Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }
   }
   void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

        {
            if (Input.GetKeyDown ("space") && GetComponent<Rigidbody>().transform.position.y <= 0.6250001f) {
                Vector3 jump = new Vector3 (0.0f, 200.0f*leap, 0.0f);

                GetComponent<Rigidbody>().AddForce (jump);
            }
        }

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
private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}
}
