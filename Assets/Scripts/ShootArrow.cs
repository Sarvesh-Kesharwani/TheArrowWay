using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject ArrowPrefab;
    private Vector3 touchPosition;
    private float ArrowSpeed = 10;

    void Update()
    {
        GetTouchPosition();
        Aim();
    }

    void GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                touchPosition.z = 0f;
                SpawnArrowInstance();
            }

        }
    }

    void SpawnArrowInstance()
    {
        GameObject ArrowInstance = Instantiate(ArrowPrefab) as GameObject;
        ArrowInstance.transform.position = touchPosition;
        // ArrowInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f) * ArrowSpeed;
        ArrowInstance.transform.position = touchPosition;
        GameObject.Destroy(ArrowInstance, 5);


    }

    void Aim()
    {

    }


}
