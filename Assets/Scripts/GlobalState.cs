using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : MonoBehaviour {
    public Color[] paletteColorsMain;
    public Color[] paletteColorsAccent;

    private int counter;
    private int currentPaletteColor;
    private int bendCounter;

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

    public int getBendCounter()
    {
        return bendCounter;
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

        if (++bendCounter > 3)
        {
            bendCounter = 0;
        }
    }
}
