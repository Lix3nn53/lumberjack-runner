using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lix.CubeRunner
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
      animator.SetFloat("SpeedY", Mathf.Abs(playerRb.velocity.y));
    }
  }
}