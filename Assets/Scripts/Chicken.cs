using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    //private float xMin, xMax, yMin, yMax;
    //private float padding = 1f;
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    MoveBorders();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    var newPosX = Mathf.Clamp(transform.position.x, xMin, xMax);
    //    var newPosY = Mathf.Clamp(transform.position.y, yMin, yMax);
    //    transform.position = new Vector2(newPosX, newPosY);
    //}
    //
    //private void MoveBorders()
    //{
    //    Camera gameCamera = Camera.main;
    //    xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
    //    xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    //    yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
    //    yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    //}
}
