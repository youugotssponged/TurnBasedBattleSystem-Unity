using System.Collections;
using UnityEngine;

public class RunBtnHandler : MonoBehaviour {

    [SerializeField]
    private Animator playerAnimator;

    // Refs to player and menu
    public GameObject Player;
    public GameObject BattleMenuUI;

    void Update()
    {
        // If player has chosen to run
        bool playerRun = (GameOperations.m_PLAYER_STATE_CHOICE == (int)GameOperations.PLAYER_STATE.RUN);

        // Run - run function
        if (playerRun)
            ReallyPlayerRun();

    }

    // Hook
    public void ReallyPlayerRun()
    {
        StartCoroutine("Player_Run");
    }

    // Player run
    private IEnumerator Player_Run()
    {
        // Hide UI
        BattleMenuUI.SetActive(false);

        playerAnimator.SetBool("RunBool", true);

        Player.transform.rotation = new Quaternion(
            Player.transform.localPosition.x, 
            Player.transform.localPosition.y + 180f, 
            Player.transform.localPosition.z, 0f);

        Player.transform.Translate(0f, 0f, 30f * Time.deltaTime);
        // RUN SOUND


        // Return
        yield return new WaitForSeconds(6f);
    }
}
