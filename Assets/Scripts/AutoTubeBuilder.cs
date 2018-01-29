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
        //if (count > 0) 
        PickPermutation();

        DeletePermutations();
        Destroy(this);
    }

    void PickPermutation()
    {
        var permutations = transform.Find("Permutations");
        var chosenPermutation = Random.Range(0, permutations.childCount);

        //Apply the permutation here
        var permutation = permutations.GetChild(chosenPermutation);
        
        Transform permutationTarget = permutation.GetComponent<Permutation>().target;

        var inst = Instantiate(permutationTarget, permutation.position, permutation.rotation);
        var instRenderer = inst.GetComponent<Renderer>();

        instRenderer.materials[0].SetColor("_Color", globalState.getMainColor());
        instRenderer.materials[2].SetColor("_Color", globalState.getAccentColor());

        globalState.Advance();

        var doc = inst.gameObject.AddComponent<DestroyOnContact>();
        doc.target = this.gameObject;
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
