using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinAnimator : MonoBehaviour
{
  public Transform TargetTransform;
  [SerializeField] private GameObject animatedCoinPrefab;

  public void AddCoins(Vector3 collectedCoinPosition, int amount)
  {
    Vector3 pos = Camera.main.WorldToScreenPoint(collectedCoinPosition);

    var coin = Instantiate(animatedCoinPrefab, pos, Quaternion.identity);
    coin.transform.SetParent(gameObject.transform);
  }
}
