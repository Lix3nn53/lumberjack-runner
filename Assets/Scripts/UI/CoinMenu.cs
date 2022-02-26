using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMenu : MonoBehaviour
{
  private int coinsCollected = 0;
  [SerializeField] private TMP_Text text;

  public void OnCoinCollect(int amount)
  {
    coinsCollected += amount;
    text.text = coinsCollected.ToString();
  }
}
