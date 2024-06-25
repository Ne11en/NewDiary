using NewDiary.Models;

namespace NewDiary;

public class DatabaseServisce
{
    private static Gr624ErsvlContext db;

    public static Gr624ErsvlContext  GetDbContext()
    {
        if (db == null)
        {
            db = new Gr624ErsvlContext();
        }
        return db;
    }
}
