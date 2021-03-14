using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    public float r;
    public float g;
    public float b;

    public float Scale;

    public bool dead;

    public float timeToDie;

    List<int> Genes = new List<int>();

   

    public SpriteRenderer rend;
    public Collider2D SCollider;

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        SCollider = GetComponent<Collider2D>();
        rend.color = new Color(r, g, b);
        transform.localScale = new Vector3(Scale, Scale, 1);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    private void OnMouseDown()
    {
        dead = true;
        timeToDie = PopulationManager.elasped;
        Debug.Log("Dead At:" + timeToDie);
        rend.enabled = false;
        SCollider.enabled = false;
    }
    */

   


}

