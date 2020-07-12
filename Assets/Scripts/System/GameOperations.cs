
using UnityEngine;

// This class is used to hold most of the game's states and operation flags.
public class GameOperations : MonoBehaviour {
    
    // Boolean flags to represent current turn, defense and win states.
    public static bool CURRENT_TURN = true; // TRUE = PLAYER, FALSE = ENEMY
    public static bool isPlayerDefending = false;
    public static bool isEnemyDefending = false;
    public static bool m_playerWon = false;
    public static bool m_enemyWon = false;

    // Globally accessed state choices 
    public static int m_PLAYER_STATE_CHOICE;
    public static int m_ENEMY_STATE_CHOICE;

    // Globally accessed health stats
    public static int m_PLAYER_HEALTH = 100;
    public static int m_ENEMY_HEALTH = 100;

    // Player states
    public enum PLAYER_STATE
    { 
        IDLE = 0,
        ATTACK,
        DEFEND,
        RUN,
        DIE,
        END_TURN,
    };

    // Enemy States
    public enum ENEMY_STATE
    {
        IDLE = 0,
        ATTACK,
        DEFEND,
        DIE,
        END_TURN
    };

    // Click functions for the UI to switch states upon being clicked
    
    // Fight button click
    public void Player_FightClick()
    {
        // Set state choice
        m_PLAYER_STATE_CHOICE = (int)PLAYER_STATE.ATTACK;
    }

    // Defend button click
    public void Player_DefendClick()
    {
        // Set state choice
        m_PLAYER_STATE_CHOICE = (int)PLAYER_STATE.DEFEND;
    }

    // Run button click
    public void Player_RunClick()
    {
        // Set state choice
        m_PLAYER_STATE_CHOICE = (int)PLAYER_STATE.RUN;
    }

}
