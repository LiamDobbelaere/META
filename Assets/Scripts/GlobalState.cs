using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : MonoBehaviour {
    public Color[] paletteColorsMain;
    public Color[] paletteColorsAccent;

    private int counter;
    private int currentPaletteColor;

    private int bendCount;
    private int maxBendCount = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Color getMainColor()
    {
        return paletteColorsMain[currentPaletteColor];
    }

    public Color getAccentColor()
    {
        return paletteColorsAccent[currentPaletteColor];
    }

    public void Advance()
    {
        if (++counter > 5)
        {
            if (++currentPaletteColor >= paletteColorsMain.Length)
            {
                currentPaletteColor = 0;
            }

            counter = 0;
        }
    }

    public Transform getNextPermutation(Transform permutations)
    {
        bool bendsOnly = false;

        if (++bendCount > maxBendCount)
        {
            bendsOnly = true;
            bendCount = 0;
        }

        List<Transform> options = new List<Transform>();

        foreach (Transform t in permutations) 
        {
            if (bendsOnly)
            {
                if (t.name.Equals("BendTube"))
                    options.Add(t);
            }
            else
            {
                if (!t.name.Equals("BendTube"))
                    options.Add(t);
            }
        }

        return options[Random.Range(0, options.Count)];
    }
}
