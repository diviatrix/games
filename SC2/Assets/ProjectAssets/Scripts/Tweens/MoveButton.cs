using UnityEngine;
using System.Collections;

public class MoveButton: MonoBehaviour {

	public void MoveBy(float f)
    {
        gameObject.MoveBy(new Vector3(f, 0, 0), 1, 0);
    }
}
