using System.Collections;
using UnityEngine;

public class FightBtnHandler : MonoBehaviour {

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Animator enemyAnimator;

    // References to the player and battlemenu ui
    public GameObject Player;
    public GameObject BattleMenuUI;

    public Transform BearCentreNode;
    private Transform CurrentNode;

    void Start()
    {
        CurrentNode = gameObject.transform;
    }

    void Update()
    {
        // If it's the player's turn
        if (GameOperations.CURRENT_TURN)
        {
            // If player is in defense mode
            bool playerFight = (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.ATTACK);

            // Run defense function
            if (playerFight)
                ReallyPlayerFight();
        }

        // Check if player has lost all health
        if (GameOperations.m_PLAYER_HEALTH == 0)
        {
            // Set state
            GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.DIE;
            BattleMenuUI.SetActive(false); // Hide menu
            StopAllCoroutines(); // Stop all running coroutines
        }
    }

    // Hook to run coroutine from UI 
    public void ReallyPlayerFight()
    {
        StartCoroutine("Player_Fight");
    }

    // Player fight
    private IEnumerator Player_Fight()
    {

        // Hide UI
        BattleMenuUI.SetActive(false);
        
        // Set states and wait
        GameOperations.isPlayerDefending = false;
        playerAnimator.SetBool("AttackBool", true);
        GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.ATTACK;
        yield return new WaitForSeconds(1.5f);


        // Decrease enemy health if the enemy is NOT defending
        if (!GameOperations.isEnemyDefending && GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.ATTACK)
        {
            GameOperations.m_ENEMY_HEALTH -= 20; // Damage
            GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.END_TURN; // Set state
            // ENEMY GRUNT SOUND
        }

        // Wait
        yield return new WaitForSeconds(1.5f);

        // Set states
        GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.IDLE;
        playerAnimator.SetBool("AttackBool", false);
        playerAnimator.SetBool("DefendBool", false);
        playerAnimator.SetBool("DefendActive", false);
        playerAnimator.SetBool("RunBool", false);


        GameOperations.CURRENT_TURN = false; // Switch to Enemy's turn 
        EnemyOperator.toggle_unlock = true;

        enemyAnimator.SetBool("DefenseBool", true);
        enemyAnimator.SetBool("DefenseActive", true);


    }
}
