using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            var result = 'F';

            if (grades[threshold - 1] <= averageGrade)
                result = 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                result = 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                result = 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                result = 'D';
            else
                result = 'F';

            return result;
        }
    }
}