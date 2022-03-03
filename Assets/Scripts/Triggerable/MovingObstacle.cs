using System;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class MovingObstacle : Obstacle
  {
    [SerializeField] private float speed;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private bool isMovingRight;

    private void FixedUpdate()
    {
      if (isMovingRight)
      {
        transform.position += Vector3.right * speed * Time.fixedDeltaTime;
        if (transform.position.x > maxX)
        {
          isMovingRight = false;
        }
      }
      else
      {
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        if (transform.position.x < minX)
        {
          isMovingRight = true;
        }
      }
    }
  }
}