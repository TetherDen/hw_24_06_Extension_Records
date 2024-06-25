using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hw_24_06_Extension_Records
{
    public static class StrExtension
    {
        private static readonly char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        public static int VowelsCount(this string str)
        {
            return str?.Count(ch => vowels.Contains(ch)) ?? 0;  // метод Count из библиотеки LINQ проверяет каждый елемент str через переменную ch, через лямбда функцию не являеться ли ch символом из масива vowels + проверка на нулл
        }
    }
    //       Завдання 7
    public record Person(string Name, int Age);
    public static class PersonExtension
    {
        public static int MinAgeInList(this List<Person> list)
        {
            int minAge = int.MaxValue;
            list?.ForEach (el => { if (el.Age < minAge) { minAge = el.Age; } });
            return list?.Count> 0? minAge : 0;
        }
        public static int MaxAgeInList(this List<Person> list)
        {
            int maxAge = int.MinValue;
            list?.ForEach(el => { if (el.Age > maxAge) { maxAge = el.Age; } });
            return list?.Count>0 ? maxAge : 0;
        }
        public static double AverageAgeInList(this List<Person> list)
        {
            double sum = 0;
            list?.ForEach(el => {  sum += el.Age; });
            //return sum/list.Count;
            return list?.Count > 0 ? sum / list.Count : 0;
        }
    }

    //       Завдання 8
    public record Point3D(double x,double y,double z);

    public static class Point3DExtension
    {
        public static double DistancesBetweenPoints(this Point3D p1, Point3D p2)
        {
            double dx = p2.x - p1.x;
            double dy = p2.y - p1.y;
            double dz = p2.z - p1.z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
        public static double MaxtDistanceInPointsList(this List<Point3D> list)
        {
            double maxDistance = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i+1; j < list.Count; j++)
                {
                    double temp = list[i].DistancesBetweenPoints(list[j]);
                    if (temp > maxDistance)
                    {
                        maxDistance = temp;
                    }
                }
            }
            return maxDistance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "seWIOjsrhgmixgca";
            Console.WriteLine($"Vowels in str: {str.VowelsCount()}");
            //          Завдання 7
            //        Створіть запис Person.Необхідно зберігати інформацію про ім’я, прізвище, вік.Створіть масив записів
            //Person.Напишіть код для пошуку людини із мінімальним
            //і максимальним віком.Відобразіть середній вік людей
            //(реалізуйте за допомогою extension method). 
            Person pers1 = new Person("name1", 123);
            Person pers2 = new Person("name2", 55);
            Person pers3 = new Person("name3", 44);
            Person pers4 = new Person("name4", 22);
            Person pers5 = new Person("name5", 33);
            List<Person> personsList = new List<Person>{pers1, pers2, pers3, pers4,pers5 };
            Console.WriteLine($"Min age in list: {personsList.MinAgeInList()}");
            Console.WriteLine($"Max age in list: {personsList.MaxAgeInList()}");
            Console.WriteLine($"Average age in list: {personsList.AverageAgeInList().ToString("f2")}");

            //List<Person> personsList1 = null;
            //Console.WriteLine(personsList1.AverageAgeInList());
            //Console.WriteLine(personsList1.MaxAgeInList());
            //Console.WriteLine(personsList1.MinAgeInList());
            //            Завдання 8
            //Створіть запис Point3D.Необхідно зберігати інформацію про координати точки у тривимірному просторі.
            //Створіть масив точок.Напишіть код для обчислення
            //відстані між точками.Відобразіть максимальну відстань
            //між точками та інформацію про них.
            Random rand = new Random();
            Point3D point1 = new Point3D(2,3,4);
            Point3D point2 = new Point3D(3,4,5);
            Point3D point3 = new Point3D(Math.Round(rand.NextDouble() * 10, 1), Math.Round(rand.NextDouble() * 10, 1), Math.Round(rand.NextDouble() * 10, 1));
            Point3D point4 = new Point3D(Math.Round(rand.NextDouble() * 10, 1), Math.Round(rand.NextDouble() * 10, 1), Math.Round(rand.NextDouble() * 10, 1));
            Point3D point5 = new Point3D(Math.Round(rand.NextDouble() * 10,1), Math.Round(rand.NextDouble() * 10,1), Math.Round(rand.NextDouble() * 10,1));
            List<Point3D> pointsList = new List<Point3D> { point1, point2, point3, point4, point5 };

            int index = 1;
            foreach (var point in pointsList)
            {
                Console.WriteLine($"{index}:{point.ToString()}");
                index++;
            }
            Console.WriteLine($"Distance between p1 p3: {point1.DistancesBetweenPoints(point3).ToString("f4")}");
            Console.WriteLine($"Max Distance in List: {pointsList.MaxtDistanceInPointsList().ToString("f4")}");
            

            //Console.WriteLine(point5);
        }
    }
}
