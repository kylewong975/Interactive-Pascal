using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int rows;
    public static List<List<GameObject>> obj = new List<List<GameObject>>();
    public static List<List<int>> triangle = new List<List<int>>();
    // Use this for initialization
    void Start()
    {
        GameObject obj_template = prefab; //the template GameObject used for initializing obj_tmp
        GameObject obj_tmp; // used for adding initialized cubes to obj (list of cubes)

        //base case 1
        triangle.Add(new List<int> { 1 });
        obj_template.GetComponentInChildren<TextMesh>().text = "1";
        obj_tmp = Instantiate(obj_template, new Vector3(0, 0, 0), Quaternion.identity);
        List<GameObject> templist = new List<GameObject> { obj_tmp };
        obj.Add(templist);

        //base case 1 1
        triangle.Add(new List<int> { 1, 1 });
        List<GameObject> templist3 = new List<GameObject>();
        obj_tmp = Instantiate(obj_template, new Vector3(-0.5f, -1, 0), Quaternion.identity);
        templist3.Add(obj_tmp);
        obj_tmp = Instantiate(obj_template, new Vector3(0.5f, -1, 0), Quaternion.identity);
        templist3.Add(obj_tmp);
        obj.Add(templist3);

        //initialize positions of starting positions of row 2
        float y = -2; //vertical
        float x = -1; //horizontal

        for (int i = 2; i < rows; i++)
        {
            List<GameObject> templist2 = new List<GameObject>();
            float tmpX = x;
            List<int> upper = triangle[i - 1];
            List<int> temp = new List<int>();
            temp.Add(1);
            obj_template.GetComponentInChildren<TextMesh>().text = "1";
            obj_tmp = Instantiate(obj_template, new Vector3(tmpX, y, 0), Quaternion.identity);
            templist2.Add(obj_tmp);
            tmpX++;
            for (int j = 1; j < i; j++)
            {
                int k;
                k = upper[j] + upper[j - 1];
                temp.Add(k);
                obj_template.GetComponentInChildren<TextMesh>().text = "" + k;
                obj_tmp = Instantiate(obj_template, new Vector3(tmpX, y, 0), Quaternion.identity);
                templist2.Add(obj_tmp);
                tmpX++;
            }
            temp.Add(1);
            obj_template.GetComponentInChildren<TextMesh>().text = "1";
            obj_tmp = Instantiate(obj_template, new Vector3(tmpX, y, 0), Quaternion.identity);
            templist2.Add(obj_tmp);
            triangle.Add(temp);
            x-=0.5f;
            y--;
            obj.Add(templist2);
        }

        //Using the general logic of generating Pascal's Triangle in a list of lists,
        /*
        List<List<int>> triangle = new List<List<int>>();
        triangle.Add(new List<int> { 1 });
        triangle.Add(new List<int> { 1, 1 });
        for(int i=2; i<rows; i++)
        {
            List<int> upper = triangle[i - 1];
            List<int> temp = new List<int>();
            temp.Add(1);
            for(int j=1; j<i; j++)
            {
                int k;
                k = upper[j] + upper[j - 1];
                temp.Add(k);
            }
            temp.Add(1);
            triangle.Add(temp);
        }
        */

        //testing
        /*for (int x = 0; x<rows; x++)
        {
            for (int y=0;y<=x; y++)
            {
                Debug.Log(triangle[x][y]);
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
