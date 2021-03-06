 using UnityEngine;
 
     public class MouseMove : MonoBehaviour
     {
        Camera camera;
        public bool isMove;
        [SerializeField] float speed;
        Vector3 destination;
        MainBattery mainBattery;
        
        [SerializeField] GameObject ok;
        [SerializeField] GameObject load;
        void Awake(){
            camera = Camera.main;
            mainBattery = GetComponent<MainBattery>();
        }

        void Update(){
            RaycastHit hit;
            if(Physics.Raycast(camera.ScreenPointToRay
            (Input.mousePosition), out hit))
            {
                SetDes(hit.point);
            }
            Move();
            CursorColor();
        }

        void SetDes(Vector3 dest){
            destination = dest;
            isMove = true;
        }

        void Move(){
            if(isMove)
            {
                var dir = destination - transform.position;
                
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);

            }

            if(Vector3.Distance(transform.position, destination)<=0.1f){
                isMove = false;

            }
        }
        void CursorColor(){
            if(isMove == false && Mathf.Round(mainBattery.reload*10)*0.1f == 0){
                ok.SetActive(true);
                load.SetActive(false);
            }
            else{
                
                ok.SetActive(false);
                load.SetActive(true);
            }
        }
     }
 