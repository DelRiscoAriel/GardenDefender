using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    public string name;
    public float health;
    public float physicalDefense;
    public float longDefence;
    public float physicalAttackDamage;
    public float longAttackDamage;
    public float specialDamage;

    public float currenthealth;
    public float specailReady = 0;
    public bool longRange = false;
    public bool isDead = false;

    /////////////////////////////////////////////////
    public AudioSource sound;
    public AudioClip physicalAttackSound;
    public AudioClip longAttackSound;
    public AudioClip specialAttackSound;
    //public AudioClip takeDamageSound;
    public AudioClip deadSound;
    public bool goSound = false;
    /////////////////////////////////////////////////

    void Start()
    {
        currenthealth = health;
    }

    void Update()
    {
        if (currenthealth <= 0)
        {
            ////////////////////////////////////////////
            if (goSound == false)
            {               
                sound.clip = deadSound;
                sound.Play();
                goSound = true;               
            }
            ////////////////////////////////////////////

            isDead = true;
            specailReady = 0;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public float Attack(float physicalDefenceEnemy)
    {
        /////////////////////////////////////////////////
        sound.clip = physicalAttackSound;
        sound.Play();
        /////////////////////////////////////////////////

        float damage = Random.Range(physicalAttackDamage - 10, physicalAttackDamage + 10);
        damage -= physicalDefenceEnemy;

        specailReady += Random.Range(20, 40);

        if (isDead == true)
        {
            return 0;
        }
        if (damage < 0)
        {
            damage = 0;
        }
        return damage;
    }

    public float longAttack(float longDefenceEnemy)
    {
        /////////////////////////////////////////////////
        sound.clip = longAttackSound;
        sound.Play();
        /////////////////////////////////////////////////

        float damage = Random.Range(longAttackDamage - 10, longAttackDamage + 10);
        damage -= longDefenceEnemy;

        specailReady += Random.Range(20, 50);

        if (isDead == true)
        {
            return 0;
        }
        if (damage < 0)
        {
            damage = 0;
        }
        return damage;
    }

    public void TakeDamage(float damage)
    {
        /////////////////////////////////////////////////
        /*sound.clip = takeDamageSound;
        sound.Play();*/
        /////////////////////////////////////////////////

        currenthealth -= damage;
    }

    public float SpecialAttack()
    {
        if (isDead == true)
        {
            return 0;
        }

        /////////////////////////////////////////////////
        sound.clip = specialAttackSound;
        sound.Play();
        /////////////////////////////////////////////////

        return Random.Range(specialDamage - 5, specialDamage + 5);
    }

    public bool Dead()
    {
        if (isDead == true)
        {
            return true;
        }
        else
            return false;
    }
}
