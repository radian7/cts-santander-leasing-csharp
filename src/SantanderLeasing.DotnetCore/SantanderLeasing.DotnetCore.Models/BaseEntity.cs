namespace SantanderLeasing.DotnetCore.Models
{
    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }

        public virtual void Print()
        {
            System.Console.WriteLine(Id);
        }
                
        public abstract void Send();
    }
}
