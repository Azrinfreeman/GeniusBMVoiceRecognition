using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStartup : MonoBehaviour
{
    public Transform PlayerNameInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerNameInput.transform.gameObject.activeSelf)
        {
            if (PlayerPrefs.GetInt("CURRENT_COINS_PLAYER_" + PlayerPrefs.GetInt("CurrentPlayerNo_")) == 0)
            {
                PlayerPrefs.SetInt("alreadyGot", 0);
            }



            if (PlayerPrefs.GetInt("alreadyGot") == 0)
            {
                PlayerPrefs.SetInt(
                    "CURRENT_COINS_PLAYER_" + PlayerPrefs.GetInt("CurrentPlayerNo_"),
                    600
                );
                PlayerPrefs.SetInt("alreadyGot", 1);
            }
        }
    }
}
