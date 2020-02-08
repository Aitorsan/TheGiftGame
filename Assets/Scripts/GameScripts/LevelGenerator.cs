/* ****************************************************************************************************************************
* The pixel map image after being import to the folder levelMaps should have the following settings enable in other to work:
* 1. Set  Read/write enable in the image map to be able to get the color
* 2. Set filter mode to point.
* ****************************************************************************************************************************/
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] dayMappings;
    public ColorToPrefab[] nightMappings;
    public bool isDay = true;

    void Start()
    {
        if (isDay)
            GenerateLevel(dayMappings);
        else
            GenerateLevel(nightMappings);
    }

    void GenerateLevel(ColorToPrefab[] prefabMap)
    {
        for ( int x = 0; x < map.width; ++x)
        {
            for(int y = 0; y <map.height;++y)
            {
                GenerateTile(x, y,prefabMap);
            }
        }
    }

    void GenerateTile(int x , int y, ColorToPrefab[] prefabMap)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
            return; // pixel is transparent

        foreach(ColorToPrefab colorMapping in prefabMap)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }


    }
  
}
