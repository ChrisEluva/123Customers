using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using _123Customers.Models;

namespace _123Customers.Controllers
{
    public class CustomerController : Controller
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomerInformation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [HttpGet]
        // GET: Customer
        public ActionResult Index()
        {
            DataTable CustomerTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CustomerDetails", sqlConnection);
                sqlData.Fill(CustomerTable);
            }

        return View(CustomerTable);
        }

        [HttpGet]
        // GET: Customer
        public ActionResult Find(string name)
        {
            DataTable CustomerTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CustomerDetails WHERE CustomerName LIKE %" +name + "%", sqlConnection);
                sqlData.Fill(CustomerTable);
            }

            return View(CustomerTable);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customerModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "INSERT INTO CustomerDetails VALUES (@CustomerName,@AddressId,@CustomerPhoneNumber)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);

                sqlCmd.Parameters.AddWithValue("@CustomerName", customerModel.CustomerName);
                sqlCmd.Parameters.AddWithValue("@AddressId", customerModel.AddressId);
                sqlCmd.Parameters.AddWithValue("@CustomerPhoneNumber", customerModel.CustomerPhoneNumber);
                sqlCmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerModel customerModel = new CustomerModel();
            DataTable CustomerTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM CustomerDetails WHERE CustomerId = @CustomerId";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlConnection);
                sqlData.SelectCommand.Parameters.AddWithValue("@CustomerId", id);
                sqlData.Fill(CustomerTable);
            }

            if (CustomerTable.Rows.Count == 1)
            {
                customerModel.CustomerId = Convert.ToInt32(CustomerTable.Rows[0][0].ToString());
                customerModel.CustomerName = CustomerTable.Rows[0][1].ToString();
                customerModel.AddressId = Convert.ToInt32(CustomerTable.Rows[0][2].ToString());
                customerModel.CustomerPhoneNumber = CustomerTable.Rows[0][3].ToString();
                return View(customerModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerModel customerModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "UPDATE CustomerDetails SET CustomerName = @CustomerName, AddressId = @AddressId, CustomerPhoneNumber = @CustomerPhoneNumber";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@CustomerId", customerModel.CustomerId);
                sqlCmd.Parameters.AddWithValue("@CustomerName", customerModel.CustomerName);
                sqlCmd.Parameters.AddWithValue("@AddressId", customerModel.AddressId);
                sqlCmd.Parameters.AddWithValue("@CustomerPhoneNumber", customerModel.CustomerPhoneNumber);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "DELETE FROM CustomerDetails WHERE CustomerId = @CustomerId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@CustomerId", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        
    }
}
