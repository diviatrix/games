using UnityEngine;
using System.Collections;

public class Logic_speechbubble : MonoBehaviour {

    public GameObject prefab;
    
	
    public void InstantiatePrefab()
    {
        GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        clone.transform.parent = transform.parent;
    }
}
