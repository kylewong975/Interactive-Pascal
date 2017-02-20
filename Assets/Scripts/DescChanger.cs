using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescChanger : MonoBehaviour {

    private string desc;
    private string desc1;

	// Use this for initialization
	void Start () {
        desc1 = " This is Pascal's triangle. It is constructed as follows: the \n topmost row is filled with the number 1, and every entry in \n each subsequent row is constructed by adding up the two \n numbers that are above it (blank spaces are interpreted as 0). \n \n The triangle has some amazing properties when \n highlighting different numbers -it's both beautiful \n and mathematically very significant. \n \n To get a flavor of what this triangle entails, choose \n one of the menu options on the left: \n 'divisible by' rotates through numbers 2 to 7 and highlights \n all the numbers in the triangle that are divisible by that \n number(i.e.are 0 modulo that number). \n \n 'Remainder' changes it to 1 modulo that number. \n \n 'Diagonal' highlights some diagonals and their interesting \n properties.";
        gameObject.GetComponent<TextMesh>().text = desc1;
    }
	
	// Update is called once per frame
	void Update () {
		if (CreateColor.mode != 1)
        {
            desc = " Highlighting the entries which are divisible by any given \n number creates a fractal pattern. Can you spot how the patterns \n formed by primes and composite numbers differ? (Why?) \n What is the pattern for primes, and why is it so complex? \n Can you see the fact that 6 is divisible by 2 and 3? \n \n When we switch the remainder to 1, are the patterns formed \n also fractal? \n \n Highlighting just the even entries (those equivalent to 0 mod 2) \n creates Sierpinski's triangle, a famous \n fractal. Check out how its behavior develops as the modulus \n increases.";
            gameObject.GetComponent<TextMesh>().text = desc;
        }
        else if(CreateColor.diag != 0)
        {
            desc = "\n \n \n Observe the pattern which forms along the successive \n diagonals of the triangle. The first diagonal lists the natural \n numbers, the second lists the triangular numbers, \n and the third lists the 'tetrahedral' numbers - the number of \n blocks it takes to form a tetrahedron. (Why do \n you think this is true?) \n \n Also - what does the fourth diagonal contain? The \n '4D tetrahedron'-al numbers? As a matter of fact, \n that is true...";
            gameObject.GetComponent<TextMesh>().text = desc;
        }
        else
        {
            gameObject.GetComponent<TextMesh>().text = desc1;
        }
	}
}
