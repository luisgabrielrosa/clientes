using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Database
{
    class Conexion
    {

        public static SqlConnection GetConnection()
        {
            SqlConnection oCon = new SqlConnection("Data Source=DESKTOP-NUGSCQ6;Initial Catalog=Test_Invoice;User ID=sa;Password=1234");
            return oCon;
        }

        public static DataTable GetTableFromCommand(SqlCommand cmd)
        {
            cmd.CommandTimeout = 300;
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            debug(cmd);
            d.Fill(dt);
            return dt;
        }

        public static DataRow GetTableRowFromCommand(SqlCommand cmd)
        {
            cmd.CommandTimeout = 300;
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            debug(cmd);
            if (dt.Rows.Count > 0) return dt.Rows[0];
            return null;
        }

        public static void FinishData(SqlCommand cmd)
        {
            if (cmd == null) return;


            if (!(cmd.Connection == null))
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            cmd.Dispose();

        }



        public static DataTable Exec_Stp(String stp_name, char c, params String[] vars)
        {
            SqlConnection conn = GetConnection();
            SqlCommand oCmd = null;
            DataTable t = null;
            SqlTransaction ot = null;
            try
            {
                conn.Open();
                oCmd = conn.CreateCommand();
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandText = stp_name;
                if (c.Equals('m'))
                {
                    ot = conn.BeginTransaction(IsolationLevel.ReadUncommitted);
                    oCmd.Transaction = ot;
                }
                if ((vars != null) && (vars.Length >= 2))
                {
                    for (int i = 0; i < vars.Length; i = i + 2)
                    {
                        oCmd.Parameters.AddWithValue(vars[i], vars[i + 1]);
                    }
                }
                debug(oCmd);
                if (c.Equals('m'))
                {
                    int ret = oCmd.ExecuteNonQuery();
                    ot.Commit();
                }
                else
                {
                    t = Conexion.GetTableFromCommand(oCmd);
                }
                return t;
            }
            finally
            {
                Conexion.FinishData(oCmd);
            }
        }


        public static void debug(SqlCommand cmd)
        {

            StringBuilder sss = new StringBuilder(256, 16384);

            String begin = @"
            -----------------------------------------            
            ";
            String parametro = @"            {0}='{1}'";

            sss.Append(begin);

            if (cmd.CommandType == CommandType.StoredProcedure)
            {
                sss.AppendFormat("EXEC ");
            }

            sss.AppendFormat("{0} ", cmd.CommandText);
            sss.AppendLine("");

            SqlParameter last_item = null;
            if (cmd.Parameters.Count > 0)
            {
                last_item = cmd.Parameters[cmd.Parameters.Count - 1];
            }
            foreach (SqlParameter item in cmd.Parameters)
            {

                if (item.ParameterName[0] != '@') { sss.Append("@"); }

                sss.AppendFormat(parametro, item.ParameterName, item.Value);

                if (last_item != item) { sss.Append(",\n"); }
            }

            sss.Append(begin);

            System.Diagnostics.Debug.Write(sss.ToString());
        }
    }
}
