
namespace week6Learning
{
    class Person
    {
        public string Name { get; set; }
        public List<Person> Friends=new List<Person>();
        public Person(string name) => Name = name;
        public void AddFriend(Person friend)
        {
            if (!Friends.Contains(friend))
            {
                Friends.Add(friend);
                friend.Friends.Add(this);
            }
        }
    }
    class SocialNetwork{
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        { 
            _members.Add(member);
        }
        public void ShowMember()
        {
            foreach (var member in _members)
            {
                Console.Write(member.Name+"->");
                List<String> friends = new List<string>(); 
                foreach (var friend in member.Friends)
                {
                    friends.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(",",friends)}");
            }
        }
    }
    internal class SocialNetworking
    {
        static void Main(string[] args)
        {
            Person angela = new Person("Angela");
            Person bob = new Person("Bob");
            Person charlie = new Person("Charlie");
            Person danny = new Person("Danny");

            SocialNetwork network=new SocialNetwork();

            network.AddMember(angela);
            network.AddMember(bob);
            network.AddMember(charlie);
            network.AddMember(danny);

            angela.AddFriend(bob);
            angela.AddFriend(charlie);
            bob.AddFriend(danny);
            danny.AddFriend(charlie);

            network.ShowMember();


        }
    }
}
