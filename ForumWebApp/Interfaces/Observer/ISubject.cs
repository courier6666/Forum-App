namespace ForumWebApp.Interfaces.Observer
{
    public interface IMySubject<T>
    {
        public void Attach(T observer);
        public void Detach(T observer);
        public void Notify();
    }
}
