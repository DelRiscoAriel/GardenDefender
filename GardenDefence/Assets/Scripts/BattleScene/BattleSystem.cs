using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURNFIRST, PLAYERTURNSECOND, ENEMYTURNFIRST, ENEMYTURNSECOND, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    //[Header("Health Settings")]
    public BattleState state;
    public bool oneEnemy = false;
    public bool onePlayer = false;

    [Header("GameManager")]
    public GameManager gm;
    public string levelToComplete;

    [Header("Characters Prefabs")]
    public GameObject playerPrefabFirst;
    public GameObject playerPrefabSecond;
    public GameObject enemyPrefabFirst;
    public GameObject enemyPrefabSecond;

    [Header("Characters Battle Stations")]
    public Transform player1BattleStation;
    public Transform player2BattleStation;
    public Transform enemy1BattleSystem;
    public Transform enemy2BattleSystem;

    CombatUnit playerUnitFirst;
    CombatUnit playerUnitSecond;
    CombatUnit enemyUnitFirst;
    CombatUnit enemyUnitSecond;

    CombatUnit slectedEnemy;

    [Header("Characters BattleHUDs")]
    public BattleHUD playerHUDfirst;
    public BattleHUD playerHUDsecond;
    public BattleHUD enemyHUDfirst;
    public BattleHUD enemyHUDsecond;

    [Header("UI")]
    public Text displayInfo;
    public GameObject selectButtonEnemy1;
    public GameObject attackButtonEnemy1;
    public GameObject longAttackButtonEnemy1;

    public GameObject selectButtonEnemy2;
    public GameObject attackButtonEnemy2;
    public GameObject longAttackButtonEnemy2;

    public SpriteRenderer playerFirstTurn;
    public SpriteRenderer playerSecondTurn;
    public SpriteRenderer enemyFirstTurn;
    public SpriteRenderer enemySecondTurn;

    bool switchTurns = false;

    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
        ButtonOffOnEnemy1(false);
        ButtonOffOnEnemy2(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (oneEnemy == true)
        {
            enemyUnitSecond.goSound = true;
            enemyUnitSecond.currenthealth = 0;
            enemyUnitSecond.isDead = true;
        }
        if (onePlayer == true)
        {
            playerUnitSecond.goSound = true;
            playerUnitSecond.currenthealth = 0;
            playerUnitSecond.isDead = true;
        }

        if (playerPrefabFirst != null)
        {
            playerHUDfirst.SetHUD(playerUnitFirst);
        }
        if (playerPrefabSecond != null)
        {
            playerHUDsecond.SetHUD(playerUnitSecond);
        }
        if (enemyPrefabFirst != null)
        {
            enemyHUDfirst.SetHUD(enemyUnitFirst);
        }
        if (enemyPrefabSecond != null)
        {
            enemyHUDsecond.SetHUD(enemyUnitSecond);
        }

        if (state == BattleState.PLAYERTURNFIRST)
        {
            playerFirstTurn.color = Color.blue;
            playerSecondTurn.color = Color.white;
            enemyFirstTurn.color = Color.white;
            enemySecondTurn.color = Color.white;
        }
        else if (state == BattleState.ENEMYTURNFIRST)
        {
            playerFirstTurn.color = Color.white;
            playerSecondTurn.color = Color.white;
            enemyFirstTurn.color = Color.blue;
            enemySecondTurn.color = Color.white;
        }
        else if (state == BattleState.PLAYERTURNSECOND)
        {
            playerFirstTurn.color = Color.white;
            playerSecondTurn.color = Color.blue;
            enemyFirstTurn.color = Color.white;
            enemySecondTurn.color = Color.white;
        }
        else if (state == BattleState.ENEMYTURNSECOND)
        {
            playerFirstTurn.color = Color.white;
            playerSecondTurn.color = Color.white;
            enemyFirstTurn.color = Color.white;
            enemySecondTurn.color = Color.blue;
        }

        if (playerUnitFirst.isDead == true)
        {
            playerFirstTurn.color = Color.red;
            if (state == BattleState.PLAYERTURNFIRST)
            {
                state = BattleState.PLAYERTURNSECOND;
            }
        }
        if (playerUnitSecond.isDead == true)
        {
            playerSecondTurn.color = Color.red;
            if (state == BattleState.PLAYERTURNSECOND)
            {
                state = BattleState.PLAYERTURNFIRST;
            }
        }
        if (enemyUnitFirst.isDead == true)
        {
            enemyFirstTurn.color = Color.red;
            selectButtonEnemy1.SetActive(false);
        }
        if (enemyUnitSecond.isDead == true)
        {
            enemySecondTurn.color = Color.red;
            selectButtonEnemy2.SetActive(false);
        }

        if (playerUnitFirst.Dead() && playerUnitSecond.Dead())
        {
            state = BattleState.LOST;
            displayInfo.text = "You Have LOST";
            StopCoroutine("EnemysTurn");
            StartCoroutine("Lose");
        }
        if (enemyUnitFirst.Dead() && enemyUnitSecond.Dead())
        {
            state = BattleState.WON;
            displayInfo.text = "You have WON";
            StopCoroutine("EnemysTurn");
            StartCoroutine("Win");
        }
    }

    void ButtonOffOnEnemy1(bool active)
    {
        attackButtonEnemy1.SetActive(active);
        longAttackButtonEnemy1.SetActive(active);
        selectButtonEnemy1.SetActive(!active);
    }
    void ButtonOffOnEnemy2(bool active)
    {
        attackButtonEnemy2.SetActive(active);
        longAttackButtonEnemy2.SetActive(active);
        selectButtonEnemy2.SetActive(!active);
    }

    void SetUpBattle()
    {
        if (playerPrefabFirst != null)
        {
            GameObject player1 = Instantiate(playerPrefabFirst, player1BattleStation);
            playerUnitFirst = player1.GetComponent<CombatUnit>();
            playerHUDfirst.SetHUD(playerUnitFirst);
        }
        if (playerPrefabSecond != null)
        {
            GameObject player2 = Instantiate(playerPrefabSecond, player2BattleStation);
            playerUnitSecond = player2.GetComponent<CombatUnit>();
            playerHUDsecond.SetHUD(playerUnitSecond);
        }
        if (enemyPrefabFirst != null)
        {
            GameObject enemy1 = Instantiate(enemyPrefabFirst, enemy1BattleSystem);
            enemyUnitFirst = enemy1.GetComponent<CombatUnit>();
            enemyHUDfirst.SetHUD(enemyUnitFirst);
        }
        if (enemyPrefabSecond != null)
        {
            GameObject enemy2 = Instantiate(enemyPrefabSecond, enemy2BattleSystem);
            enemyUnitSecond = enemy2.GetComponent<CombatUnit>();
            enemyHUDsecond.SetHUD(enemyUnitSecond);
        }

        state = BattleState.PLAYERTURNFIRST;

        displayInfo.text = "Select an enemy to attack";
    }

    //Functions to select which nemy attack
    public void PlayerTurnSelectFirstEnemy()
    {
        if (state == BattleState.PLAYERTURNFIRST)
        {
            slectedEnemy = enemyUnitFirst;
            ButtonOffOnEnemy1(true);
            displayInfo.text = "Select which type of attack";
        }
        else if (state == BattleState.PLAYERTURNSECOND)
        {
            slectedEnemy = enemyUnitFirst;
            ButtonOffOnEnemy1(true);
            displayInfo.text = "Select which type of attack";
        }
    }
    public void PlayerTurnSelectSecondEnemy()
    {
        if (state == BattleState.PLAYERTURNFIRST)
        {
            slectedEnemy = enemyUnitSecond;
            ButtonOffOnEnemy2(true);
            displayInfo.text = "Select which type of attack";
        }
        else if (state == BattleState.PLAYERTURNSECOND)
        {
            slectedEnemy = enemyUnitSecond;
            ButtonOffOnEnemy2(true);
            displayInfo.text = "Select which type of attack";
        }
    }

    //Player Attack Methods
    public void PlayerFirstAttack()
    {
        if (state == BattleState.PLAYERTURNFIRST)
        {
            float damageDelt;
            slectedEnemy.TakeDamage(damageDelt = playerUnitFirst.Attack(slectedEnemy.physicalDefense));
            
            ButtonOffOnEnemy1(false);
            ButtonOffOnEnemy2(false);
            displayInfo.text = "Damage delt " + (int)damageDelt;

            //state = BattleState.ENEMYTURNFIRST;
            if (enemyUnitFirst.isDead == false && enemyUnitSecond.isDead == false)
            {
                if (playerUnitSecond.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.ENEMYTURNFIRST;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.ENEMYTURNSECOND;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.ENEMYTURNFIRST;
                }
            }
            else
            {
                state = BattleState.ENEMYTURNFIRST;
            }
            StartCoroutine("EnemysTurn");
        }
        else if (state == BattleState.PLAYERTURNSECOND)
        {
            float damageDelt;
            slectedEnemy.TakeDamage(damageDelt = playerUnitSecond.Attack(slectedEnemy.physicalDefense));           
            ButtonOffOnEnemy1(false);
            ButtonOffOnEnemy2(false);
            displayInfo.text = "Damage delt " + (int)damageDelt;

            //state = BattleState.ENEMYTURNSECOND;
            if (enemyUnitFirst.isDead == false && enemyUnitSecond.isDead == false)
            {
                if (playerUnitFirst.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.ENEMYTURNSECOND;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.ENEMYTURNFIRST;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.ENEMYTURNSECOND;
                }
            }
            else
            {
                state = BattleState.ENEMYTURNSECOND;
            }
            StartCoroutine("EnemysTurn");
        }        
    }
    public void PlayerFirstLongAttack()
    {
        if (state == BattleState.PLAYERTURNFIRST)
        {
            float damageDelt;
            slectedEnemy.TakeDamage(damageDelt = playerUnitFirst.longAttack(slectedEnemy.longDefence));            
            ButtonOffOnEnemy1(false);
            ButtonOffOnEnemy2(false);
            displayInfo.text = "Damage delt " + (int)damageDelt;

            //state = BattleState.ENEMYTURNFIRST;
            if (enemyUnitFirst.isDead == false && enemyUnitSecond.isDead == false)
            {
                if (playerUnitSecond.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.ENEMYTURNFIRST;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.ENEMYTURNSECOND;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.ENEMYTURNFIRST;
                }
            }
            else
            {
                state = BattleState.ENEMYTURNFIRST;
            }
            StartCoroutine("EnemysTurn");
        }
        else if (state == BattleState.PLAYERTURNSECOND)
        {
            float damageDelt;
            slectedEnemy.TakeDamage(damageDelt = playerUnitSecond.longAttack(slectedEnemy.longDefence));           
            ButtonOffOnEnemy1(false);
            ButtonOffOnEnemy2(false);
            displayInfo.text = "Damage delt " + (int)damageDelt;

            //state = BattleState.ENEMYTURNSECOND;
            if (enemyUnitFirst.isDead == false && enemyUnitSecond.isDead == false)
            {
                if (playerUnitFirst.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.ENEMYTURNSECOND;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.ENEMYTURNFIRST;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.ENEMYTURNSECOND;
                }
            }
            else
            {
                state = BattleState.ENEMYTURNSECOND;
            }
            StartCoroutine("EnemysTurn");
        }
    }
    public void PlayerSpecialFirst()
    {
        if (state == BattleState.PLAYERTURNFIRST)
        {
            ButtonOffOnEnemy1(false);
            ButtonOffOnEnemy2(false);
            playerUnitFirst.specailReady = 0;
            float damageDelt;
            enemyUnitFirst.TakeDamage(damageDelt = playerUnitFirst.SpecialAttack());
            enemyUnitSecond.TakeDamage(damageDelt = playerUnitFirst.SpecialAttack());
            displayInfo.text = "Damage delt to both enemys " + (int)damageDelt;

            //state = BattleState.ENEMYTURNFIRST;
            if (enemyUnitFirst.isDead == false && enemyUnitSecond.isDead == false)
            {
                if (playerUnitSecond.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.ENEMYTURNFIRST;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.ENEMYTURNSECOND;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.ENEMYTURNFIRST;
                }
            }
            else
            {
                state = BattleState.ENEMYTURNFIRST;
            }
            StartCoroutine("EnemysTurn");
        }
    }
    public void PlayerSpecialSecond()
    {
        if (state == BattleState.PLAYERTURNSECOND)
        {
            ButtonOffOnEnemy1(false);
            ButtonOffOnEnemy2(false);
            playerUnitSecond.specailReady = 0;
            float damageDelt;
            enemyUnitFirst.TakeDamage(damageDelt = playerUnitSecond.SpecialAttack());
            enemyUnitSecond.TakeDamage(damageDelt = playerUnitSecond.SpecialAttack());
            displayInfo.text = "Damage delt to both enemys " + (int)damageDelt;

            //state = BattleState.ENEMYTURNSECOND;
            if (enemyUnitFirst.isDead == false && enemyUnitSecond.isDead == false)
            {
                if (playerUnitFirst.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.ENEMYTURNSECOND;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.ENEMYTURNFIRST;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.ENEMYTURNSECOND;
                }
            }
            else
            {
                state = BattleState.ENEMYTURNSECOND;
            }
            StartCoroutine("EnemysTurn");
        }
    }

    //Enemys Turn
    IEnumerator EnemysTurn()
    {
        yield return new WaitForSeconds(0.5f);
        if (enemyUnitFirst.isDead == true & enemyUnitSecond.isDead == true)
        {
            state = BattleState.WON;
        }
        else if (enemyUnitFirst.isDead == true)
        {
            state = BattleState.ENEMYTURNSECOND;
        }
        else if (enemyUnitSecond.isDead == true)
        {
            state = BattleState.ENEMYTURNFIRST;
        }

        if (state == BattleState.ENEMYTURNFIRST)
        {
            yield return new WaitForSeconds(2f);
            displayInfo.text = (enemyUnitFirst.name + " turn");
            yield return new WaitForSeconds(2f);

            float a = Random.Range(0, 2);
            if (a == 0)
            {
                slectedEnemy = playerUnitFirst;
            }
            else
                slectedEnemy = playerUnitSecond;

            if (playerUnitFirst.isDead == true)
            {
                slectedEnemy = playerUnitSecond;
            }
            if (playerUnitSecond.isDead == true)
            {
                slectedEnemy = playerUnitFirst;
            }

            float damageDelt;
            if (enemyUnitFirst.specailReady >= 98)
            {
                playerUnitFirst.TakeDamage(damageDelt = enemyUnitFirst.SpecialAttack());
                playerUnitSecond.TakeDamage(damageDelt = enemyUnitFirst.SpecialAttack());

                enemyUnitFirst.specailReady = 0;
                displayInfo.text = "Both Players have recive " + (int)damageDelt + " damage";
            }
            else
            {
                if (enemyUnitFirst.longRange == false)
                {
                    slectedEnemy.TakeDamage(damageDelt = enemyUnitFirst.Attack(slectedEnemy.physicalDefense));
                }
                else
                {
                    slectedEnemy.TakeDamage(damageDelt = enemyUnitFirst.longAttack(slectedEnemy.longDefence));
                }

                displayInfo.text = slectedEnemy.name + " has recive " + (int)damageDelt + " damage";
            }

            yield return new WaitForSeconds(2f);
            displayInfo.text = "Select an enemy to attack";

            if (playerUnitFirst.isDead == false && playerUnitSecond.isDead == false)
            {
                if (enemyUnitSecond.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.PLAYERTURNSECOND;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.PLAYERTURNFIRST;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.PLAYERTURNSECOND;
                }
            }
            else
            {
                state = BattleState.PLAYERTURNSECOND;
            }
        }
        else if (state == BattleState.ENEMYTURNSECOND)
        {
            yield return new WaitForSeconds(2f);
            displayInfo.text = (enemyUnitSecond.name + " turn");
            yield return new WaitForSeconds(2f);

            float a = Random.Range(0, 2);
            if (a == 0)
            {
                slectedEnemy = playerUnitFirst;
            }
            else
                slectedEnemy = playerUnitSecond;

            if (playerUnitFirst.isDead == true)
            {
                slectedEnemy = playerUnitSecond;
            }
            if (playerUnitSecond.isDead == true)
            {
                slectedEnemy = playerUnitFirst;
            }

            float damageDelt;
            if (enemyUnitSecond.specailReady >= 98)
            {
                playerUnitFirst.TakeDamage(damageDelt = enemyUnitSecond.SpecialAttack());
                playerUnitSecond.TakeDamage(damageDelt = enemyUnitSecond.SpecialAttack());

                enemyUnitSecond.specailReady = 0;
                displayInfo.text = "Both Players have recive " + (int)damageDelt + " damage";
            }
            else
            {
                if (enemyUnitSecond.longRange == false)
                {
                    slectedEnemy.TakeDamage(damageDelt = enemyUnitSecond.Attack(slectedEnemy.physicalDefense));
                }
                else
                {
                    slectedEnemy.TakeDamage(damageDelt = enemyUnitSecond.longAttack(slectedEnemy.longDefence));
                }

                displayInfo.text = slectedEnemy.name + " has recive " + (int)damageDelt + " damage";
            }

            yield return new WaitForSeconds(2f);
            displayInfo.text = "Select an enemy to attack";           

            if (playerUnitFirst.isDead == false && playerUnitSecond.isDead == false)
            {
                if (enemyUnitFirst.isDead == true)
                {
                    if (switchTurns == false)
                    {
                        state = BattleState.PLAYERTURNFIRST;
                        switchTurns = true;
                    }
                    else
                    {
                        state = BattleState.PLAYERTURNSECOND;
                        switchTurns = false;
                    }
                }
                else
                {
                    state = BattleState.PLAYERTURNFIRST;
                }
            }
            else
            {
                state = BattleState.PLAYERTURNFIRST;
            }
        }
        else if (state == BattleState.LOST)
        {

        }
        else if (state == BattleState.WON)
        {

        }
    }

    IEnumerator Win()
    {       
        gm.CompleteLevel(levelToComplete);
        yield return new WaitForSeconds(2f);
        SaveSystem.SavePlayer(gm);
        SceneManager.LoadScene("LevelSelect");
    }
    IEnumerator Lose()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LevelSelect");
    }
}
