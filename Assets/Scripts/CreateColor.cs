using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateColor : MonoBehaviour {
    
	public static int mode;
    public static int remainder;
    public static int diag;

    void Start()
    {
        mode = 1;
        remainder = 0;
        diag = 0;
    }

    // Version in which you play on the computer	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            changeremainder();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            changemod();
        }
        else if (Input.GetKeyDown("f"))
        {
            changediag();
        }
        if (mode == 1)
        {
            resetColor();
            //GameObject uitxt = GameObject.Find("modselect");
            //uitxt.GetComponent<Text>().text = "Mode: no highlight";
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: none";
        }
        if (mode == 2)
        {
            highlightDivisible(2, Color.yellow);
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: mod 2";
        }
        else if (mode == 3)
        {
            highlightDivisible(3, Color.green);
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: mod 3";
        }
        else if (mode == 4)
        {
            highlightDivisible(4, Color.red);
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: mod 4";
        }
        else if (mode == 5)
        {
            highlightDivisible(5, Color.blue);
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: mod 5";
        }
        else if (mode == 6)
        {
            highlightDivisible(6, Color.black);
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: mod 6";
        }
        else if (mode == 7)
        {
            highlightDivisible(7, Color.red);
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: mod 7";
        }
        if (diag == 1)
        {
            highlightIndex(diag, Color.red);
            GameObject.Find("DiagCube").GetComponentInChildren<TextMesh>().text = "Diagonal: " + diag;
        }
        else if (diag == 2)
        {
            highlightIndex(diag, Color.green);
            GameObject.Find("DiagCube").GetComponentInChildren<TextMesh>().text = "Diagonal: " + diag;
        }
        else if (diag == 3)
        {
            highlightIndex(diag, Color.yellow);
            GameObject.Find("DiagCube").GetComponentInChildren<TextMesh>().text = "Diagonal: " + diag;
        }
        else if (diag == 4)
        {
            highlightIndex(diag, Color.blue);
            GameObject.Find("DiagCube").GetComponentInChildren<TextMesh>().text = "Diagonal: " + diag;
        }
    }

    public static void resetColor()
    {
        int sizeOfList = TriangleGenerator.obj.Count;
        for(int i=0; i<sizeOfList; i++)
        {
            for (int j=0; j<i+1; j++)
            {
                GameObject tempo = TriangleGenerator.obj[i][j];
                Renderer rend = tempo.GetComponent<Renderer>();
                Color w = Color.white;
                rend.material.color = w;
                TriangleGenerator.obj[i][j] = tempo;
            }
        }
    }

    void highlightDivisible(int num, Color col)
    {
        resetColor();
        int sizeOfList = TriangleGenerator.obj.Count;
        for (int i = 0; i < sizeOfList; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                GameObject tempo = TriangleGenerator.obj[i][j];
                Renderer rend = tempo.GetComponent<Renderer>();
                int n = TriangleGenerator.triangle[i][j];
                if (n % num == remainder)
                {
                    rend.material.color = col;
                }
                TriangleGenerator.obj[i][j] = tempo;
            }
        }
    }

    public static void setDiagonalZero()
    {
        diag = 0;
        GameObject.Find("DiagCube").GetComponentInChildren<TextMesh>().text = "Diagonal: none";
    }

    public static void changediag()
    {
        setRemainderZero();
        mode = 1;
        if (diag != 4) // != mode - 1
        {
            diag++;
        }
        else
        {
            resetColor();
            setDiagonalZero();
        }
    }

    void highlightIndex(int num, Color col)
    {
        resetColor();
        int sizeOfList = TriangleGenerator.obj.Count;
        for (int i = 0; i < sizeOfList; i++)
        {
            if (i < num) continue;
            GameObject tempo = TriangleGenerator.obj[i][num];
            Renderer rend = tempo.GetComponent<Renderer>();
            rend.material.color = col; //remainder does not have effect on this
            TriangleGenerator.obj[i][num] = tempo;
        }
    }

    public static void changeremainder()
    {
        setDiagonalZero();
        if (remainder == 0) // != mode - 1
        {
            remainder++;
            GameObject.Find("RemainderCube").GetComponentInChildren<TextMesh>().text = "Remainder: " + remainder;
        }
        else
        {
            setRemainderZero();
        }
    }

    public static void setRemainderZero()
    {
        remainder = 0;
        GameObject.Find("RemainderCube").GetComponentInChildren<TextMesh>().text = "Remainder: 0";
    }

    public static void changemod()
    {
        setRemainderZero();
        setDiagonalZero();
        if (mode != 7)
            {
                mode++;
            }
            else
            {
                mode = 1;
            }
    }

}
