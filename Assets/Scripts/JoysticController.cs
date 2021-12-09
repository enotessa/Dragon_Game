using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticController : MonoBehaviour
{
    public GameObject touchMarker;
    Vector3 targetVector;
    public MovePlayer movePlayer;
    bool Flag = false;
    private Camera camera;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().material.color;
        camera = Camera.main;
        touchMarker.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        color.a = 0f;
        GetComponent<SpriteRenderer>().material.color = color;
        touchMarker.GetComponent<SpriteRenderer>().material.color = color;  

        //touchMarker.SetActive(false);
        if (Input.GetMouseButton(0))
        {
            color.a = 0.5f;
            GetComponent<SpriteRenderer>().material.color = color;
            touchMarker.GetComponent<SpriteRenderer>().material.color = color;

            Vector3 touchPos = camera.ScreenToWorldPoint(Input.mousePosition);
            touchPos = new Vector3(touchPos.x, touchPos.y, 0);
            if (!Flag)
            {
                transform.position = touchPos;
            }
            Flag = true;
            Debug.Log("touchPos : " + touchPos + "  targetVector : " + targetVector + "  transform.position : " + transform.position);
            targetVector = touchPos - transform.position;
            if (targetVector.magnitude<0.7)
            {
                //Debug.Log("targetVector.magnitude : "+ targetVector.magnitude);
                touchMarker.transform.position = touchPos;
                movePlayer.targetMove = targetVector;
            }
            else
            {
                touchMarker.transform.position = transform.position + (touchPos - transform.position).normalized * 0.7f;
                targetVector = touchMarker.transform.position - transform.position;
                movePlayer.targetMove = targetVector;
            }
        }
        else
        {
            //color.a = 50f;
            //transform.GetComponent<Renderer>().material.color = color;
            //touchMarker.GetComponent<Renderer>().material.color = color;

            Flag = false;
            touchMarker.transform.position = transform.position;
            movePlayer.targetMove = new Vector3(0,0,0);

        }
    }
}
