using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{
    private CapsuleCollider2D collider;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Walls")))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Collided with wall!");
        }

    }


}