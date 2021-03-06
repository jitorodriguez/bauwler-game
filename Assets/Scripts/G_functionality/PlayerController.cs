using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public Text countText;
	public Text winText;
	public Text timerLabel;
	public float speed;
	public float jumpHeight;
	public GameObject mini;
	private float timer;
	private Rigidbody rb;
	private int count;
	private bool isGrounded;
	private bool isFlat;

	void Start ()
    {
		rb = GetComponent<Rigidbody> ();  //Goes to RigidBody Component of Player object to gain access to the Rigidbody properties of the Player object.
		count = 0;
		SetCountText ();
		winText.text = "";
		isGrounded = true;
		isFlat = false;
	}
	
	// Update is called once per frame
	void Update () //Before each frame
    {
		timer += Time.deltaTime;

		var minutes = timer / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = timer % 60; //Use the euclidean division for the seconds.
		var fraction = (timer * 100) % 100;

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
		
	}

    void FixedUpdate() //For physics code
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (Input.GetKeyDown("space") && isGrounded){  //Checks if player object is on ground and if the surface
			rb.AddForce (Vector3.up * jumpHeight);
		}

	
    }

	void OnTriggerEnter(Collider other) //Event where Rigbody makes contact with another RigBody.
	{
		if (other.gameObject.CompareTag("Ding"))  //Compares tag of the collided object with string
		{
				other.gameObject.SetActive(false);	//Deactivates "other" object to disappear from scene
				count = count + 1;
				SetCountText ();
		}
				
	}

	void SetCountText()
	{
		countText.text = "Cubes: " + count.ToString ();
		if (count >= 18) {
			winText.text = "Bruh, you won!";
			//Comence explosion and split function
			for (int i = 0; i < 10; i++) {
				Instantiate(mini, new Vector3(rb.position.x, 1, rb.position.z), Quaternion.identity);
			}

		}
	}


	void OnCollisionStay(Collision coll){

		isGrounded = true;

		if (coll.gameObject.CompareTag ("Wall")) 
		{  //Compares tag of the collided object with string
			isGrounded = false;
		} 

	}
	void OnCollisionExit(Collision coll){
		if(isGrounded){
			isGrounded = false;   
		}
	}


	/*void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.normal.y >= 0.6)
		{
			isFlat = true;
		}
		else
		{
			isFlat = false;
		}


	}
	*/
}
//Destroy(other.gameObject);
//if (other.gameObject.CompareTag("Player"))
//gameObject.SetActive(false);

/*if (!coll.gameObject.CompareTag ("Wall")) 
{  //Compares tag of the collided object with string
	isGrounded = true;
} */