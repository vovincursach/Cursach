using System;
namespace КП
{
    public interface ISqlCommand
    {
        void Insert(ISqlData data);

        void Delete(ISqlData data);

        void Update(ISqlData data);

        ISqlData[] Select(string value, string paramToSelect = null);
    }
}
