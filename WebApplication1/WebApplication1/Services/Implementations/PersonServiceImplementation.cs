using WebApplication1.Model;

namespace WebApplication1.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        private long IncrementAndGet() => Interlocked.Increment(ref count);

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "Jônathas",
                LastName = "Leandro",
                Age = 26,
                Gender = "M"
            };
        }

        public Person Update(Person person)
        {
            person.Id = IncrementAndGet();
            return person;
        }

        private Person MockPerson(long i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person Last Name {i}",
                Age = new Random().Next(0, 80),
                Gender = (count % 2 == 0) ? "M" : "F"
            };
        }


    }
}
