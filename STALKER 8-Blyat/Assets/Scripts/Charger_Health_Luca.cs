using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger_Health_Luca : MonoBehaviour
{
  public int maxHealth;
  public int currentHealth;
  public Enemy_health_bar_Luca health_bar;

  public GunStats gunStats;

  
  void Start()
  {
    currentHealth = maxHealth;
    health_bar.SetHealth(currentHealth, maxHealth); 
  }
  void Update(){
    if (currentHealth == 0) Destroy(gameObject);
    
  }


  public void OnTriggerEnter2D(Collider2D collision){ //remember that onCOLLISIONenter2D uses Collision and NOT Collider
   
   if (collision.gameObject.CompareTag("Bullet")){
    TakeDamage(gunStats.GunDamage); //replace 5 with a bullet damage stat
    Debug.Log("enemy took damage");

   }

   
  }
   void TakeDamage(int damage){   //Copy this over to each entity that can take damage
    currentHealth -= damage;
    health_bar.SetHealth(currentHealth, maxHealth);
  }
}
