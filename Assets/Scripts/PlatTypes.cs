using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTypes : MonoBehaviour
{
    // Mats to represent what type it is
    public Material type1;
    public Material type2;
    public Material type3;
    public Material type4;
    public Material type5;

    private PlayerController player;

    // Moving Platforms variable
    public float speed = 1f;
    public float leftBoundary = -10.0f;
    public float rightBoundary = 10.0f;
    private int direction = 1;
    public Vector3 spawnPoint;
    private Rigidbody rb;
    
    public GameObject play;

    int type;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        var _Rdr = GetComponent<Renderer>();
        //type = Random.Range(1,5);
        type = 4;
        
        if(type == 1){
            _Rdr.material = type1;
        }
        if(type == 2){
            _Rdr.material = type2;
        }
        if(type == 3){
            _Rdr.material = type3;
        }
        if(type == 4){
            _Rdr.material = type4;
        }
        if(type == 5){
            _Rdr.material = type5;
        }
    }
    
    void OnCollisionEnter(Collision other){
        Collider collider = other.collider;
        print(type);
        if(other.gameObject.CompareTag("Player")){
            if(type == 1){
                print("hit");
            }
            if(type == 2){
                print("ReverseGrav");
                StartCoroutine(RevGrav());
            }
            if(type == 3){
                print("SpawnEnemy");
            }
            if(type == 4){
                print("Horizontal");
                play.transform.parent.parent = transform;
            }
            if(type == 5){
                print("Vertical");
                other.gameObject.transform.parent.parent = transform;
            }
            
        }
        }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Player")){
            play.transform.parent.parent = null;
        }
    }
    
    IEnumerator RevGrav(){
        float og = player.gravity;
        player.gravity = Mathf.Abs(og);
        yield return new WaitForSeconds(2);
        player.gravity = -Mathf.Abs(og);
    }

    void Update()
    {
        if(type == 4){
            Horizontal();
        }
        else if(type == 5){
            Vertical();
        }
    }

    void Horizontal()
    {
        float newPosition = transform.position.x + direction * speed * Time.deltaTime;
        if (newPosition > spawnPoint.x + rightBoundary)
        {
            direction = -1;
        }
        else if (newPosition < spawnPoint.x + leftBoundary)
        {
            direction = 1;
        }
        Vector3 move = new Vector3(direction * speed, 0,0);
        rb.velocity = move;
    }

    void Vertical()
    {
        
        float newPosition = transform.position.y + direction * speed * Time.deltaTime;
        if (newPosition > spawnPoint.y + rightBoundary)
        {
            direction = -1;
        }
        else if (newPosition < spawnPoint.y + leftBoundary)
        {
            direction = 1;
        }
        Vector3 move = new Vector3(0, direction * speed ,0);
        rb.velocity = move;
    }

    
}
