using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject blockGameObject;
    // public Transform jumpPads;

    // Define parameters for Perlin noise
    public float perlinScale = 0.1f;
    public float minHeight = 0.5f;
    public float maxHeight = 100.0f;
    private List<GameObject> blocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
      


        Bounds bounds = GetComponent<Collider>().bounds;
        Random.InitState(System.DateTime.Now.Millisecond); // Set a new seed based on the current time



        for (int i = 0; i < 30; i++)
        {
            // Generate random positions within the bounds
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
            Vector3 platformPosition = bounds.center + new Vector3(offsetX, 0f, offsetZ);

            // Use Perlin noise for vertical height
            float heightValue = Mathf.PerlinNoise(platformPosition.x * perlinScale, platformPosition.z * perlinScale);
            float platformHeight = Mathf.Lerp(minHeight, maxHeight, heightValue);
            platformPosition.y = platformHeight;

            // Instantiate and position the platform
            GameObject platform =  GameObject.Instantiate(blockGameObject,platformPosition,Quaternion.identity) as GameObject;
           // platform.transform.position = platformPosition;
           // platform.transform.SetParent( jumpPads.transform,true) ;
            blocks.Add(platform);
        }
      

        for(int i = 0;i<25;i++)
        {

            blocks[Random.Range(0, blocks.Count - 1)].GetComponent<Jump>().isJumpable = true;
        }
        int jCount = 0;
        for(int i =0; i<blocks.Count;i++)
        {
            
            if (blocks[i].GetComponent<Jump>().isJumpable == true)
            {
                jCount++;
            }

        }
        Debug.Log(jCount);

    }

 
}
