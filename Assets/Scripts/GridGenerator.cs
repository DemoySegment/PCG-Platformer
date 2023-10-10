using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject blockGameObject;
    public float perlinScale = 0.1f;
    public float minHeight = 0.5f;
    public float maxHeight = 100.0f;
    public int num_blocks = 5;
    public int num_jump_blocks = 2; // Assuming you want a certain number of jumpable blocks.
    public Bounds bounds;
    private List<GameObject> blocks = new List<GameObject>();
    public bool playerOnFloor;
    public GameObject player;
    public GameObject removeBlock;
    public FloorDetection floorDetector;

    public GameObject Target;
    public int num_Targets;

    void Start()
    {

        Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i < num_blocks; i++)
        {
            GeneratePlatform();
        }

        // Set jumpable flag for a specified number of blocks
        for (int i = 0; i < num_jump_blocks - 1; i++)
        {
            int randomIndex = Random.Range(1, blocks.Count);
            if (blocks[randomIndex].GetComponent<Jump>().isJumpable != true)
            {
                blocks[randomIndex].GetComponent<Jump>().isJumpable = true;
            }
            else
            {
                randomIndex = Random.Range(1, blocks.Count);
                blocks[randomIndex].GetComponent<Jump>().isJumpable = true;

            }
        }

        for (int i = 0; i < num_Targets; i++)
        {
            int randomIndex = Random.Range(1, blocks.Count);

            if (blocks[randomIndex].GetComponent<Jump>().isJumpable != true)
            {
                blocks[randomIndex].GetComponent<Jump>().isTarget = true;
            }
            else
            {
                randomIndex = Random.Range(1, blocks.Count);
                blocks[randomIndex].GetComponent<Jump>().isTarget = true;

            }
        }

        blocks[0].GetComponent<Jump>().isJumpable = true;
        blocks[0].name = "InitalPad";
    }

    void GeneratePlatform()
    {
        bounds = GetComponent<Collider>().bounds;

        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        Vector3 platformPosition;
        if (blocks.Count == 0)
        {
            platformPosition = bounds.center + new Vector3(offsetX, 0f, offsetZ);
            platformPosition.y = 3f;
            platformPosition.x = Mathf.Clamp(platformPosition.x, bounds.min.x + 1, bounds.max.x - 1);
            platformPosition.z = Mathf.Clamp(platformPosition.z, bounds.min.z + 1, bounds.max.z - 1);
        }
        else
        {
            platformPosition = bounds.center + new Vector3(offsetX, 0f, offsetZ);
            float heightValue = Mathf.PerlinNoise(platformPosition.x * perlinScale, platformPosition.z * perlinScale);
            float platformHeight = Mathf.Lerp(minHeight, maxHeight, heightValue);
            platformPosition.y = platformHeight;
        }

        /* if (playerOnFloor && blocks.Count!=0)
         {
             platformPosition = bounds.center + new Vector3(offsetX, 0f, offsetZ);
             platformPosition.y = 1f;
             platformPosition.x = Mathf.Clamp(platformPosition.x, bounds.min.x + 1, bounds.max.x - 1);
             platformPosition.z = Mathf.Clamp(platformPosition.z, bounds.min.z + 1, bounds.max.z - 1);
             Debug.Log("Here");
         }*/
        GameObject platform = GameObject.Instantiate(blockGameObject, platformPosition, Quaternion.identity) as GameObject;
        blocks.Add(platform);
    }

    private void Update()
    {
       
        if (blocks.Contains(removeBlock))
        {
            if (removeBlock != null)
            {
                if (removeBlock.name == "InitalPad")
                {
                    floorDetector.gameOverTrigger = true;

                }
            }
            else
            {
                blocks.Remove(removeBlock);
                GeneratePlatform();
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    blocks[^1].GetComponent<Jump>().isJumpable = true;
                    blocks[^1].GetComponent<Jump>().isTarget = false;


                }
                else if (rand == 1)
                {

                    blocks[^1].GetComponent<Jump>().isJumpable = false;
                    blocks[^1].GetComponent<Jump>().isTarget = true;
                }

            }

           
        }

      
    }

   
}
