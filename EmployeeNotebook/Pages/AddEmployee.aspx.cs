using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace EmployeeNotebook
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void SubmitEmployeeData_Click(object sender, EventArgs e)
        {

            EmployeeRecord record = new EmployeeRecord();

            if (TryUpdateModel(record, new FormValueProvider(ModelBindingExecutionContext)))
            {
                var allRecords = RecordsRepository.GetRepository().GetAllRecords();
                if (allRecords.Any())
                {
                    record.Id = RecordsRepository.GetRepository().GetAllRecords().Max(x => x.Id) + 1;
                }
                else record.Id = 0;
                RecordsRepository.GetRepository().AddRecord(record);
                FilePersistence.SaveRecords();
                Response.Redirect("Index.aspx");
            }

        }
    }
}