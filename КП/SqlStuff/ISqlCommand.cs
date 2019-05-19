using System.Collections;

namespace КП
{
    public interface ISqlCommand
    {
        void Insert(ISqlData data);

        void Delete(ISqlData data);

        void Update(ISqlData data);

        ArrayList SelectAll();
    }
}
