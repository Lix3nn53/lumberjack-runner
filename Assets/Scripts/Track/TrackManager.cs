using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class TrackManager : MonoBehaviour
  {
    #region Public Fields

    [Header("TrackSegment")]
    [SerializeField] private GameObject segmentPartPrefab;
    [SerializeField] private float segmentLength = 50;

    [Header("BetweenParts")]
    [SerializeField] private GameObject betweenPartsPrefab;
    [SerializeField] private int cubeLength = 1;
    [SerializeField] private int cubeDistanceBetween = 4;

    [Header("Obstacle")]
    public float ObstacleStartHeight = 0.5f;

    #endregion

    #region Private Fields
    private TrackSegment[] segmentPrefabs;

    private TrackSegment[] segmentBuffer;

    #endregion

    #region Dependencies
    private PlayerMovement playerMovement;

    #endregion

    #region Unity Methods

    private void Start()
    {
      // Init dependencies
      playerMovement = DIContainer.GetService<PlayerMovement>();

      // Init prefabs
      this.segmentPrefabs = new TrackSegment[transform.childCount];
      for (int i = 0; i < segmentPrefabs.Length; i++)
      {
        Transform segment = transform.GetChild(i);

        this.segmentPrefabs[i] = segment.GetComponent<TrackSegment>();
      }

      // Init buffer
      this.segmentBuffer = new TrackSegment[segmentPrefabs.Length];

      for (int i = 0; i < segmentBuffer.Length; i++)
      {
        this.segmentBuffer[i] = this.segmentPrefabs[i];

        this.segmentBuffer[i].transform.position = new Vector3(-segmentLength + (i * segmentLength), 0, 0);
      }

      for (int i = 2; i < segmentBuffer.Length; i++)
      {
        this.segmentBuffer[i].OnStart(segmentPartPrefab, betweenPartsPrefab, cubeLength, cubeDistanceBetween, segmentLength);
      }
    }

    void FixedUpdate()
    {
      Vector3 position = playerMovement.transform.position;
      float distance = position.x;

      if (distance > segmentLength)
      {
        playerMovement.transform.position = new Vector3(0, position.y, position.z);

        TrackSegment temp = this.segmentBuffer[0]; // save 0 for moving to end

        for (int i = 0; i < segmentBuffer.Length - 1; i++)
        {
          this.segmentBuffer[i] = this.segmentBuffer[i + 1];

          this.segmentBuffer[i].transform.position = new Vector3(-segmentLength + (i * segmentLength), 0, 0);
        }

        this.segmentBuffer[segmentBuffer.Length - 1] = temp;
        this.segmentBuffer[segmentBuffer.Length - 1].transform.position = new Vector3(-segmentLength + (segmentLength * (segmentBuffer.Length - 1)), 0, 0);
        // Regenerate the segment while moving from 0 to the end
        this.segmentBuffer[segmentBuffer.Length - 1].OnRestart(segmentPartPrefab, betweenPartsPrefab, cubeLength, cubeDistanceBetween, segmentLength);
      }
    }

    #endregion

    #region Public Methods

    public TrackSegment GetCurrentSegment()
    {
      return this.segmentBuffer[1];
    }

    #endregion
  }
}