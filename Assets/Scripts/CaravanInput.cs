using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanInput : MonoBehaviour {

	[SerializeField]
	MotionControl motionControl; // Control over the player's prefab

    public int playerId { get; set; }

	string playerInputSuffix;

	public void SetPlayer(int playerNumber)
	{
		if (playerNumber < 1)
		{
            playerNumber = 1;
		}
		playerInputSuffix = "_P" + playerNumber;
        playerId = playerNumber;
	}

	private void Update()
	{
		// take input movement
		motionControl.AccelerateToward(new Vector3(Input.GetAxis("Horizontal" + playerInputSuffix), 0, Input.GetAxis("Vertical" + playerInputSuffix)).normalized);
	}

    public void DisableInput()
    {
        this.enabled = false;
    }

    public void EnableInput()
    {
        this.enabled = true;
    }
}
