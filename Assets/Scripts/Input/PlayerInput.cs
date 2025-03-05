using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public float XAxis { get; set; }
    public float YAxis { get; set; }
    public bool Shoot { get; set;}
    

    void Update()
    {
      
        XAxis = Input.GetAxisRaw("Horizontal");
        YAxis = Input.GetAxisRaw("Vertical");
        Shoot = Input.GetButtonDown("Fire1");
      
    }




}
