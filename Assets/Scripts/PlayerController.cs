using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
    }

    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxis ("Horizontal");
      float moveVertical = Input.GetAxis ("Vertical");

      Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

      rb.AddForce (movement * 10);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Pickup")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText () 
    {
     countText.text = "Count: " + count.ToString();
    }
}
