using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GenerateMesh))]
public class PlaceObjects : MonoBehaviour
{

    public TerrainController TerrainController { get; set; }

    public void Place() {
        int numObjects = Random.Range(TerrainController.MinObjectsPerTile, TerrainController.MaxObjectsPerTile);
        for (int i = 0; i < numObjects; i++)
        {
            int prefabType = Random.Range(0, TerrainController.PlaceableObjects.Length);
            int rock = Random.Range(0, TerrainController.Rocks.Length);
            //Debug.Log(prefabType.ToString());
            Vector3 startPoint = RandomPointAboveTerrain();

            RaycastHit hit;
            if (Physics.Raycast(startPoint, Vector3.down, out hit) && hit.point.y > TerrainController.Water.transform.position.y && hit.collider.CompareTag("Terrain"))
            {
                int e = ((int)Random.Range(0f, 5f));
                if(e == 2)
                {
                    Quaternion orientation = Quaternion.Euler(Vector3.up * Random.Range(0f, 360f));
                    Instantiate(TerrainController.PlaceableObjects[prefabType], new Vector3(startPoint.x, hit.point.y, startPoint.z), orientation, transform);
                }

                int f = ((int)Random.Range(0f, 15f));
                if(f == 12)
                {
                    Quaternion orientation = Quaternion.Euler(Vector3.up * Random.Range(0f, 360f));
                    Instantiate(TerrainController.Rocks[rock], new Vector3(startPoint.x, hit.point.y, startPoint.z), orientation, transform);
                }
            }

        }
    }

    private Vector3 RandomPointAboveTerrain()
    {
        return new Vector3(
            Random.Range(transform.position.x - TerrainController.TerrainSize.x / 2, transform.position.x + TerrainController.TerrainSize.x / 2),
            transform.position.y + TerrainController.TerrainSize.y * 2,
            Random.Range(transform.position.z - TerrainController.TerrainSize.z / 2, transform.position.z + TerrainController.TerrainSize.z / 2)
        );
    }
}