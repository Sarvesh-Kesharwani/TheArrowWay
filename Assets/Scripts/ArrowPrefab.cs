using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{
    private CapsuleCollider2D collider;
    // private Rigidbody2D rigidbody2D;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        //  rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log("sfs");
        if (collider.IsTouchingLayers(LayerMask.GetMask("Walls")))
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            Debug.Log("Collided with wall!");
        }

    }


}