using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendBtnHandler : MonoBehaviour {

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Animator enemyAnimator;

    // References to the player and battlemenu ui
    public GameObject Player;
    public GameObject BattleMenuUI;

    void Update()
    {
        // If it's the player's turn
        if (GameOperations.CURRENT_TURN)
        {
            // If player is in defense mode
            bool playerDefend = (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.DEFEND);

            // Run defense function
            if (playerDefend)
                ReallyPlayerDefend();
        }

    }

    // Hook to run coroutine from UI 
    public void ReallyPlayerDefend()
    {
        StartCoroutine("Player_Defend");
    }

    private IEnumerator Player_Defend()
    {
        // Hide UI
        BattleMenuUI.SetActive(false);

        // Set states
        GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.DEFEND;
        GameOperations.isPlayerDefending = true; // Enemy will check

        playerAnimator.SetBool("DefendBool", true);
        playerAnimator.SetBool("DefendActive", true);

        // DEFEND SOUND

        yield return new WaitForSeconds(1.5f);

        // Set state and wait
        GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.END_TURN;
        yield return new WaitForSeconds(1.5f);


        playerAnimator.SetBool("AttackBool", false);
        playerAnimator.SetBool("RunBool", false);

        // Set states
        GameOperations.m_PLAYER_STATE_CHOICE = (int)GameOperations.PLAYER_STATE.IDLE;
        GameOperations.CURRENT_TURN = false; // Switch to Enemy's turn 
        EnemyOperator.toggle_unlock = true;

        enemyAnimator.SetBool("DefenseBool", true);
        enemyAnimator.SetBool("DefenseActive", true);

    }
}
