using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;
    public Slider specialSlider;
    public GameObject specialButton;

    void Start()
    {
        specialButton.SetActive(false);
    }

    public void Update()
    {
        if (specialSlider.value == 100)
        {
            specialButton.SetActive(true);
        }
        else
        {
            specialButton.SetActive(false);
        }
    }
    public void SetHUD(CombatUnit unit)
    {
        //nameText.text = unit.name;
        hpSlider.maxValue = unit.health;
        hpSlider.value = unit.currenthealth;
        specialSlider.maxValue = 100;
        specialSlider.value = unit.specailReady;
    }

    public void UpdateHUD(CombatUnit unit)
    {
        hpSlider.value = unit.currenthealth;
        specialSlider.value = unit.specailReady;
    }

}
