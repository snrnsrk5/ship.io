using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player; // 바라볼 플레이어 오브젝트입니다.
    [SerializeField] float distance = -50;

    ///public float rotationSpeed = 0.01f;
    public float SmoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] int toggleView = 1;

    private float wheelspeed= 100.0f;
    [SerializeField] int maxZoom;
    [SerializeField] int minZoom;
    int zoomLocal;
    float mouse;

    // Update is called once per frame
    //void Update()
    //    //마우스 우클릭 중에만 카메라 무빙 적용
    //     if (Input.GetMouseButton(1))
    //     {
    //        // xmove += Input.GetAxis("Mouse X");
    //         //ymove -= Input.GetAxis("Mouse Y");
    //     }
    //     transform.rotation = Quaternion.Euler(90, xmove, 0);
    //     //transform.Translate(new Vector3(xmove, -ymove, 0));
        
    //     if (Input.GetKeyDown(KeyCode.LeftShift))
    //         toggleView = 4 - toggleView;

    //     if (toggleView == 3)
    //     {
    //         distance += Input.GetAxis("Mouse ScrollWheel") * wheelspeed;
    //         if (distance < -500f) distance = -500f;
    //         if (distance > -10f) distance = -10f;
    //     }

    //     if (toggleView == 1)
    //     {
    //         Vector3 reverseDistance = new Vector3(0.0f, 0.0f, -1000f);
    //         transform.position = player.transform.position + transform.rotation * reverseDistance;
    //     }
    //     else if (toggleView == 3)
    //     {
    //         Vector3 reverseDistance = new Vector3(0.0f, 0.0f,-distance );
    //         transform.position = Vector3.SmoothDamp(transform.position,player.transform.position - transform.rotation * reverseDistance,ref velocity,SmoothTime);
    //     }
    // }
    void Update(){
        transform.rotation = Quaternion.Euler(90, 0, 0);

        if (distance < maxZoom) distance = maxZoom;
        if (distance > minZoom) distance = minZoom;

        if (Input.GetKeyDown(KeyCode.LeftShift)) toggleView = 4 - toggleView;
        mouse = Input.GetAxis("Mouse ScrollWheel");
        distance += mouse * wheelspeed;

        if (toggleView == 1){
            Vector3 reverseDistance = new Vector3(0.0f, 0.0f,-distance);

            transform.position = Vector3.SmoothDamp(transform.position,
                                player.transform.position - transform.rotation * reverseDistance,
                                ref velocity,SmoothTime);
        }

        if (toggleView == 3){
            Vector3 reverseDistance = new Vector3(0.0f, 0.0f,maxZoom);

            transform.position = Vector3.SmoothDamp(transform.position,
                                player.transform.position + transform.rotation * reverseDistance,
                                ref velocity,SmoothTime);
            if (mouse > 0) {
                
                toggleView = 1;
            }
        }
    }
}