using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

    [HideInInspector] public bool jump = false;
    public float maxSpeed = 5f;
    public float moveForce = 365f;
    public float jumpForce = 500f;
    public Transform groundCheck;

    private Rigidbody2D rbody2d;
    private bool grounded = false;

    void Awake() {
        rbody2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update() {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << (LayerMask.NameToLayer("Ground")));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    
	void FixedUpdate () {

        float h = Input.GetAxis("Horizontal");

        if (h * rbody2d.velocity.x < maxSpeed)
            rbody2d.AddForce(Vector2.right * h * moveForce);
        if (h == 0)
            rbody2d.AddForce(new Vector2((-.5f) * rbody2d.velocity.x, 0));

        if (Mathf.Abs(rbody2d.velocity.x) > maxSpeed)
            rbody2d.velocity = new Vector2(Mathf.Sign(rbody2d.velocity.x) * maxSpeed, rbody2d.velocity.y);

        if (jump)
        {
            rbody2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
