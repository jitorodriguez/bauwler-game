using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position; //Find initial offset of where the camera is in respect to the player object
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset; //Updates camera position so that it is always folowing position of player object.
		//We use LateUpdate () because it runs after all the processes of every frame have computed.
	}
}
