using UnityEngine;
using System.Collections;

public class AutomaticGunPickup : MonoBehaviour 
{
	public WeaponControl weaponControl;
	public GameObject gun;
	public GameObject toDestroy;

	void DetectObject()
	{
		GameObject weapon = GameObject.Instantiate (gun, transform.position, transform.rotation) as GameObject;
		Gun gunScript = weapon.AddComponent<Gun> ();
		weaponControl.EquipRight (gunScript);

		Destroy (toDestroy);

	}
}
