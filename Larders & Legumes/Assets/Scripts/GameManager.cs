using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerController p;
    public EnemyController e;

    public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST };
    public BattleState state;

    private void Update()
    {
        if (p.inCombat)
        {
            state = BattleState.START;
            StartCoroutine(SetupBattle());
        }
    }

    IEnumerator SetupBattle()
    {
        //Space for dialogue and general setup
        yield return null;
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    void PlayerTurn()
    {
        p.LocateEnemy();
    }

    public void OnAttackPressed()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        bool isDead;
        
        if (e.enemy.currentHealth - p.player.attackPower <= 0) isDead = true;
        else isDead = false;

        p.DealDamage(p.player.attackPower);
        
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            e.enemy.Drop();
        }
        else if(state == BattleState.LOST)
        {
            PlayerDied();
        }
    }

    IEnumerator EnemyTurn()
    {
        bool isDead;

        if (p.player.currentHealth - e.enemy.attackPower <= 0) isDead = true;
        else isDead = false;

        yield return new WaitForSeconds(1f);
        e.DealDamage(e.enemy.attackPower);

        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }


    public void PlayerDied()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        Debug.Log("You Died.");
    }

    public void Retry()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
