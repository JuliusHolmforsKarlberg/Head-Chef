using EPiServer.Data.Dynamic;
using Head_Chef.Business.Services.Interfaces;
using Models.DDS;

namespace Head_Chef.Business.Services
{
public class CommentService : ICommentService
{
    private DynamicDataStore _store = DynamicDataStoreFactory.Instance.CreateStore(typeof(Comment));

    public void Save(Comment comment)
    {
            //_store.Save(comment);
            using (var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(Comment)))
            {
                store.Save(comment);
            }
        }

    public IEnumerable<Comment> GetCommentsByPage(int pageId)
    {
        var comments = _store.Items<Comment>().Where(x => x.PageId == pageId);

        return comments;
    }

    public void Delete(int pageId)
    {
        var comments = GetCommentsByPage(pageId);

        foreach (var comment in comments)
        {
            _store.Delete(comment);
        }
    }
}
}

