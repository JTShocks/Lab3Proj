using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

// Intermediate Game Development Lab 3 Sub-Assignment 1.
//Written by Carl Bowne and John(? Place full name here please.)

public class LabScript_1 : MonoBehaviour
{
    public string courseName = null;

    //Assumption: Course schedule is assumed to be a full 16 week course schedule with no breaks.
    const int COURSELENGTH = 16; //Maximum weeks in a course

    //Assumption: "Difficulty" is measured against a maximum of 16, 1 of each item for every week.
    [Range(0, COURSELENGTH)]public int moduleCount;
    [Range(0, COURSELENGTH)]public int readingMatCount;
    [Range(0, COURSELENGTH)]public int assignmentCount;
    [Range(0, COURSELENGTH)]public int quizCount;
    public bool hasIntructorTaughtCourse; //The instructor having taught the class before is treated as making it easier for the students.

    void Start() => Main();


    void Main()
    {
        //Error Checks.
        if(courseName == "")
        {
            Debug.LogError("This course is missing a name. Please add a name.");
            return;
        }
        if (CheckAllZeros())
        {
            Debug.LogError("This course has nothing in it. Please add content.");
            return;
        }

        float resultTotal = 0f;
        resultTotal += CalculateFactorPercentage(moduleCount, 15);
        resultTotal += CalculateFactorPercentage(readingMatCount, 30);
        resultTotal += CalculateFactorPercentage(quizCount, 15);
        resultTotal += CalculateFactorPercentage(assignmentCount, 30);
        resultTotal += hasIntructorTaughtCourse ? 0f : 10f;

        int finalResult = (int)Mathf.Lerp(1, 10, resultTotal/100);

        Debug.LogFormat("Challenge Rating for course {0} is {1}", courseName, finalResult);
    }


    float CalculateFactorPercentage(int amountOfFactor, int factorPercentage) =>
        ((float)amountOfFactor * (float)factorPercentage) / (float)COURSELENGTH;

    bool CheckAllZeros() =>
        moduleCount == 0 && assignmentCount == 0 && readingMatCount == 0 && quizCount == 0;
}
