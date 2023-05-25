using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon2: MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public float launchforce;
    public Sprite Chargé;
    public Sprite pas_chargé;
    public SpriteRenderer render;


    private Vector2 startingPoint;
    private int leftTouch = 99;

    private float timeBtwShots;
    public float startTimeBtwShots;

    int TapCount;
    public float MaxDubbleTapTime;
    float NewTime;
    // Start is called before the first frame update
    void Start()
    {
        TapCount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 2)
                {
                    if (timeBtwShots <= 0)
                    {
                        render.sprite = Chargé;

                        if (Input.GetMouseButtonDown(0))
                        {
                            GameObject newProj = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                            newProj.GetComponent<Rigidbody2D>().velocity = transform.right * launchforce;
                            timeBtwShots = startTimeBtwShots;
                            render.sprite = pas_chargé;
                        }

                    }
                    else
                    {
                        timeBtwShots -= Time.deltaTime;
                    }
                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);



            }
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;

            }
            ++i;
        }

    }
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

   
}

