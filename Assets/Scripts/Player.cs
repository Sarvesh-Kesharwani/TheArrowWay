using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    void Update()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }




}
