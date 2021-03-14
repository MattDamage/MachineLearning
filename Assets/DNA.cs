using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {


    public List<int> genes = new List<int>();

    public int DNALength;
    public int maxValues;

	// Use this for initialization
    public DNA(int l, int v) {
        
        DNALength = l;
        maxValues = v;
        SetRandom(); 


	}
    public void SetRandom() {
        genes.Clear();
        for (int i = 0; i < DNALength; i ++) {

            genes.Add(Random.Range(0,maxValues));

        }


    }


    public void SetInt(int pos, int value) {
        genes[pos] = value;


    }

    public void Combine(DNA d1, DNA d2)
    {

        for (int i = 0; i < DNALength; i++)
        {

            if (i < DNALength / 2.0f)
            {
                int c = d1.genes[i];
                genes[i] = c;

            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }


        }

    }

    public void Mutate() {
        genes[Random.Range(0, DNALength)] = Random.Range(0, maxValues);


    }

    public int GetGene(int pos) {
        return genes[pos];


    }

}
