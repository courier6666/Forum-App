namespace ForumWebApp.Interfaces.Observer
{
    public interface IMyObserver<T>
    {
        public void Update(T subject);
    }
}
