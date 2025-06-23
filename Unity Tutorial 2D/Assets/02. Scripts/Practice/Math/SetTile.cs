using System.Collections;
using UnityEngine;

public class SetTile : MonoBehaviour
{
    public GameObject tilePrefab;
    public int rows = 5, cols = 5;

    IEnumerator Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                //if ((i + j) % 2 == 0)
                var pos = new Vector3(i, 0, j);

                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                Renderer renderer = tile.GetComponent<Renderer>();
                if((i+j)%2==0)
                    renderer.material.color = Color.white;
                else
                    renderer.material.color = Color.black;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
