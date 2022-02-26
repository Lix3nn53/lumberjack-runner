using System;
using UnityEngine;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class ObstacleGroup : Triggerable
  {
    private static float hitBoxWidth = 0.9f;

    [Serializable]
    public struct ObstacleLine
    {
      public int start;
      public int height;
    }

    [SerializeField] private ObstacleLine[][] lines;

    // Dependencies
    private PlayerCollider playerCollider;
    private PlayerMovement playerMovement;
    private TrackManager trackManager;

    private void Start()
    {
      playerCollider = DIContainer.GetService<PlayerCollider>();
      playerMovement = DIContainer.GetService<PlayerMovement>();
      trackManager = DIContainer.GetService<TrackManager>();

      RandomShape();
      // AutoFillLineData(); // Random Shape already fills the data
    }

    public override void OnTrigger(Collider other)
    {
      var go = other.gameObject;
      if (go == null || !other.gameObject.CompareTag("Player"))
        return;

      float line = playerMovement.gameObject.transform.localPosition.z;

      int indexMin = (int)(line);
      int indexMax = (int)(line + hitBoxWidth);

      ObstacleLine[] parts;
      if (indexMin < 0)
      {
        parts = lines[indexMax];
      }
      else if (indexMax > 4)
      {
        parts = lines[indexMin];
      }
      else
      {
        ObstacleLine[] x = lines[indexMin];
        ObstacleLine[] y = lines[indexMax];

        parts = new ObstacleLine[x.Length + y.Length];
        x.CopyTo(parts, 0);
        y.CopyTo(parts, x.Length);
      }

      playerCollider.OnObstacle(parts);
    }

    public void RandomShape()
    {
      lines = new ObstacleLine[5][]; // Save data
      for (int i = 0; i < 5; i++)
      {
        Transform obstacleLine = transform.GetChild(i);

        int obstacleCount = UnityEngine.Random.Range(0, 4);
        lines[i] = new ObstacleLine[obstacleCount]; // Save data

        float startHeight = trackManager.ObstacleStartHeight;
        for (int y = 0; y < obstacleCount; y++)
        {
          GameObject obstacle = PoolManager.Get("ObstaclePool").Pool.Get();
          obstacle.transform.SetPositionAndRotation(new Vector3(0, startHeight, 0), Quaternion.identity);
          obstacle.transform.SetParent(obstacleLine);
          int obstacleHeight = UnityEngine.Random.Range(1, 3);
          obstacle.transform.localScale = new Vector3(1, obstacleHeight, 1);
          obstacle.transform.localPosition = new Vector3(0, startHeight, 0);

          // Save data
          ObstacleLine obstaclePart = new ObstacleLine() { start = (int)startHeight, height = obstacleHeight };
          lines[i][y] = obstaclePart;

          startHeight += obstacleHeight + 1;
        }
      }
    }
  }
}