using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeNotebook
{
    public class RecordsRepository
    {
        private static RecordsRepository repository = new RecordsRepository();
        private List<EmployeeRecord> employeeRecords = new List<EmployeeRecord>();

        public static RecordsRepository GetRepository()
        {
            return repository;
        }

        public IEnumerable<EmployeeRecord> GetAllRecords()
        {
            return employeeRecords;
        }

        public void AddRecord(EmployeeRecord record)
        {

            employeeRecords.Add(record);
        }
        public void DelRecord(long id)
        {
            int index = employeeRecords.FindIndex(s =>s.Id ==id);
            employeeRecords.RemoveAt(index);
        }


    }
}