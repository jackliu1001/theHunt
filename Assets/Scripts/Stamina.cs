using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    public Slider slider;

    [SerializeField] protected int maxStamina;
    [Range(0, 10)] [SerializeField] private float staminaDrain = 1f;
    [Range(0, 10)] [SerializeField] private float staminaRegen = 1f;
    public int currentStamina;
    private CharacterController player;
    private void Start()
    {
        slider.value = maxStamina;
        currentStamina = maxStamina;
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        slider.value = currentStamina;
    }

    void useStamina(int stamina)
    {
        currentStamina -= stamina;
    }
}
