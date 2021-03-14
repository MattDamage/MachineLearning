using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GenerateHuman : MonoBehaviour {
    [Header("Dependencies")]
    public GameObject Body;
    private GameObject BodyMesh;
    private Material Skin;
    private Material Shoes;
    private Material Eyes;
    private Material Cloths;
    private Material Hair;
    private GameObject HairGameObject;
    public SkinnedMeshRenderer SMR;
   
    [Header("Textures")]
    public Texture2D[] EyeTextures;
    public Texture2D[] SkinTextures;
    public Texture2D[] HairTextures;
    public Color[] HairColors;
    [Header("Meshes")]
   
    public Mesh[] HairOptions;
    

    [Header("Options")]
    public int AmountOfShapes;
    public int MaxEdits;

    public bool Girl;

   
  
    public void Generate()
    {

        foreach (Transform Child in transform)
        {
            if (Girl)
            {
                if(Child.name  == "Femalestudent_Hair")
                {
                    HairGameObject = Child.gameObject;

                }
               // Debug.Log(Child.name);
                if (Child.name == "Femalestudent_Body")
                {
                   
                    BodyMesh = Child.gameObject;
                   
                        
                    // if(Child.GetComponent<Material>().name == "")
                }
            } else
            {
                if (Child.name == "Malestudent_Hair")
                {
                    HairGameObject = Child.gameObject;

                }
                if (Child.name == "Malestudent_Body")
                {

                    BodyMesh = Child.gameObject;
                }
            }
        }

        foreach (Material BodyMaterials in BodyMesh.GetComponent<Renderer>().materials)
        {
            Debug.Log(BodyMaterials);
            if (Girl)
            {
                if (BodyMaterials.name == "F_Body (Instance)")
                {
                    Skin = BodyMaterials;
                }
                if (BodyMaterials.name == "F_Eyes (Instance)")
                {
                    Eyes = BodyMaterials;
                }
                if (BodyMaterials.name == "F_Cloths (Instance)")
                {
                    Cloths = BodyMaterials;
                }
                if (BodyMaterials.name == "F_Shoes (Instance)")
                {
                    Shoes = BodyMaterials;
                }
            } else
            {
                if (BodyMaterials.name == "M_Body (Instance)")
                {
                    Skin = BodyMaterials;
                }
                if (BodyMaterials.name == "F_Eyes (Instance)")
                {
                    Eyes = BodyMaterials;
                }
                if (BodyMaterials.name == "M_Cloths (Instance)")
                {
                    Cloths = BodyMaterials;
                }
                if (BodyMaterials.name == "M_Shoes (Instance)")
                {
                    Shoes = BodyMaterials;
                }


            }
        }
        Hair = HairGameObject.GetComponent<Renderer>().material;

        GenerateMesh();
    }

    public void GenerateMesh()
    {
       
       
            for (int i = 0; i < MaxEdits; i++)
            {
                int j = Random.Range(0, AmountOfShapes);
                SMR.SetBlendShapeWeight(j, Random.Range(0, 100));

            }
            Eyes.SetTexture("_MainTex", EyeTextures[Random.Range(0, EyeTextures.Length)]);
            Skin.SetTexture("_MainTex", SkinTextures[Random.Range(0, SkinTextures.Length)]);
            Hair.SetColor("_Color", HairColors[Random.Range(0, HairColors.Length)]);
            Color ClothsColor = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
            Cloths.SetColor("_Color", ClothsColor);
            Color ShoesColor = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
            Shoes.SetColor("_Color", ShoesColor);
            int HairIndex = Random.Range(0, HairOptions.Length);
            HairGameObject.GetComponent<MeshFilter>().mesh = HairOptions[HairIndex];
            Hair.SetTexture("_MainTex", HairTextures[HairIndex]);

        

    }

}
