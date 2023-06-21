using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LootLockerManager : MonoBehaviour
{

    public TMP_InputField playerNameInput;
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");

            PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
        });
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("SetPlayerName: success");
            }
            else
            {
                Debug.Log("SetPlayerName: failure");
            }
        });
    }
}
