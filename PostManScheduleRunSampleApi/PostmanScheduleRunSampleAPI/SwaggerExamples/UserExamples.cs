using PostmanScheduleRunSampleAPI.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Runtime.CompilerServices;

namespace PostmanScheduleRunSampleAPI
{
    public class UserPostExamples : IMultipleExamplesProvider<UsersModel>
    {
        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }

        public IEnumerable<SwaggerExample<UsersModel>> GetExamples()
        {
            yield return SwaggerExample.Create("User Example1",
               new UsersModel()
               {
                   EnglishName = string.Join("En_", GenerateName(5)),
                   ArabicName = string.Join("Ar_", GenerateName(5))

               });
            yield return SwaggerExample.Create("User Example2",
              new UsersModel()
              {
                  EnglishName = string.Join("En_", GenerateName(5)),
                  ArabicName = string.Join("Ar_", GenerateName(5))

              });
        }

    }
    public class UserPutExamples : IMultipleExamplesProvider<UsersModel>
    {
        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }

        public IEnumerable<SwaggerExample<UsersModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Update Example1",
               new UsersModel()
               {
                   UserId = 1,
                   EnglishName = string.Join("En_", GenerateName(5)),
                   ArabicName = string.Join("Ar_", GenerateName(5))

               });
            yield return SwaggerExample.Create("Update Example2",
              new UsersModel()
              {
                  UserId = 2,
                  EnglishName = string.Join("En_", GenerateName(5)),
                  ArabicName = string.Join("Ar_", GenerateName(5))

              });
        }

    }
}
