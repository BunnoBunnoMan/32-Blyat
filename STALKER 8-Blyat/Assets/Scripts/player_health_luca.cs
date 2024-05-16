using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health_luca : MonoBehaviour
{
  public int maxHealth = 10;
  public int currentHealth;
  public Health_bar_luca health_bar;

  
  void Start()
  {
    currentHealth = maxHealth;
  }
  

  void Update(){
    //health_bar.SetHealth(currentHealth); //this is not entirely neccessary


    //When enemy scripts are finished, implement some system that properly applies damage depending on the enemy that attacks.
  }

  void TakeDamage(int damage){   //Copy this over to each entity that can take damage
    currentHealth -= damage;
    health_bar.SetHealth(currentHealth);
  }



}
