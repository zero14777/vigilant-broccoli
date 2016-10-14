using UnityEngine;
using System;
using System.Collections;

public class Player : Unit
{
	public Transform m_left_foot;
	public Transform m_right_foot;
	public float m_hops = 8.0f;
	public float m_speed = 5.0f;

	private Rigidbody2D m_player;
	// Use this for initialization
	void Start ()
	{
		m_player = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
	}

	void FixedUpdate ()
	{
		movement ();
	}

	private bool grounded () {
		return Physics2D.Linecast (m_left_foot.position, m_right_foot.position, LayerMask.GetMask ("Default"));
	}

	private void movement ()
	{
		if (Input.GetKeyDown ("w") && grounded ()) {
			m_player.AddForce ((Vector2.up * m_hops), ForceMode2D.Impulse);
		}
		Vector2 velocity_vect = m_player.velocity;
		velocity_vect.x = 0.0f;
		if (Input.GetKey ("d"))
		{
			velocity_vect.x = (5.0f);
		}
		if (Input.GetKey ("a"))
		{
			velocity_vect.x -= (5.0f);
		}
		m_player.velocity = velocity_vect;
	}
}