using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    public void UpdateHealth(int hp)
    {
        healthSlider.value = hp;
    }
}
