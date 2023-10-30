using Models.DDS;

namespace Head_Chef.Business.Services.Interfaces
{
    public interface ICommentService
    {
        void Save(Comment comment);

        IEnumerable<Comment> GetCommentsByPage(int pageId);

        void Delete(int pageId);
    }
}
