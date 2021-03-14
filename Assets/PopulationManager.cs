using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PopulationManager : MonoBehaviour
{

    public GameObject botPrefab;
    public int popuationSize = 10;
    List<GameObject> population = new List<GameObject>();
    //public staic
    public float tiralTime = 10;
    int generation = 1;

    public Transform target;

    GUIStyle guistyle = new GUIStyle();
    private void OnGUI()
    {
        guistyle.fontSize = 58;
        guistyle.normal.textColor = Color.white;
        GUI.BeginGroup(new Rect(10,10,250,150));
        GUI.Box(new Rect(10, 25, 200, 30),"Stats", guistyle);
        GUI.Label(new Rect(10, 50, 200, 30), "Gen: " + generation, guistyle);
        GUI.Label(new Rect(10, 75, 200, 30), string.Format("Time: {0:0.00}", elasped), guistyle);
        GUI.Label(new Rect(10, 75, 200, 30), "Time Trial" + elasped + "/ " + tiralTime, guistyle);
    }


    public static float elasped = 0;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < popuationSize; i++)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-2, 2),
                                      this.transform.position.y,
                                      this.transform.position.z + Random.Range(-2, 2));
            
            GameObject go = Instantiate(botPrefab, pos, this.transform.rotation);
            go.GetComponent<StayOnPlatBrain>().Init();

            population.Add(go);

        }
    }

    // Update is called once per frame
    void Update()
    {
        elasped += Time.deltaTime;
        if (elasped > tiralTime)
        {
           // tiralTime = elasped;
            BreedNewPopuation();
            elasped = 0;
            generation++;
        }
    }

    public GameObject Breed(GameObject parent1, GameObject parent2) {
        Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-2, 2),
                                      this.transform.position.y,
                                      this.transform.position.z + Random.Range(-2, 2));

        GameObject offSpring = Instantiate(botPrefab, pos, this.transform.rotation);
        StayOnPlatBrain b = offSpring.GetComponent<StayOnPlatBrain>();
        //b.Target = target.position;
        if (Random.Range(0, 100) == 1)
        {
            b.Init();
            b.dna.Mutate();
           
        } else {
            b.Init();
            b.dna.Combine(parent1.GetComponent<StayOnPlatBrain>().dna,parent2.GetComponent<StayOnPlatBrain>().dna);
        }
        return offSpring;
    }


    public void BreedNewPopuation() {

        List<GameObject> NewPopuation = new List<GameObject>(); 
        List<GameObject> soretedList = population.OrderBy(o => o.GetComponent<StayOnPlatBrain>().timeAlive).ToList();
       
        population.Clear();

        for (int i = (int)(soretedList.Count / 2.0f) - 1; i < soretedList.Count() - 1; i++)
        {
            population.Add(Breed(soretedList[i], soretedList[i + 1]));
            population.Add(Breed(soretedList[i + 1], soretedList[i]));



        }

        for (int i = 0; i < soretedList.Count; i++)
        {
            Destroy(soretedList[i]);


        }


    }


 

}
