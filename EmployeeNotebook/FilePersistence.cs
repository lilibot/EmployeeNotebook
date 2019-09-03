using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace EmployeeNotebook
{
    public class FilePersistence
    {
        //
        public static void LoadRecords()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files//EmployeeRecords.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                StreamReader f1 = new StreamReader(filePath);
                string st;
                string[] buf;
                while ((st = f1.ReadLine()) != null)
                {
                    buf = st.Split('|');
                    EmployeeRecord employee = new EmployeeRecord();
                    employee.Name = buf[0];
                    employee.Surname = buf[1];
                    employee.YearOfBirth = int.Parse(buf[2]);
                    employee.Phone = buf[3];
                    employee.Id = long.Parse(buf[4]);
                    RecordsRepository.GetRepository().AddRecord(employee);
                }

                f1.Close();
            }

        }

    public static void SaveRecords()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files//EmployeeRecords.txt");
            StreamWriter f = new StreamWriter(filePath);
            var data = RecordsRepository.GetRepository().GetAllRecords();
            foreach (var record in data)
            {
                f.WriteLine("{0}|{1}|{2}|{3}|{4}", record.Name, record.Surname, record.YearOfBirth, record.Phone, record.Id);
            }
            f.Close();
        }

    }
}