using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeInfo : MonoBehaviour
{
    [SerializeField] List<GradeItem> grades;
    private int currentGrade = 0;

    public void UpGrade()
    {
        currentGrade++;
    }

    public GradeItem GetCurrentGrade()
    {
        if (currentGrade == grades.Count)
            return null;
        else
        return grades[currentGrade];
    }
}
