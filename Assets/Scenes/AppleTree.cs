using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject   applePrefab;
    public GameObject   bombPrefab;

    // Speed at which the AppleTree moves
    public float        speed = 1f;

    // Distance where AppleTree turns around
    public float        leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float        chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float        secondsBetweenAppleDrops = 1f;

    public float         chanceToDropBomb = 0.1f;

    void Start () {
        // Dropping apples every second
        Invoke( "DropApple", 2f );                                      // a
    }

    void DropApple() {                                                  // b
        GameObject prefabToSpawn;
        if (Random.value < chanceToDropBomb) {
            prefabToSpawn = bombPrefab;
        } else {
            prefabToSpawn = applePrefab;
        }
        GameObject go = Instantiate( prefabToSpawn ) as GameObject;              // c
        go.transform.position = transform.position;
        Invoke( "DropApple", secondsBetweenAppleDrops );                          // d
    }
    void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if ( pos.x < -leftAndRightEdge ) {
            speed = Mathf.Abs(speed);  // Move right
        } else if ( pos.x > leftAndRightEdge ) {
            speed = -Mathf.Abs(speed); // Move left
        }                                                                    // a
    }

    void FixedUpdate() {
        // Changing Direction Randomly is now time-based because of FixedUpdate()
        if ( Random.value < chanceToChangeDirections ) {                     // b
            speed *= -1; // Change direction
        }
    }
}