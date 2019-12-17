using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    public float curr;
    public float capacity;
    public float healCost = 3;
    public float healAmmount = 1;
    public Slider slider;
    public Health playerHealth;
    

    public void FillMeter()
    {
        if (curr < capacity)
        {
            curr ++;
            // slider.value += 1/capacity;
        }
    }

    public void Heal()
    {
        if (curr >= healCost)
        {
            curr -= healCost;
            // slider.value -= healCost/capacity;
            playerHealth.damageHealth(-1 * healAmmount, gameObject);
        }
    }
    
   private void Update() 
   {
       if (Input.GetKeyDown(KeyCode.H))
       {
           Heal();
       }
       slider.value = Mathf.MoveTowards(slider.value, curr/capacity, .2f * Time.deltaTime);
   } 
}
