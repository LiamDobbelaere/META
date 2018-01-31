using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTubeBuilder : MonoBehaviour
{
    private GlobalState globalState;
    private bool hasBuilt = false;
    private bool growOnContact = false;

    // Use this for initialization
    void Start()
    {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalState.activeTubes < 4) Continue();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (growOnContact)
                hasBuilt = false;

            if (gameObject.name.Contains("Split"))
                globalState.scoreMultiplier++;
        }
    }

    public void Continue()
    {
        if (!hasBuilt)
        {
            if (gameObject.name.Contains("SplitTubePermutation"))
            {
                InstantiateAllPermutations();
            }
            else
            {
                PickPermutation();
            }

            DeletePermutations();
            hasBuilt = true;
        }
    }

    void InstantiateAllPermutations()
    {
        var perms = transform.Find("Permutations");
        var permutation = perms.GetChild(0);

        Transform permutationTarget = permutation.GetComponent<Permutation>().target;

        var aInst = Instantiate(permutationTarget, permutation.position, permutation.rotation);
        aInst.GetComponent<AutoTubeBuilder>().hasBuilt = true;
        aInst.GetComponent<AutoTubeBuilder>().growOnContact = true;
        var instRenderer = aInst.GetComponent<Renderer>();
        var doc = aInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;

        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[1].SetColor("_EmissionColor", globalState.getTubeColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        permutation = perms.GetChild(1);

        permutationTarget = permutation.GetComponent<Permutation>().target;

        var bInst = Instantiate(permutationTarget, permutation.position, permutation.rotation);
        bInst.GetComponent<AutoTubeBuilder>().hasBuilt = true;
        bInst.GetComponent<AutoTubeBuilder>().growOnContact = true;
        instRenderer = bInst.GetComponent<Renderer>();
        doc = bInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;

        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[1].SetColor("_EmissionColor", globalState.getTubeColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        doc = aInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = bInst.gameObject;

        doc = bInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = aInst.gameObject;

        globalState.activeTubes += 2;
    }

    void PickPermutation()
    {
        var permutations = transform.Find("Permutations");

        //var chosenPermutation = Random.Range(0, permutations.childCount);

        //Apply the permutation here
        var permutation = globalState.getNextPermutation(permutations);
        
        Transform permutationTarget = permutation.GetComponent<Permutation>().target;

        var inst = Instantiate(permutationTarget, permutation.position, permutation.rotation);
        var instRenderer = inst.GetComponent<Renderer>();
        
        var doc = inst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;


        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[1].SetColor("_EmissionColor", globalState.getTubeColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        globalState.activeTubes++;

        var obstacles = inst.Find("Obstacles");

        if (obstacles != null) {
            //Deactivate all obstacles
            foreach (Transform obst in obstacles)
            {
                obst.gameObject.SetActive(false);
            }

            //Activate one obstacle
            int obstacleCount = obstacles.childCount;
            int chosenObstacle = Random.Range(0, obstacleCount);

            Color laserColor = globalState.getMainColor();

            if (laserColor.r == 0 && laserColor.g == 0 && laserColor.b == 0) laserColor = Color.red;

            var obgo = obstacles.GetChild(chosenObstacle).gameObject;
            obgo.SetActive(true);

            laserColor.a = 0.25f;
            
            //obgo.GetComponent<BlinkObstacle>().targetColor = laserColor;
            obgo.GetComponent<Renderer>().materials[0].SetColor("_Color", laserColor);

            if (obgo.transform.childCount > 0)
            {
                foreach (Transform t in obgo.transform) {
                    //t.GetComponent<BlinkObstacle>().targetColor = laserColor;
                    t.GetComponent<Renderer>().materials[0].SetColor("_Color", laserColor);
                }
            }

        }
    }

    void DeletePermutations()
    {
        var permutations = transform.Find("Permutations");

        foreach (Transform permutation in permutations)
        {
            Destroy(permutation.gameObject);
        }
    }
}
