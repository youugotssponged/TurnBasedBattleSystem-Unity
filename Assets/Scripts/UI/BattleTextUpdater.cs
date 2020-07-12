using UnityEngine;
using UnityEngine.UI;

// This component is used to constantly check and update what currently 
// is happening within the game based off currently set states
public class BattleTextUpdater : MonoBehaviour {

    // Reference to the battle text object
    public Text t_BattleText;
	
	// Update is called once per frame
	void Update () {

        // PLAYER
        if (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.ATTACK)
            t_BattleText.text = "You attacked!";
        if (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.DEFEND)
            t_BattleText.text = "You are now in defense mode!";
        if (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.RUN)
            t_BattleText.text = "You ran away, shame...";
        if (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.DIE)
            t_BattleText.text = "GAME OVER, YOU LOST!";
        if (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.END_TURN)
            t_BattleText.text = "It's the enemy's turn now!";

        // Enemy 
        if(GameOperations.m_ENEMY_STATE_CHOICE == (int)GameOperations.ENEMY_STATE.ATTACK)
            t_BattleText.text = "The enemy attacked!";
        if (GameOperations.m_ENEMY_STATE_CHOICE == (int)GameOperations.ENEMY_STATE.DEFEND)
            t_BattleText.text = "The enemy is now in defense mode!";
        if (GameOperations.m_ENEMY_STATE_CHOICE == (int)GameOperations.ENEMY_STATE.DIE)
            t_BattleText.text = "YOU WIN!";
        if (GameOperations.m_ENEMY_STATE_CHOICE == (int)GameOperations.ENEMY_STATE.END_TURN)
            t_BattleText.text = "It's your turn now!";
    }
}
