using UnityEngine;
using System.Collections;

public class PlatformMove : MonoBehaviour {

	private Vector3 startPosition;
	private bool setter;
	//Collider collider = GetComponent<Collider>();

	// Use this for initialization
	void Start () {
		
		startPosition = transform.position;
		setter = true;
		//collider.Equals (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((transform.position.y - startPosition.y) > 1.5f) {
			setter = false;
		} 
		else if (transform.position.y - startPosition.y <= 0) 
		{
			setter = true;
		}

		if(setter) 
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);
		} 
		else 
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.01f, transform.position.z);
		}
			
	}
		
}
