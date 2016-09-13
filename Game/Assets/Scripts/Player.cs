using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Transform m_left_foot;
	public Transform m_right_foot;
	public float m_hops = 8.0f;
	public float m_speed = 5.0f;
	public float m_weight = 1.0f;

	private Rigidbody2D m_player;
	private bool grounded = false;
	private Vector2 m_move;

	// Use this for initialization
	void Start ()
	{
		m_player = GetComponent<Rigidbody2D> (); 
		m_move = new Vector2(0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update ()
	{
	}

	void FixedUpdate ()
	{
		if (!grounded) {
			grounded = Physics2D.Linecast (m_left_foot.position, m_right_foot.position, LayerMask.GetMask ("Default"));
		}
		if (grounded) {
			movement ();
			if (Input.GetKeyDown ("w")) {
				grounded = false;
				m_player.AddForce ((Vector2.up * m_hops), ForceMode2D.Impulse);
			}
		} else {
			airdrift ();
		}
	}

	private void movement ()
	{
		m_move.x = 0.0f;
		if (Input.GetKey ("d"))
		{
			m_move.x = m_speed;
		}
		if (Input.GetKey ("a"))
		{
			m_move.x -= m_speed;
		}
		m_player.velocity = m_move;
	}

	private void airdrift ()
	{
		Vector2 velocity_vect = m_player.velocity;
		velocity_vect.x = 0.0f;
		if (Input.GetKey ("d"))
		{
			velocity_vect.x = (5.0f / m_weight);
		}
		if (Input.GetKey ("a"))
		{
			velocity_vect.x -= (5.0f / m_weight);
		}
		m_player.velocity = velocity_vect;
	}
}