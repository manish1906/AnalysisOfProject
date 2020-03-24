using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MovieDetails
{
    public abstract class Base
    {
        public Base()
        {
            this.SqlConnection = new SqlConnection(@"data Source=MANISHPARMAR\SQLEXPRESS;initial catalog=MovieDetailsDb; Integrated Security=True;MultipleActiveResultSets=True;");
            this.SqlConnection.Open();

        }
        public SqlDataReader GetReader(string commadText)
        {
            this.SqlCommand = new SqlCommand(commadText, this.SqlConnection);
            return this.SqlCommand.ExecuteReader();
        }
        public void ExecuteNonQuery(string commandText)
        {
            SqlCommand SqlCommand = new SqlCommand(commandText, this.SqlConnection);
            SqlCommand.ExecuteNonQuery();

        }
        public void CloseConnection()
        {
            this.SqlConnection.Close();
        }
        public SqlConnection SqlConnection { get; set; }
        public SqlCommand SqlCommand { get; set; }



    }
}
