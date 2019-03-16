using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{

    private Collider2D collider2D;


    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        StabWall();
    }

    void Update()
    {

    }

    void StabWall()
    {
        if (collider2D.IsTouchingLayers(LayerMask.GetMask("Walls")))
        {
            Debug.Log("Collided With Wall");
        }
    }
}
