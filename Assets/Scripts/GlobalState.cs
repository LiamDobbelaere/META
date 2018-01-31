using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : MonoBehaviour
{
    public Color[] paletteColorsMain;
    public Color[] paletteColorsAccent;
    public Color[] paletteColorsTube;
    public int[] maxStraightCounts;
    public int[] maxBendCounts;

    public ShipController ship;

    public float score;
    public int scoreMultiplier = 1;

    private int currentPaletteColor;

    private int bendCount;
    private int maxStraightCount = 3;
    
    private int splitCount;
    private int maxBendCount = 2;

    private float newAcceleration;

    private bool hasCompletedAll;
    private float scorePerSecond = 10f;    

    // Use this for initialization
    void Start()
    {
        ship = GameObject.Find("Ship").GetComponent<ShipController>();
        newAcceleration = ship.acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        ship.acceleration = Mathf.Lerp(ship.acceleration, newAcceleration, 0.002f);

        if (!ship.isDead) score += (scorePerSecond * scoreMultiplier) * Time.deltaTime;
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

            if (!hasCompletedAll)
            {
                newAcceleration += 1f;
                ship.maxBanking += 0.4f;
                hasCompletedAll = true;
            }
        }

        scoreMultiplier++;
        maxBendCount = maxBendCounts[currentPaletteColor];
        maxStraightCount = maxStraightCounts[currentPaletteColor];

        if (ship.acceleration < 3.9f)
        {
            newAcceleration += 1f;
            ship.maxBanking += 0.4f;
        }
    }

    public Transform getNextPermutation(Transform permutations)
    {
        bool bendsOnly = false;
        bool allowSplit = false;

        if (++bendCount > maxStraightCount)
        {
            bendsOnly = true;
            bendCount = 0;

            if (++splitCount > maxBendCount)
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

                //if (t.name.Equals("UpTube") || t.name.Equals("DownTube"))
                //    options.Add(t);
            }
            else
            {
                if (t.name.Equals("StraightTube"))
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
