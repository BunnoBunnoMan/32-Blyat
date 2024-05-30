using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_health_luca : MonoBehaviour
{
  public int maxHealth;
  public int currentHealth;
  public Health_bar_luca health_bar;

 // private int dmg = 2; //REPLACE WITH A SCRIPTABLE OBJECT REFERENCE
  
  void Start()
  {
    currentHealth = maxHealth;
    health_bar.SetMaxhealth(maxHealth);
  }
  

  void Update(){
    health_bar.SetHealth(currentHealth);
  }

  public void OnTriggerEnter2D(Collider2D collision){ //remember that onCOLLISIONenter2D uses Collision and NOT Collider
   
   if (collision.gameObject.name == "Bull"){
      TakeDamage(4); //
      //Debug.Log("You took damage");
    }

    if (collision.gameObject.name == "Charger"){
      TakeDamage(2);
    }

  }

  void TakeDamage(int damage){   //Copy this over to each entity that can take damage
    currentHealth -= damage;
  }



}
