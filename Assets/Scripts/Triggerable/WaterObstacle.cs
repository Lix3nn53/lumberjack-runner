using System;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class WaterObstacle : Triggerable
  {
    // Dependencies
    private PlayerCollider playerCollider;
    private PlayerMovement playerMovement;
    private Collider triggerCollider;
    [SerializeField] private BoxCollider colliderToWalkOn;

    [SerializeField] private float logStartLength = 3f;

    [SerializeField] private float logLengthPerLog = 2f;

    [SerializeField] private float colliderStartLength = -1f;

    [SerializeField] private float colliderLengthPerLog = 2f;

    [SerializeField] private int requiredLogAmount = 5;

    private int logsAdded = 0;

    private void Start()
    {
      playerCollider = DIContainer.GetService<PlayerCollider>();
      playerMovement = DIContainer.GetService<PlayerMovement>();
      triggerCollider = GetComponent<Collider>();
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      playerCollider.OnWaterObstacle(this);
      triggerCollider.enabled = false;
    }

    private static float[] lanes = new float[] { -1.5f, 0f, 1.5f };

    [SerializeField] private GameObject[] laneColliders;

    public static int GetLane(float playerX)
    {
      if (playerX < -0.4)
      {
        return 0;
      }
      else if (playerX > 0.4)
      {
        return 2;
      }
      else
      {
        return 1;
      }
    }

    public void FormLane(GameObject stackContainer, float playerX)
    {
      int laneIndex = GetLane(playerX);

      int stopIndex = stackContainer.transform.childCount;
      if (stackContainer.transform.childCount > requiredLogAmount)
      {
        stopIndex = requiredLogAmount;
      }

      int lastIndex = stackContainer.transform.childCount - 1;

      for (int i = 0; i < stopIndex; i++)
      {
        AddLog(stackContainer.transform.GetChild(lastIndex - i), lanes[laneIndex]);
      }

      FormColliderLength(laneIndex);
    }

    private void AddLog(Transform log, float spawnLane)
    {
      log.GetComponent<Collider>().enabled = false;
      log.GetComponent<Rigidbody>().isKinematic = true;
      log.SetParent(this.transform);
      log.localPosition = new Vector3(spawnLane, -0.5f, logStartLength + (logsAdded * logLengthPerLog));

      logsAdded++;
    }

    private void FormColliderLength(int lane)
    {
      laneColliders[lane].transform.localScale = new Vector3(laneColliders[lane].transform.localScale.x, laneColliders[lane].transform.localScale.y, colliderStartLength + (logsAdded * colliderLengthPerLog));
    }
  }
}