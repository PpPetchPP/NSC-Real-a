using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_Player : MonoBehaviour
{
    public Slider stamina_bar;
    public Slider hunger_bar;

    public float stamina = 10f;
    public float hunger_value = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        stamina_bar.value = stamina;
        hunger_bar.value = hunger_value;
    }

    public void use_stamina() 
    {
        stamina -= Time.deltaTime;
    }
    public void regen_stamina() 
    {
        if (hunger_value >= 0) 
        {
            stamina += Time.deltaTime;
            hunger_value -= Time.deltaTime/2;
        }
    }

    public void add_hunger(float value) 
    {
        hunger_value += value;
    }
}
