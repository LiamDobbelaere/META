using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : MonoBehaviour
{
    public Color[] paletteColorsMain;
    public Color[] paletteColorsAccent;
    public Color[] paletteColorsTube;

    private int currentPaletteColor;

    private int bendCount;
    private int maxBendCount = 3;

    private int splitCount;
    private int maxSplitCount = 2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Color getMainColor()
    {
        return paletteColorsMain[currentPaletteColor];
    }

    public Color getAccentColor()
    {
        return paletteColorsAccent[currentPaletteColor];
    }

    public Color getTubeColor()
    {
        return paletteColorsTube[currentPaletteColor];
    }

    public void AdvancePalette()
    {
        if (++currentPaletteColor >= paletteColorsMain.Length)
        {
            currentPaletteColor = 0;
        }
    }

    public Transform getNextPermutation(Transform permutations)
    {
        bool bendsOnly = false;
        bool allowSplit = false;

        if (++bendCount > maxBendCount)
        {
            bendsOnly = true;
            bendCount = 0;

            if (++splitCount > maxSplitCount)
            {
                allowSplit = true;
            }
        }

        List<Transform> options = new List<Transform>();

        foreach (Transform t in permutations)
        {
            if (bendsOnly)
            {
                if (t.name.Equals("BendTube") && !allowSplit)
                    options.Add(t);

                if (t.name.Equals("SplitTube") && allowSplit)
                    options.Add(t);
            }
            else
            {
                if (!t.name.Equals("BendTube") && !t.name.Equals("SplitTube"))
                    options.Add(t);
            }
        }
        var option = options[Random.Range(0, options.Count)];

        if (option.name.Equals("SplitTube"))
        {
            AdvancePalette();
            splitCount = 0;
        }

        return option;
    }
}
