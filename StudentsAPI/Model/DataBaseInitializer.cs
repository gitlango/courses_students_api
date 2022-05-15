namespace StudentsAPI.Model
{
    public class DataBaseInitializer
    {
        public static void InitializeIfEmpty(Context context, int numbersOfStudents)
        {
            if (context.Students.Any())
            {
                return;
            }

            foreach (var courseName in courseNames)
            {
                Course course = new() { Name = courseName };
                context.Courses.Add(course);
            }

            context.SaveChanges();

            for (int i = 0; i < numbersOfStudents; i++)
            {
                Student student = new();
                student.Name = RandomFullName();
                student.EnrolledCourses = RandomZeroToAllCourses(context, student).ToList();

                context.Students.Add(student);
            }
            context.SaveChanges();
        }

        private static string[] firstNames = new string[] { "John", "Ned", "Robert", "Aria", "Tyrion", "Daenarys" };
        private static string[] lastNames = new string[] { "Stark", "Snow", "Baratheron", "Lannister", "Targaerean" };

        private static string[] courseNames = new string[] { "Archery Course", "Sword and Shield Course",
                                                      "Brewing Course", "Blacksmithing Course", "Tailorship Course" };

        public static string RandomFullName()
        {
            Random random = new Random();
            return $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}";
        }

        private static IEnumerable<CourseStudent> RandomZeroToAllCourses(Context context, Student student)
        {
            Random random = new Random();

            int coursesCount = random.Next(0, courseNames.Length);

            List<string> drawnCourses = new List<string>();

            while (drawnCourses.Count < coursesCount)
            {
                string drawn = courseNames[random.Next(courseNames.Length)];

                if (false == drawnCourses.Contains(drawn))
                {
                    drawnCourses.Add(drawn);
                }
            }

            List<Course> courses = context.Courses.Where(c => drawnCourses.Contains(c.Name)).ToList();

            foreach (Course course in courses)
            { 
                yield return new CourseStudent() { Course = course, Student = student };
            }
        }
    }
}
