using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    private float xMin, xMax, yMin, yMax;
    public Transform player;
    public Transform playerRotation;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float padding = 0.55f;
    private float lastPosX = float.NaN;
    public Vector3 targetMove;  // направление движения

    void Start()
    {
        MoveBorders();
    }
    private void Update()
    {
        playerRotation.rotation = player.position.x < lastPosX ? Quaternion.Euler(0, -107, 0) : player.position.x > lastPosX ? Quaternion.Euler(0, 107, 0) : playerRotation.rotation;
        lastPosX = player.position.x;

        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), Mathf.Clamp(player.transform.position.y, yMin, yMax), player.transform.position.z);
        player.transform.Translate(targetMove * speed * Time.deltaTime);
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
