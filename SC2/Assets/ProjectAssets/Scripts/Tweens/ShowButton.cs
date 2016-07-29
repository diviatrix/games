using UnityEngine;
using System.Collections;

public class ShowButton : MonoBehaviour {
    public float range, speed;
	// Use this for initialization
	void Start () {
        gameObject.MoveBy(new Vector3(0, range, 0), speed, 0,EaseType.linear,LoopType.pingPong);
    }
}
