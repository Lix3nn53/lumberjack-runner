using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lix.LumberjackRunner
{
  public class PlayerAnimationController : MonoBehaviour
  {
    [SerializeField] Rigidbody playerRb;
    Animator animator;

    void Awake()
    {
      this.animator = GetComponent<Animator>();
    }

    void Update()
    {
      animator.SetFloat("SpeedForward", Mathf.Abs(playerRb.velocity.z));
    }

    public void OnWin()
    {
      animator.SetTrigger("Win");
    }

    public void OnGameOverObstacle()
    {
      animator.SetTrigger("Lose");
    }

    public void OnGameOverDrown()
    {
      animator.SetTrigger("Drown");
    }

    public void SetStackAmount(int stackCount)
    {
      animator.SetInteger("StackAmount", stackCount);
    }
  }
}