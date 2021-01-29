using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpforce;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      winText.text = "";
    }

    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxis ("Horizontal");
      float moveVertical = Input.GetAxis ("Vertical");

      Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

      rb.AddForce (movement * 10);

      if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
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
     if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
