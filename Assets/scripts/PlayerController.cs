using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Text countText;
    public Text winText;
    public float speed;
    private Rigidbody rb;
    private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    } 
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickups"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 8)
        {
            winText.text = "Win!";
        }
    }
}
