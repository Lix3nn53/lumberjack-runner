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
    [SerializeField] private float heightPerStack = 0.5f;
    [SerializeField] private float offsetYOnCollect = 0.1f;

    private PlayerMovement playerMovement;
    private GameManager gameManager;
    private AudioManager audioManager;
    private PlayerAnimationController playerAnimationController;
    private void Start()
    {
      playerMovement = DIContainer.GetService<PlayerMovement>();
      gameManager = DIContainer.GetService<GameManager>();
      audioManager = DIContainer.GetService<AudioManager>();
      playerAnimationController = DIContainer.GetService<PlayerAnimationController>();

      playerAnimationController.SetStackAmount(GetStackCount());
    }

    public int GetStackCount()
    {
      return stackContainer.transform.childCount;
    }

    public void OnStack(GameObject stack)
    {
      // The logs player is carrying affacted by gravity
      stack.GetComponent<BoxCollider>().isTrigger = false;
      stack.GetComponent<Rigidbody>().isKinematic = false;

      int stackCount = GetStackCount();

      // Add New Stack To Container
      stack.transform.SetParent(this.stackContainer.gameObject.transform);
      if (stackCount > 0)
      {
        float localY = stackContainer.transform.GetChild(stackCount - 1).transform.localPosition.y + this.heightPerStack + this.offsetYOnCollect;
        stack.transform.localPosition = new Vector3(0, localY, 0);
      }
      else
      {
        float localY = this.heightPerStack + this.offsetYOnCollect;
        stack.transform.localPosition = new Vector3(0, localY, 0);
      }

      // Play Sound
      audioManager.Play("OnStack");
      playerAnimationController.SetStackAmount(GetStackCount());
    }

    public void OnObstacle()
    {
      int toRemove = 1;

      // Check for gameover
      int count = GetStackCount();
      if (count < toRemove)
      { // Gameover if player is below required height or if player loses all cubes 
        playerMovement.StopRunning();
        gameManager.GameOver(false);
        return;
      }

      int lastIndex = count - 1;
      GameObject cubeToRemove = this.stackContainer.transform.GetChild(lastIndex).gameObject;
      // cubeToRemove.transform.SetParent(null); // Add dropped cube to thrash of current segment
      Destroy(cubeToRemove);
      playerAnimationController.SetStackAmount(GetStackCount());
    }

    public void OnWaterObstacle(WaterObstacle waterObstacle)
    {
      waterObstacle.FormLane(this.stackContainer, this.transform.position.x);
      playerAnimationController.SetStackAmount(GetStackCount());
    }

    public void OnFinish(Finish finish)
    {
      finish.OnFinishCallback(this.stackContainer, this.transform.position.x);
      Destroy(this.stackContainer);
      playerAnimationController.SetStackAmount(0);
    }

    public void OnDrown()
    {
      Destroy(this.stackContainer);
    }
  }
}