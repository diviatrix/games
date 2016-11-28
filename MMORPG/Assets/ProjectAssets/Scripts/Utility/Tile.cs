using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{    
    public bool isWalkable;
    public bool isTrigger;
    public bool isVisible;
    

    private void Start()
    {
        // set collider
        this.GetComponent<Collider2D>().enabled = (isWalkable && isTrigger) || (!isWalkable);
        this.GetComponent<Collider2D>().isTrigger = isTrigger && isWalkable;
        // set render
        this.GetComponent<SpriteRenderer>().enabled = isVisible;
        // set trigger
    }
}

