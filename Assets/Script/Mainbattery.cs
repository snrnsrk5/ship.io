using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBattery : MonoBehaviour
{
    public float reload;
    [SerializeField] float reloadTime;
    //[SerializeField] bool broken;
    [SerializeField] Text timeText;
    //[SerializeField] float speed;
    //[SerializeField] int count = 5;
    [SerializeField] Image reloadBar;
    [SerializeField] AudioSource cannon;
    
    MouseMove mouseMove;

    void Awake(){
        mouseMove = GetComponent<MouseMove>();
    }
    void FixedUpdate() {
        ReloadTime();
        Time();
        ReloadBar() ;
    }
    void Update() {
        Launch();
    }
    void Launch(){
        if(Input.GetMouseButtonDown(0) && Mathf.Round(reload*10)*0.1f == 0 && mouseMove.isMove == false){
            cannon.Play();
            reload = reloadTime;
        }
    }
    void ReloadTime(){
        if(reload > 0){
            reload -= 0.01f;
        }
    }

    void ReloadBar( ) {
	reloadBar.fillAmount = ((100 / reloadTime) * reload) / 100;
    }

    void Time(){
        if(Mathf.Round(reload * 10)*0.1f == 0) {
            timeText.text = string.Format(" ");
        }
        else timeText.text = string.Format("{0:0.0} s", reload);
    }
}