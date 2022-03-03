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

    protected override void Update()
    {
      base.Update();

      if (isMovingRight)
      {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if (transform.position.x > maxX)
        {
          isMovingRight = false;
        }
      }
      else
      {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < minX)
        {
          isMovingRight = true;
        }
      }
    }
  }
}