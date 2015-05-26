using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    public GameObject RotateTarget;
    public float RotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(RotateTarget.transform);
        transform.Translate(Vector3.right * Time.deltaTime * RotateSpeed);
	}
}
