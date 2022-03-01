using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class Finish : Triggerable
  {
    private PlayerMovement playerMovement;
    private GameManager gameManager;
    private PlayerCollider playerCollider;

    [SerializeField] private int requiredLogAmount = 8;

    [SerializeField] private GameObject[] woodFinishArray;

    [SerializeField] private float woodShiftPerLane = 0.3f;

    private void Start()
    {
      playerMovement = DIContainer.GetService<PlayerMovement>();
      gameManager = DIContainer.GetService<GameManager>();
      playerCollider = DIContainer.GetService<PlayerCollider>();

      foreach (GameObject woodFinish in woodFinishArray)
      {
        woodFinish.SetActive(false);
      }
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      // TODO carry this over to trigger on finish lifebuoy
      // playerMovement.StopRunning();
      // gameManager.GameOver(true);
      playerMovement.DisableInput();
      playerCollider.OnFinish(this);

      Destroy(this);
    }

    public void OnFinishCallback(GameObject stackContainer, float playerX)
    {
      gameManager.OnFinish(stackContainer.transform.childCount);

      int laneIndex = WaterObstacle.GetLane(playerX);

      int stopIndex = stackContainer.transform.childCount;
      if (stackContainer.transform.childCount > requiredLogAmount)
      {
        stopIndex = requiredLogAmount;
      }

      int lastIndex = stackContainer.transform.childCount - 1;

      for (int i = 0; i < stopIndex; i++)
      {
        woodFinishArray[i].SetActive(true);
        woodFinishArray[i].transform.localPosition = new Vector3(
          woodFinishArray[i].transform.localPosition.x + ((laneIndex - 1) * woodShiftPerLane),
          woodFinishArray[i].transform.localPosition.y,
          woodFinishArray[i].transform.localPosition.z);

      }
    }
  }
}