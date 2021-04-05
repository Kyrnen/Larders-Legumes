using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerController p;
    public EnemyController e;

    private bool combatCommences = false;

    private void Update()
    {
        if (p.inCombat && !combatCommences)
        {
            combatCommences = true;
           // StartCoroutine(BeginTurnBasedCombat());
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

    IEnumerator BeginTurnBasedCombat()
    {
        while (p.player.currentHealth > 0 && e.enemy)
        {
            if (!p.hasAttacked)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    p.DealDamage(p.player.attackPower);
                    p.hasAttacked = true;
                    e.hasAttacked = false;
                    yield return new WaitForSeconds(1.5f);
                }
            }
            if (!e.hasAttacked)
            {
                e.DealDamage(e.player.attackPower);
                e.hasAttacked = true;
                p.hasAttacked = false;
                yield return new WaitForSeconds(1.5f);
            }
        }

        combatCommences = false;
        yield return null;
    }

}
