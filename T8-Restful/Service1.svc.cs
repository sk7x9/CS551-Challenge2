using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace T8_Restful
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {


        /// 
        /// Query age, company, position based on name
        ///

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "queryInfo/{name}")]

        public Person QueryInfo(string name)
        {
            //Declare Connection by passing the connection string from the web config file
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            //Open the connection
            conn.Open();

            string age = "";
            string name2 = "";
            string company = "";
            string position = "";

            //Declare the sql command
            SqlCommand cmd = new SqlCommand("Select * From testTable where name='" + name + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                age = age + ";" + reader["age"];
                name2 = name2 + ";" + reader["name"].ToString();
                company = company + ";" + reader["company"].ToString();
                position = position + ";" + reader["position"].ToString();
            }
            reader.Close();
            //close the connection
            conn.Close();


            //Open the connection
            // lookup person with the requested id 
            return new Person()
            {
                Age = age,
                Name = name2,
                company = company,
                position = position

            };
        }








        /// 
        /// Insert name, age, company, position to database
        ///

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insertInfo/{name}/{age}/{company}/{position}")]

        public Person InsertInfo(string name, string age, string company, string position)
        {
            //Declare Connection by passing the connection string from the web config file
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            //Open the connection
            conn.Open();

            //Declare the sql command
            SqlCommand cmd = new SqlCommand
                ("Insert into testTable(name,age,company,position)values('" + name + "','" + age + "','" + company + "','" + position + "')", conn);

            //Execute the insert query
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            //close the connection
            conn.Close();


            //Open the connection
            // lookup person with the requested id 
            return new Person()
            {
                Age = age,
                Name = name,
                company = company,
                position = position

            };
        }




        /// 
        /// delete all information realted to a certain name
        ///

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "deleteInfo/{name}")]

        public string DeleteInfo(string name)
        {
            //Declare Connection by passing the connection string from the web config file
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            //Open the connection
            conn.Open();

            //Declare the sql command
            SqlCommand cmd = new SqlCommand("Delete From testTable Where name= '" + name + "'", conn);

            //Execute the insert query
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            //close the connection
            conn.Close();


            return "Delete Successfully";
        }




        [WebInvoke(UriTemplate = "TestPost", Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]


        public int Test(string value)  //Value stays null
        {
            return 0;
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }
    }


    public class Person
    {

        public string Age { get; set; }

        public string Name { get; set; }

        public string company { get; set; }

        public string position { get; set; }

    }
}
