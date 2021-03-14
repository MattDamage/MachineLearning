using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatBrain : MonoBehaviour {

    int DNALength = 2;
    public float timeAlive;
    public StayOnPlatDNA dna;
    public GameObject eyes;
    public bool alive = true;
    bool SeeGround = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dead") {
            alive = false;

        }
    }


    public void Init() {
        dna = new StayOnPlatDNA(DNALength, 3);
        alive = true;

    }

    public void Update() {
        if(!alive){
            return;

        }
        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, 10);
        RaycastHit hit;

        if(Physics.Raycast(eyes.transform.position,eyes.transform.forward * 10, out hit)) {
            if(hit.collider.gameObject.tag == "Platform" ) {
                SeeGround = false;

            }
           
        } 
        timeAlive = PopulationManager.elasped;
        float h = 0;
        float v = 0;
        if(SeeGround) {
            if(dna.GetGenes(0) == 0) {
                v = 1;

            } else if (dna.GetGenes(0) == 1) {
                h = -90;

            }    
            else if (dna.GetGenes(0) == 2) {
                h = 90;

            }    
        } else {
            if(dna.GetGenes(1) == 0) {
                v = 1;

            } else if (dna.GetGenes(1) == 1) {
                h = -90;

            }    
            else if (dna.GetGenes(1) == 2) {
                h = 90;

            }    

        }
        this.transform.Translate(0,0,v * 0.1f);
        this.transform.Rotate(0, h, 0);
    }
}
