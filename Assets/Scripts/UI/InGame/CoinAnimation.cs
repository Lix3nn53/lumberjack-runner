using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;
public class CoinAnimation : MonoBehaviour
{
  [SerializeField] private float smoothTime = 0.4f;
  [SerializeField] private float distanceToDestroy = 0.1f;
  private Vector3 targetPosition;
  private Vector3 velocity = Vector3.zero;

  private void Start()
  {
    targetPosition = DIContainer.GetService<CoinAnimator>().TargetTransform.position;

    // TODO better way to make responsible coin size?
    float length = Screen.width / 10;
    GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
  }

  private void Update()
  {
    // transform.position = Vector3.MoveTowards(transform.position, targetLocation.position, Time.deltaTime * animationSpeed);
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    if (Vector3.Distance(transform.position, targetPosition) < distanceToDestroy)
    {
      Destroy(gameObject);
    }
  }
}
