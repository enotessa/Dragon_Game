using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    private float xMin, xMax, yMin, yMax;


    // Start is called before the first frame update
    void Start()
    {
        MoveBorders();
    }

    public Transform player;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float padding = 0.55f;
    private float lastPosX = float.NaN;
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.Clamp(mousePos.x, xMin, xMax);
        mousePos.y = Mathf.Clamp(mousePos.y, yMin, yMax);

        player.rotation = player.position.x < lastPosX ? Quaternion.Euler(0, -107, 0) : player.position.x > lastPosX ? Quaternion.Euler(0, 107, 0) : player.rotation;

        lastPosX = player.position.x;
        player.position = Vector2.MoveTowards(player.position,
                                                new Vector2(mousePos.x, mousePos.y),
                                                speed * Time.deltaTime);
    }

    private void MoveBorders()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

}
