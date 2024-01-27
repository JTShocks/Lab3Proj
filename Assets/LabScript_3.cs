using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Intermediate Game Development Lab 3 Sub-Assignment 3.
//Written by Carl Bowne

public class LabScript_3 : MonoBehaviour
{
    public int inputDollars;

    [Header("(Keep in order from highest to lowest.)")]
    public List<int> divisionLevels = new List<int> { 100, 50, 20, 10, 5, 1}; //Using a list because they can change size.


    void Start() => Main();

    void Main()
    {
        //No Money Error Check
        if (inputDollars == 0)
        {
            Debug.Log("You are Broke.");
            return;
        } 

        //Adds a 1 division level to the end of the divisionLevels list if there is none.
        if (divisionLevels.Count == 0 || divisionLevels[divisionLevels.Count - 1] != 1) divisionLevels.Add(1);

        // "Only accepting 1s" Soft Error check.
        if (divisionLevels.Count == 1) Debug.LogWarning("You're only accepting 1 Dollar Bills. What is the point of this?");


        int workingDollars = inputDollars;
        List<int> billCounts = new List<int>();
        billCounts.AddRange(new int[divisionLevels.Count]); 
        //This is dumb. Why does the option to pass a capacity into a list constructor exist if it breaks the list and the only working way to make a blank list of a size is to do this? >:T

        for (int i = 0; i < divisionLevels.Count; i++)
            billCounts[i] = SeparateBills(ref workingDollars, divisionLevels[i]);
        
        DisplayResults(divisionLevels, billCounts);
    }

    int SeparateBills(ref int input, int level)
    {
        if (level == 1) return input;
        int bills = 0;
        while(input >= level)
        {
            input -= level;
            bills++;
        }
        return bills;
    }

    void DisplayResults(/*int singleDollars,*/ List<int> divisions, List<int> billCounts)
    {
        string displayString = "You have " + inputDollars + " Dollars, which separates into ";
        int divisionCount = divisions.Count; //I added this cause making two loops that do roughly the same thing loop through technically different domains bothers me.

        //Identifies the First and Last Bill Levels that have any Bills.
        int firstBillLevel = -1;
        int lastBillLevel = -1;
        for (int i = 0; i < divisionCount; i++) 
            if (billCounts[i] > 0)
            {
                firstBillLevel = (firstBillLevel == -1) ? i : firstBillLevel;
                lastBillLevel = i;
            }

        for (int i = 0; i < divisionCount; i++)
        {
            if (billCounts[i] == 0) continue;

            displayString +=
                ((i == lastBillLevel && firstBillLevel != lastBillLevel) ? "and " : "") //Adds "and" before display if this is the last.
                + billCounts[i] + " " + divisions[i] + " Dollar Bill" //Displays the bill count for this division level
                + ((billCounts[i] > 1) ? "s" : "") //Displays the plural s to the end if there's more than one.
                + ((i == lastBillLevel) ? "." : ", ") //Displays the proper punctuation depending on if this is the last
                ;
        }

        Debug.Log(displayString);
    }
}
