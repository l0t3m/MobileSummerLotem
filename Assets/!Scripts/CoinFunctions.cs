using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinFunctions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            ScoreHandler.Instance.AddToScoreClass(1, false);
            Destroy(other.gameObject);
        }
    }
}
