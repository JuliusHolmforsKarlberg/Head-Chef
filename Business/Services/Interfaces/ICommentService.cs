using Models.DDS;

namespace Head_Chef.Business.Services.Interfaces
{
    public interface ICommentService
    {
        //void Save(Comment comment);

        //IEnumerable<Comment> GetCommentsByPage(int pageId);

        //void Delete(int pageId);

        //////////////////////////

        void Save(Comment comment);

        Task<IEnumerable<Comment>> GetCommentsByPageAsync(int pageId);

        Task DeleteAsync(int pageId);
    }
}
