using System.Collections;
using System.Collections.Generic;                                          // a
using UnityEngine;
using UnityEngine.SceneManagement;   
using UnityEngine.UI;                                      // b

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject       basketPrefab;
    public int              numBaskets = 4;
    public float            basketBottomY = -14f;
    public float            basketSpacingY = 2f;
    public List<GameObject> basketList;

    public Text roundText;

    void Start () {
        basketList = new List<GameObject>();                               // c
        for (int i=0; i<numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );                                   // d
        }
        updateRoundText();
    }

    public void AppleDestroyed() {
        // Destroy all of the falling apples
        GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tGO in tAppleArray ) {
            Destroy( tGO );
        }

        // Destroy one of the baskets                                      // e
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count-1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy( tBasketGO );

          if ( basketList.Count == 0 ) {
            SceneManager.LoadScene( "_Scene_GameOver" );                              // a
        }
        if (basketList.Count > 0) {
            updateRoundText();
        }
    } 

    void updateRoundText() {
        int roundNumber = (numBaskets - basketList.Count) + 1;
        roundText.text = "Round: " + roundNumber.ToString();
    }
}