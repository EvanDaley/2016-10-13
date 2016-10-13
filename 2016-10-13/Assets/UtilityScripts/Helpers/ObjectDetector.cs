using UnityEngine;
using System.Collections;

public class ObjectDetector : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		print ("detect");
		transform.parent.BroadcastMessage ("DetectObject", other.gameObject, SendMessageOptions.DontRequireReceiver);
	}
}
