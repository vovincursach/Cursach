using System;
namespace КП
{
    public interface ISqlData
    {
         string Name { get; set; }

         string Color { get; set; }

         decimal Price { get; set; }

         string Mark { get; set; }
    }
}
