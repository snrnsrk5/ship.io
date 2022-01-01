using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMove : MonoBehaviour
{
    [SerializeField] float engine = 0;
    [SerializeField] float nots = 0;
    [SerializeField] float maxNots = 32.5f;
    [SerializeField] float acceleration = 1;
    [SerializeField] int accel;
    float full,thqu,half,quad,stop,back;

    [SerializeField] float steering = 0f;
    [SerializeField] float maxSteering = 5f;
    [SerializeField] float steeringAcceleration = 1f;
    [SerializeField] int steeringAccel = 0;
    float lFull, lHalf, rFull, rHalf;
    float ppp;

    [SerializeField] Text ktsText;
    [SerializeField] Text jtText;
    void Awake(){
        full = Mathf.Round(maxNots * 100) * 0.01f;
        thqu = Mathf.Round(maxNots * 0.75f *100 ) * 0.01f;
        half = Mathf.Round(maxNots * 0.5f *100 ) * 0.01f;
        quad = Mathf.Round(maxNots * 0.25f *100 ) * 0.01f;
        stop = 0;
        back = Mathf.Round(-maxNots * 0.5f *100 ) * 0.01f;
        
        rFull = Mathf.Round(maxSteering *10  ) * 0.1f;
        rHalf = Mathf.Round(maxSteering * 0.5f *10 ) * 0.1f;
        lFull = Mathf.Round(-maxSteering *10 ) * 0.1f;
        lHalf = Mathf.Round(-maxSteering * 0.5f *10 ) * 0.1f;

        accel = 0;
        InvokeRepeating("Kts", 0f, 0.5f);
    }

    void FixedUpdate() {
        Engine();
        Steering();
        Acceleration();
        SteeringAcceleration();
    }

    void Update(){
        Accel();
        SteeringAccel();
        Jt();
    }

    void Accel(){
        if (Input.GetKeyDown(KeyCode.W) && accel != 4) {accel += 1;}
        else if (Input.GetKeyDown(KeyCode.S) && accel != -1) { accel -= 1;}
    }

    void SteeringAccel() {
        if (Input.GetKeyDown(KeyCode.Q) && steeringAccel != 2) { steeringAccel += 1;}
        else if (Input.GetKeyDown(KeyCode.E) && steeringAccel != -2) { steeringAccel -= 1;}
    }

    void Engine(){
        ppp = 1 - (Mathf.Abs(steering) * 0.05f);
        engine = Mathf.Round( engine * 1000 )*0.001f  ;
        this.transform.Translate(new Vector3(0, engine * ppp *0.01f  ,0));
        nots = Mathf.Round(engine * ppp * 10 )*0.1f  ;
    }

    void Steering(){
        steering = Mathf.Round( steering * 1000 )*0.001f;
        Quaternion rotationQ = Quaternion.Euler(new Vector3(0f, 0f, steering));
        this.transform.Rotate(new Vector3(0f, 0f, (steering * 0.001f * Mathf.Abs(nots))));
    }

    void Acceleration(){
        if(accel == 4){
            if( stop > engine ) engine += (acceleration *0.001f)*0.64f;
            else if( quad > engine ) engine += (acceleration *0.001f)*0.80f;
            else if( half > engine ) engine += (acceleration *0.001f);
            else if( thqu > engine ) engine += (acceleration *0.001f)*0.80f;
            else if( full * 0.875f > engine ) engine += (acceleration *0.001f)*0.64f;
            else if( full * 0.937f > engine ) engine += (acceleration *0.001f)*0.51f;
            else if( full * 0.968f > engine ) engine += (acceleration *0.001f)*0.40f;
            else if( full * 0.984f > engine ) engine += (acceleration *0.001f)*0.32f;
            else if( full * 0.992f > engine ) engine += (acceleration *0.001f)*0.25f;
            else if( full > engine ) engine += (acceleration *0.001f)*0.20f;
            
            else if( full < engine ) engine -= (acceleration *0.001f)*0.64f;
        }
        if(accel == 3){
            if( stop > engine ) engine += (acceleration *0.001f)*0.64f;
            else if( quad > engine ) engine += (acceleration *0.001f)*0.80f;
            else if( half > engine ) engine += (acceleration *0.001f);
            else if( thqu > engine ) engine += (acceleration *0.001f)*0.80f;

            else if( thqu < engine ) engine -= (acceleration *0.001f)*0.64f;
        }
        if(accel == 2){
            if( stop > engine ) engine += (acceleration *0.001f)*0.64f;
            else if( quad > engine ) engine += (acceleration *0.001f)*0.80f;
            else if( half > engine ) engine += (acceleration *0.001f);

            else if( half < engine ) engine -= (acceleration *0.001f)*0.64f;
        }
        if(accel == 1){
            if( stop > engine ) engine += (acceleration *0.001f)*0.64f;
            else if( quad > engine ) engine += (acceleration *0.001f)*0.80f;

            else if( quad < engine ) engine -= (acceleration *0.001f)*0.64f;
        }
        if(accel == 0){
            if( stop > engine ) engine += (acceleration *0.001f)*0.64f;

            else if( stop < engine ) engine -= (acceleration *0.001f)*0.64f;
        }
        if(accel == -1){
            if( back*0.25 < engine ) engine -= (acceleration *0.001f)*0.64f;
            else if( back*0.5 < engine ) engine -= (acceleration *0.001f)*0.51f;
            else if( back*0.75 < engine ) engine -= (acceleration *0.001f)*0.40f;
            else if( back < engine ) engine -= (acceleration *0.001f)*0.32f;
        }
    }

    void SteeringAcceleration(){
        switch(steeringAccel)
        {
            case 2:
                if(rFull > steering) steering += (steeringAcceleration *0.001f);
            break;

            case 1:
                if(rHalf > steering) steering += (steeringAcceleration *0.001f);
                if(rHalf < steering) steering -= (steeringAcceleration *0.001f);
            break;

            case 0:
                if(0 > steering) steering += (steeringAcceleration *0.001f);
                if(0 < steering) steering -= (steeringAcceleration *0.001f);
            break;

            case -1:
                if(lHalf > steering) steering += (steeringAcceleration *0.001f);
                if(lHalf < steering) steering -= (steeringAcceleration *0.001f);
            break;

            case -2:
                if(lFull < steering) steering -= (steeringAcceleration *0.001f);
            break;
        }
    }
    void Kts()
    {
        ktsText.text = string.Format("< {0:0.0#} kts\n", nots);
        float y = 200f * (1f /(maxNots / nots)) + 50f;

        if(nots == 0f){
            y = 50f;
        }

        if(nots < 0){
            y = 100f * (1f / (maxNots / nots)) + 50f;
        }
        ktsText.rectTransform.anchoredPosition = new Vector2(170, y);
    }
    void Jt()
    {
        jtText.text = string.Format("^");

        float x = 200f * (steering/maxSteering);
        if (steering == 0f){
            x = 0f;
        }
        
        jtText.rectTransform.anchoredPosition = new Vector2(-x, -400);
    }
}
