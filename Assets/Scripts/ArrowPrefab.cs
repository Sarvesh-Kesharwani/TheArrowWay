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


    }

    void OnCollisionEnter(Collision otherCollision)
    {
        if (otherCollision.gameObject.tag == "Wall")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Collided");
        }

    }
}