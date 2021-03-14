using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatDNA{

    List<int> genes = new List<int>();
    int DNALenght = 0;
    int maxValue = 0;

    public StayOnPlatDNA(int l, int v) {
        DNALenght = l;
        maxValue = v;
        SetRandom();


    }




	// Use this for initialization
    public void SetRandom () {
        for (int i = 0; i < DNALenght; i++) {
            genes.Add(Random.Range(0,maxValue));

        }


	}
	
	// Update is called once per frame
	void SetInt (int pos, int value) {
        genes[pos] = value;
	}

    public void Combine (StayOnPlatDNA d1, StayOnPlatDNA d2) {
        for (int i = 0; i < DNALenght; i++) {
            if(i < DNALenght/2.0f) {
                int c = d1.genes[i];
                genes[i] = c;

            } else {
                int c = d2.genes[i];
                genes[i] = c;
            }

        }


    }

    public void Mutate() {

        genes[Random.Range(0, DNALenght)] = Random.Range(0, maxValue);

    }


    public int GetGenes(int pos) {
        return genes[pos];

    }
}
