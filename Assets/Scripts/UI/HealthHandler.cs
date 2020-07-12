using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour {

    // Refs to health text
    public Text t_PlayerHealthText;
    public Text t_EnemyHealthText;

	// Update is called once per frame
	void Update () {
        // Update health based on current status of health
        t_PlayerHealthText.text = "Your Health: " + GameOperations.m_PLAYER_HEALTH;
        t_EnemyHealthText.text = "Enemy Health: " + GameOperations.m_ENEMY_HEALTH;
	}
}
