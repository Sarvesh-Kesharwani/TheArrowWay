using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject ArrowPrefab;
    private GameObject ArrowInstance;

    private Vector3 touchPosition;
    private Vector3 InitialTouchPosition;


    public float turnSpeed = 10f;
    public float moveSpeed = 100f;
    public float AimSenstivity = 5;
    private bool arrowReleased = false;



    void Start()
    {
    }

    void Update()
    {
        GetTouchPosition();
        SpawnArrowInstance();

    }

    void GetTouchPosition()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            if (touch.phase == TouchPhase.Began)
            {
                InitialTouchPosition = touchPosition;

                ArrowInstance = Instantiate(ArrowPrefab) as GameObject;
                ArrowInstance.transform.position = touchPosition;
                arrowReleased = false;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Aim();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                arrowReleased = true;
            }
        }

    }

    void SpawnArrowInstance()
    {
        if (arrowReleased == true)
            ArrowInstance.transform.Translate(new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime);


    }

    void Aim()
    {
        var offset = new Vector2(touchPosition.x - ArrowInstance.transform.position.x,
                               touchPosition.y - ArrowInstance.transform.position.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg * AimSenstivity;
        ArrowInstance.transform.rotation = Quaternion.Euler(0, 0, angle);
        // ArrowInstance.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }


}
