using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  /// <summary>
  /// The PlayerCollider handles what happens when the player collides with something.
  /// 
  /// The Player can collide with:
  /// - Cube
  /// - Obstacle
  /// - Crystal
  /// </summary>
  public class PlayerCollider : MonoBehaviour
  {
    [SerializeField] private GameObject graphicsContainer;
    [SerializeField] private GameObject stackContainer;
    [SerializeField] private GameObject playerGraphics;
    [SerializeField] private float heightPerStack = 0.5f;
    [SerializeField] private float offsetYOnCollect = 0.1f;

    private PlayerMovement playerMovement;
    private TrackManager trackManager;

    private void Start()
    {
      playerMovement = DIContainer.GetService<PlayerMovement>();
      // trackManager = DIContainer.GetService<TrackManager>();
    }

    public void OnStack(GameObject stack)
    {
      int stackCount = this.stackContainer.transform.childCount;

      // Add New Stack To Container
      stack.transform.SetParent(this.stackContainer.gameObject.transform);
      float localY = stackContainer.transform.GetChild(stackCount - 1).transform.localPosition.y + this.heightPerStack + this.offsetYOnCollect;
      stack.transform.localPosition = new Vector3(0, localY, 0);

      // Player player = go.GetComponent<Player>();

      // player.SetSelectedInterractable(this);

      // AudioManager.Instance.Play("interractEnter");
    }
    public void OnObstacle(ObstacleGroup.ObstacleLine[] parts)
    {
      List<int> toRemove = new List<int>();
      int requiredHeight = 0;
      foreach (ObstacleGroup.ObstacleLine part in parts)
      {
        int currentHeight = part.start + part.height;
        if (currentHeight > requiredHeight)
        {
          requiredHeight = currentHeight;
        }

        for (int i = part.start; i < part.start + part.height; i++)
        {
          toRemove.Add(i);
        }
      }

      // Remove playerCubes from player
      if (toRemove.Count > 1)
      {
        toRemove = toRemove.Distinct().ToList();
        toRemove.Sort();
      }

      // Check for gameover
      int count = this.stackContainer.transform.childCount;
      if (count < requiredHeight || count <= toRemove.Count)
      { // Gameover if player is below required height or if player loses all cubes 
        playerMovement.StopRunning();
        Debug.Log("GAME OVER");
        return;
      }

      int lastIndex = count - 1;
      foreach (int i in toRemove)
      {
        GameObject cubeToRemove = this.stackContainer.transform.GetChild(lastIndex - i).gameObject;
        cubeToRemove.transform.SetParent(trackManager.GetCurrentSegment().DroppedCubeThrash.transform); // Add dropped cube to thrash of current segment
        cubeToRemove.transform.localPosition = new Vector3((int)(cubeToRemove.transform.localPosition.x), cubeToRemove.transform.localPosition.y, cubeToRemove.transform.localPosition.z);
      }
    }
  }
}