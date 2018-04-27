using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSprite : MonoBehaviour {

    public GameObject bottomTile;

    [Header("Sectors Tiles")]
    public GameObject[] firstSectorTiles;
    public GameObject[] secondSectorTiles;
    public GameObject[] thirdSectorTiles;

    private float offsetY;
    private int jumpCount;

	void Awake ()
    {
        MakeATile();;
	}
	
    void MakeATile()
    {
        offsetY = 0;
        Vector3 tilePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(firstSectorTiles[Random.Range(0, firstSectorTiles.Length)], tilePosition, Quaternion.identity);
        //tile.transform.parent = this.transform;

        for (int i = 0; i < 4; i++)
        {
            offsetY -= 2.5f;
            Vector3 bottomTilePosition = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z);
            Instantiate(bottomTile, bottomTilePosition, Quaternion.identity);
        }
    }
}
