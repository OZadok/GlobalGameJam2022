using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FamilyMovementManager : MonoBehaviour
{
    public GameObject hood;
    Bounds hoodBounds;
    LayerMask houseMask;
    public Transform[] gatheringSpotPositions;
    GatheringSpot[] gatheringSpots;
    struct GatheringSpot {
        public Vector3 pos;
        public FamilyType family;
        public GatheringSpot(Vector3 pos, FamilyType family)
        {
            this.pos = pos;
            this.family = family;
        }
    }

    void Start()
    {
        ResetHoodBounds();
        ResetGatheringSpots(gatheringSpotPositions);
        houseMask = LayerMask.GetMask("House");
    }

    void Update()
    {
    }

    public Vector3 RequestDestination(FamilyMemberScript requester) {
        return GetRandomPosition();
    }

    Vector3 GetRandomPosition() {
        float minX = (hoodBounds.center - hoodBounds.extents).x;
        float maxX = (hoodBounds.center + hoodBounds.extents).x;
        float minZ = (hoodBounds.center - hoodBounds.extents).z;
        float maxZ = (hoodBounds.center + hoodBounds.extents).z;

        Vector3 possiblePosition;
        Vector3 rayOrigin;
        RaycastHit hit;

        //TODO: switch to NavMesh.SamplePosition
        for (int i = 0; i < 50; i++)
        {
            possiblePosition = new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));
            rayOrigin = possiblePosition + new Vector3(0f, 10f, 0f);
            if (Physics.Raycast(new Ray(rayOrigin, Vector3.down), out hit, 10f, houseMask))
                continue;
            else
                return possiblePosition;
        }
        throw new UnityException("couldnt find a value for family member destination");
    }
    
    void ResetHoodBounds() {
        hoodBounds = new Bounds(new Vector3(0,0,0), Vector3.one);
        BoxCollider[] colliders = hood.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider collider in colliders)
            hoodBounds.Encapsulate(collider.bounds);
    }

    void ResetGatheringSpots(Transform[] gatheringSpotPositions) {
        this.gatheringSpots = new GatheringSpot[gatheringSpotPositions.Length];
        for (int i = 0; i < gatheringSpots.Length; i++)
            this.gatheringSpots[i] = new GatheringSpot(gatheringSpotPositions[i].position, FamilyType.None);
    }

    GatheringSpot AssignGatheringSpot(FamilyType familyType) {
        bool isGatheringSpotSelected = false;
        int i = -1;
        while (!isGatheringSpotSelected) {
            i = Mathf.FloorToInt(Random.Range(0, gatheringSpots.Length));
            if (gatheringSpots[i].family == FamilyType.None) {
                gatheringSpots[i].family = familyType;
                isGatheringSpotSelected = true;
            }
        }
        for (int j = 0; j < gatheringSpots.Length; j++) {
            if (j != i && gatheringSpots[j].family == familyType) {
                gatheringSpots[j].family = FamilyType.None;
            }
        }
        return gatheringSpots[i];
    }


}
