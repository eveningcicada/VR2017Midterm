using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	[SerializeField] Transform decalPrefab;

	public int numDecals;
	[Space(10)]
	public float groundDepth = -0.1f;
	[Space(5)]
	public float groundX = 5;
	public float groundZ = 5;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < numDecals; i++)
		{
			Transform decal = Instantiate(decalPrefab) as Transform;

			float randX = Random.Range(0.25f, 2.5f);
			float randY = Random.Range(0.05f, 0.25f);
			float randZ = Random.Range(0.25f, 2.5f);

			decal.localScale = new Vector3(randX, randY, randZ);
			decal.position = new Vector3(Random.Range(-groundX, groundX), groundDepth, Random.Range(-groundZ, groundZ));
			decal.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
