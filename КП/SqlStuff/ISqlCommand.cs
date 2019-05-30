using System.Collections;

namespace КП
{
    public interface ISqlCommand
    {
        void InsertCars(ISqlDataCars data);

        void DeleteCars(ISqlDataCars data);

        void UpdateCars(ISqlDataCars data);

        void InsertCustomers(ISqlDataCustomers data);

        void DeleteCustomers(ISqlDataCustomers data);

        void UpdateCustomers(ISqlDataCustomers data);

        ArrayList SelectAllCars();
    }
}
