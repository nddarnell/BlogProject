namespace BlogProject.Services
{
    public interface ISlugService
    {
        string UrlFriendly(string title);
        bool isUnique(string slug);


    }
}
