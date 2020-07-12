using System.Collections;
using UnityEngine;

// Used to control the enemy's choices during it's turn
public class EnemyOperator : MonoBehaviour {

    [SerializeField]
    private Animator enemyAnimator;

    [SerializeField]
    private Animator playerAnimator;

    // Global boolean to stop the enemy after it take's its turn
    public static bool toggle_unlock = false;

    // Reference to the battle menu ui as it will be set to hidden
    public GameObject BattleMenuUI;

    // Progressive locks to stop re-execution during coroutine / update function clash
    private bool locka = false, lockb = false;

    // Update is called once per frame
    void Update() {
        // If the enemy's turn
        if (!GameOperations.CURRENT_TURN && !locka && !lockb)
        {
            // Ensures Action happens once - self locking - only unlocks after a player's turn
            if (toggle_unlock)
            {
                // Generate a random number between one and two
                System.Random rndnum = new System.Random();
                int num = rndnum.Next(1, 3);
                print(num);

                // If 1 -> attack
                if (num == 1)
                {
                    toggle_unlock = false;
                    runEnemyAttack();
                    locka = true;
                }
                // Else if 2 -> defend
                else if (num == 2)
                {
                    toggle_unlock = false;
                    runEnemyDefense();
                    lockb = true;
                }

                //enabled = false;
            }
            
        }

        // Check if the enemy has died
        if (GameOperations.m_ENEMY_HEALTH == 0)
        {
            // Set state
            GameOperations.m_ENEMY_STATE_CHOICE = (int)GameOperations.ENEMY_STATE.DIE;
            BattleMenuUI.SetActive(false); // Hide menu
            StopAllCoroutines(); // Stop all currently running coroutines
        }
           

	}

    // Hooks to allow button click event to run the coroutine as private IEnums are not accessible via UI components
    // Attack
    void runEnemyAttack()
    {
        StartCoroutine("Enemy_Attack");
    }

    // Defend
    void runEnemyDefense()
    {
        StartCoroutine("Enemy_Defend");
    }

    // Enemy attack function coroutine
    IEnumerator Enemy_Attack()
    {
        // Set state and wait
        enemyAnimator.SetBool("AttackBool", true);
        GameOperations.m_ENEMY_STATE_CHOICE = (int)GameOperations.ENEMY_STATE.ATTACK;
        GameOperations.isEnemyDefending = false;
        yield return new WaitForSeconds(1.5f);

        // Preform Enemy Attack - check if player is NOT in defense mode
        if (!GameOperations.isPlayerDefending && GameOperations.m_ENEMY_STATE_CHOICE == (int)GameOperations.ENEMY_STATE.ATTACK)
        {
            GameOperations.m_PLAYER_HEALTH -= 20; // damage#
            // PLAYER GRUNT SOUND
        }

        // Set state and wait
        GameOperations.m_ENEMY_STATE_CHOICE = (int)GameOperations.ENEMY_STATE.END_TURN;
        yield return new WaitForSeconds(1f);

        // Set state and reveal menu to player
        GameOperations.m_ENEMY_STATE_CHOICE = (int)GameOperations.ENEMY_STATE.IDLE;
        BattleMenuUI.SetActive(true);

        // Change turn
        GameOperations.CURRENT_TURN = true; // Switch to Players turn 

        locka = false;
        lockb = false;

        enemyAnimator.SetBool("AttackBool", false);
        playerAnimator.SetBool("DefendBool", false);
        playerAnimator.SetBool("DefendActive", false);


    }

    IEnumerator Enemy_Defend()
    {
        enemyAnimator.SetBool("DefenseBool", false);
        GameOperations.m_ENEMY_STATE_CHOICE = (int)GameOperations.ENEMY_STATE.DEFEND;
        GameOperations.isEnemyDefending = true;
        yield return new WaitForSeconds(3.5f);

        enemyAnimator.SetBool("DefenseActive", false);


        // Set state and reveal menu to player
        GameOperations.m_ENEMY_STATE_CHOICE = (int)GameOperations.ENEMY_STATE.END_TURN;
        BattleMenuUI.SetActive(true);

        // Change turn
        GameOperations.CURRENT_TURN = true; // Switch to Players turn 

        locka = false;
        lockb = false;

        playerAnimator.SetBool("DefendBool", false);
        playerAnimator.SetBool("DefendActive", false);


    }

}
