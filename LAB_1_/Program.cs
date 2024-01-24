namespace LAB_1_
{
    internal class Program
    {

        //Defines the person class
        public class Person
        {
            public int PersonId;
            public string FirstName;
            public string LastName;
            public string FavouriteColor;
            public int Age;
            public bool IsWorking;

            public Person(int personId, string firstName, string lastName, string favouriteColor, int age, bool isWorking)
            {
                PersonId = personId;
                FirstName = firstName;
                LastName = lastName;
                FavouriteColor = favouriteColor;
                Age = age;
                IsWorking = isWorking;
            }

            //Prints all the information of the object
            public void DisplayPersonInfo()
            {
                Console.WriteLine($"{PersonId}: {FirstName} {LastName}'s favorite colour is {FavouriteColor}");
            }

            //Changes favourite color to white
            public void ChangeFavouriteColor()
            {
                FavouriteColor = "White";
                Console.WriteLine($"{PersonId}: {FirstName} {LastName}'s favorite colour is {FavouriteColor}");
            }

            //Takes the persons age then adds 10 to it
            public int GetAgeInTenYears()
            {
                return Age + 10;
            }

            //Turns all the information into list format
            public override string ToString()
            {
                return $"Person ID:{PersonId}\nFirst Name: {FirstName}\nLast Name: {LastName}\nFavourite Color: {FavouriteColor}\nAge: {Age}\nIs Working: {IsWorking}";
            }
        }

        //Defines different relationships
        public class Relation
        {
            public enum RelationshipType
            {
                sister,
                brother,
                mother,
                father
            }
            public RelationshipType Relationship { get; set; }
            public void ShowRelationship(Person person1, Person person2) 
            {
                string relationship = GetRelationshipType(); 
                Console.WriteLine($"Relationship between {person1.FirstName} and {person2.FirstName} is {relationship}");
            }

            private string GetRelationshipType() 
            {
                switch ( Relationship ) {
                    case RelationshipType.sister:
                        return "Sisterhood";

                    case RelationshipType.brother:
                        return "Brotherhood";

                    case RelationshipType.mother:
                        return "Motherhood";

                    case RelationshipType.father:
                        return "Fatherhood";

                    default:
                        return "Unknown Relationship";
                
                }
            }
                
        }

        public class Mains
        {
            static void Main()
            {
                //Objects for the Person class
                Person person1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
                Person person2 = new Person(2, "Gina", "James", "Green", 18, false);
                Person person3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
                Person person4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

                //Displays all of persons 2 information
                person2.DisplayPersonInfo();

                //Displays person 3 information in a list format
                Console.WriteLine(person3.ToString());

                //Output for person 1 after changing color to white
                person1.ChangeFavouriteColor(); 

                //Displays person 4 age in 1 years
                Console.WriteLine($"Mary Beale's age in 10 years is:{person4.GetAgeInTenYears()}"); 

                //Shows the relationship between people 2 and 4 then 1 and 3
                Relation relation1 = new Relation();
                Relation relation2 = new Relation();
                relation1.ShowRelationship(person2, person4);
                relation2.Relationship = Relation.RelationshipType.brother;
                relation2.ShowRelationship(person1, person3);


                //Creates and adds the 4 people to a list
                List<Person> persons = new List<Person> {person1, person2, person3, person4 };

                //Finds the average age
                double averageAge = persons.Average(person => person.Age);
                Console.WriteLine($"The average age of everyone is {averageAge}");

                //Uses the list to find and display the oldest and youngest 
                Person youngest = persons.OrderBy(person => person.Age).First();
                Person oldest = persons.OrderByDescending(person => person.Age).First();
                Console.WriteLine($"The youngest person is {youngest.FirstName}");
                Console.WriteLine($"The oldest person is {oldest.FirstName}");


                // Used AI to help me with the last two outputs
                //Uses the list to find the people that starts with letter M
                var startsWithM = persons.Where(person => person.FirstName.StartsWith("M")).Select(person => person.ToString());
                Console.WriteLine($"People whose first names start with M:\n{string.Join("\n", startsWithM)}");

                //Finds the person that likes blue and prints the information, if no one likes blue it will say blue is not in the list
                var blueGuy = persons.Find(person => person.FavouriteColor.ToLower() == "blue");
                if (blueGuy != null)
                {
                    Console.WriteLine(blueGuy.ToString());
                }
                else
                {
                    Console.WriteLine("Blue is not a Favourite color.");
                }

            }
        }
    }
}
