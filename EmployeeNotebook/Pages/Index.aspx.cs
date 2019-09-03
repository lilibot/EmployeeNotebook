using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Text;
using System.IO;



namespace EmployeeNotebook
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                var data = RecordsRepository.GetRepository().GetAllRecords();

                EmployeeGridView.DataSource = data;
                EmployeeGridView.DataBind();
            }
        }
        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void FindRecords_Click(object sender, EventArgs e)
        {
            var allRecords = RecordsRepository.GetRepository().GetAllRecords();
            string name = Request.Form["name"].ToLower();
            string surname = Request.Form["surname"].ToLower();
            string phone = Request.Form["phone"].ToLower();
            if (!((name == "") && (surname == "") && (phone == "")))
            {
                var filtered = allRecords.Where(x =>
                            ((name == "" ? true : x.Name.ToLower().Contains(name))
                              && (surname == "" ? true : x.Surname.ToLower().Contains(surname))
                              && (phone == "" ? true : x.Phone.ToLower().Contains(phone))
                            ));
                FoundRecordsGridView.DataSource = filtered;
                FoundRecordsGridView.DataBind();
            }
            else
            {
                FoundRecordsGridView.DataSource = null;
                FoundRecordsGridView.DataBind();
            }
        }

        protected void SortBySurnameAndBirthYear_Click(object sender, EventArgs e)
        {
            var data = RecordsRepository.GetRepository().GetAllRecords();

                IList<EmployeeRecord> result = data.OrderBy(x => x.Surname).ThenBy(x => x.YearOfBirth).ToList();
                data = result;

            EmployeeGridView.DataSource = data;
            EmployeeGridView.DataBind();
            EmployeeGridView.Visible = true;
        }
        protected void EmployeeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            var id = long.Parse(EmployeeGridView.DataKeys[e.RowIndex].Value.ToString());
            RecordsRepository.GetRepository().DelRecord(id);
            var data = RecordsRepository.GetRepository().GetAllRecords();
            EmployeeGridView.DataSource = data;
            EmployeeGridView.DataBind();
            EmployeeGridView.Visible = true;
            FilePersistence.SaveRecords();

        }

        protected void EmployeeGridView_Sorting(object sender, GridViewSortEventArgs e)
        {

            var data = RecordsRepository.GetRepository().GetAllRecords();
            if (e.SortExpression == "Surname")
            {
                IList<EmployeeRecord> result = data.OrderBy(x => x.Surname).ToList();
                data = result;
            }
            if (e.SortExpression == "YearOfBirth")
            {
                IList<EmployeeRecord> result = data.OrderBy(x => x.YearOfBirth).ToList();
                data = result;
            }

            EmployeeGridView.DataSource = data;
            EmployeeGridView.DataBind();
            EmployeeGridView.Visible = true;

        }


    }

    }

