using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector3 mousePos, transPos, targetPos;
    float test;

    void Update()
    {
        CalTargetPos();

        MoveToTarget();
    }

    void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        mousePos.z = mousePos.y;
        mousePos.y = 5;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(-transPos.x, 5, -transPos.z);
        
    }

    void MoveToTarget()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        transform.position = targetPos;
    }
}