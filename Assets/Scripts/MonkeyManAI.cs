using UnityEngine;

public class MonkeyManAI : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
	
	public Transform core;

    public float JumpableHeight = 0f;
    private Vector2 VectorDistance;
    private float MagnitudeDistance = 0f;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }


  void OnTriggerEnter2D(Collider2D CollidedArrow)
    {
        if (CollidedArrow.gameObject.tag == "ArrowInstance")
        {
            VectorDistance = new Vector2(CollidedArrow.transform.position.x - core.transform.position.x,
                CollidedArrow.transform.position.y - core.transform.position.y);
            MagnitudeDistance = VectorDistance.magnitude;

            if (MagnitudeDistance <= JumpableHeight)
            {
                Debug.Log("Jump");
            }
        }
    }
}
