using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    
    [SerializeField] Transform Player; 
    [SerializeField] Transform teleport;
    
    Transform Cam; //es vor player-in heteves
    Camera cam; 
    void Start()
    {
        Cam = Camera.main.transform;
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        {
            //Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            //Screen.worldtoscreen
            Vector3 screenpos = cam.WorldToScreenPoint(Player.position);
            if (screenpos.x > 1200)
            {
                print("aj es");
                Player.position = new Vector3(Cam.position.x  - teleport.position.x *3 /4, teleport.position.y, teleport.position.z); 
            }
            else if (screenpos.x < -100)
            {
                print("dzax es");
                Player.position = new Vector3(Cam.position.x - teleport.position.x * 3 / 4, teleport.position.y, teleport.position.z);
            }
        }

        Cam.position = new Vector3(Cam.position.x, Player.position.y + 2f, Cam.position.z); //fixecir camerayi pozitiony x u z arancqneri hamar
         
    }

}
                   