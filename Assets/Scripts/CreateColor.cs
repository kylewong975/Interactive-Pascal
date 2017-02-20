using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Generates and creates 
public class CreateColor : MonoBehaviour {
    
	public static int mode; //mode is "divisble by" mathematical property
    public static int remainder; //remainder within the "divisble by" mathematical property
    public static int diag; //the diagonal mathemataical properties

    //initialize
    void Start()
    {
        mode = 1;
        remainder = 0;
        diag = 0;
    }

    // Version in which you play on the computer	
    // Update is called once per frame
    void Update () {
        //Computer inputs
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

        //Various modes to highlight different mathematical properties in the Pascal's triangle
        //Code refactoring can be enhanced to highlightDivisible(mode) for mode in [2, 7] if you wish to not include unique colors for each mode
        if (mode == 1)
        {
            resetColor();
            //GameObject uitxt = GameObject.Find("modselect");
            //uitxt.GetComponent<Text>().text = "Mode: no highlight";
            GameObject.Find("ModeCube").GetComponentInChildren<TextMesh>().text = "Divisible by: none";
        }
        else if (mode == 2)
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

        //Diagonal properties, which can be easily refactored like above (highlightIndex(diag)), if you don't care about unique colors for each property
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

    //resets the color (default color: white) of all Pascal number blocks
    //function call every time a mathematical property is changed
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

    //highlight all numbers that are divisible by num, using the color col passed in the parameter
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

    //highlights all Pascal numbers, which, in context of a list of list of integers, is found in that index num.
    void highlightIndex(int num, Color col)
    {
        resetColor();
        int sizeOfList = TriangleGenerator.obj.Count;
        for (int i = 0; i < sizeOfList; i++)
        {
            if (i < num) continue; //if the row has fewer elements than can be accessed by index num, do not proceed
            GameObject tempo = TriangleGenerator.obj[i][num];
            Renderer rend = tempo.GetComponent<Renderer>();
            rend.material.color = col; //remainder does not have effect on this
            TriangleGenerator.obj[i][num] = tempo;
        }
    }

    //clears the diagonal, which occurs after switching different mathematical patterns (from diagonal to divisible by) or switching after diagonal 4 (pentelope numbers) is highlighted
    public static void setDiagonalZero()
    {
        diag = 0;
        GameObject.Find("DiagCube").GetComponentInChildren<TextMesh>().text = "Diagonal: none";
    }

    //sets remainder to 0, which occurs after every mod (divisble by) mode change or after switching between different mathematical properties
    public static void setRemainderZero()
    {
        remainder = 0;
        GameObject.Find("RemainderCube").GetComponentInChildren<TextMesh>().text = "Remainder: 0";
    }

    //changes the diagonal based on the diagonal mode
    public static void changediag()
    {
        setRemainderZero();
        mode = 1; //if you were highlighting divisible by n numbers, clear the pattern and proceed to highlight diagonal properties
        if (diag != 4)
        {
            diag++;
        }
        else
        {
            resetColor();
            setDiagonalZero();
        }
    }

    //change the remainder when in the divisble by mode
    public static void changeremainder()
    {
        setDiagonalZero();
        if (remainder == 0) // != mode - 1 if you want to see more highlighted number properties, but for simplicity it is kept as a toggle between 0 and 1
        {
            remainder++;
            GameObject.Find("RemainderCube").GetComponentInChildren<TextMesh>().text = "Remainder: " + remainder;
        }
        else
        {
            setRemainderZero();
        }
    }

    //change the "divisible by" mathematical property
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
