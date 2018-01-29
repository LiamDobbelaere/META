using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTubeBuilder : MonoBehaviour
{
    private GlobalState globalState;

    // Use this for initialization
    void Start()
    {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Continue();
    }

    void Continue()
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
        Destroy(this);
    }

    void InstantiateAllPermutations()
    {
        var perms = transform.Find("Permutations");
        var permutation = perms.GetChild(0);

        Transform permutationTarget = permutation.GetComponent<Permutation>().target;

        var aInst = Instantiate(permutationTarget, permutation.position, permutation.rotation);
        var instRenderer = aInst.GetComponent<Renderer>();
        var doc = aInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;

        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        permutation = perms.GetChild(1);

        permutationTarget = permutation.GetComponent<Permutation>().target;

        var bInst = Instantiate(permutationTarget, permutation.position, permutation.rotation);
        instRenderer = bInst.GetComponent<Renderer>();
        doc = bInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;
        
        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        doc = aInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = bInst.gameObject;

        doc = bInst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = aInst.gameObject;

        globalState.Advance();
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
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        globalState.Advance();
    }

    void DeletePermutations()
    {
        var permutations = transform.Find("Permutations");

        for (int i = 0; i < permutations.childCount; i++)
        {
            Destroy(permutations.GetChild(i).gameObject);
        }
    }
}
