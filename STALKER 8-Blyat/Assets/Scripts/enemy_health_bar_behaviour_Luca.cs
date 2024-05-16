using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy_health_bar_Luca : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    // Start is called before the first frame update
   public void SetHealth( int health, int maxHealth){
    slider.value = health;
    slider.maxValue = maxHealth;
   }

   
    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
