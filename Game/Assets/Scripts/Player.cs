using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D m_player_body;
	[SerializeField]
	private float m_speed = 10;

	// Use this for initialization
	private void Start () {
		m_player_body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	private void Update () {
		GetInput ();
	}

	private void GetInput () {
		float horizontal_move = Input.GetAxis ("Horizontal") * m_speed;
		m_player_body.AddForce (Vector3.right * horizontal_move);
	}
}
