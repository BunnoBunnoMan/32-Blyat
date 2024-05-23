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

  public void OnCollisionEnter2D(Collision2D collision){ //remember that onCOLLISIONenter2D uses Collision and NOT Collider
   
   if (collision.gameObject.CompareTag("Bull")){
      TakeDamage(2); //replace 5 with a bullet damage stat
      Debug.Log("You took damage");
    }

  }

  void TakeDamage(int damage){   //Copy this over to each entity that can take damage
    currentHealth -= damage;
  }



}
