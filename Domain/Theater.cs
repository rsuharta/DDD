namespace Domain
{
    using WebApplication1;

    public class Theater : Entity
    {
        protected Theater()
        {   
        }

        public Theater(int capacity)
        {
            this.Capacity = capacity;
        }

        public virtual int Capacity { get; }
    }
}
