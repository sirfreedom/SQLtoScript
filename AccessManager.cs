using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace ScriptUtil
{
    public class AccessManager
    {
        #region Declartion

        private static readonly AccessManager _instance = new AccessManager();
 
        #endregion

        #region Constructor

        private AccessManager()
        {
        }

        #endregion

        #region Conection

        private string ConectionStringManagerAccess(string FilePath)
        {
            StringBuilder builder = new StringBuilder();
            if (FilePath != string.Empty)
            {
                builder.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                builder.Append(FilePath);
                builder.Append(";Persist Security Info=False");
            }
            return builder.ToString();
        }

        #endregion

        #region Method Get

        private DataSet GetAllData(List<string> SelectTables,string FileName)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet dsData = new DataSet("dsData");
            try
            {
                connection.ConnectionString = ConectionStringManagerAccess(FileName);
                connection.Open();
                cmd.Connection = connection;
                foreach (string sActiveTable in SelectTables)
                {
                    DataTable dtData = new DataTable("dtData");
                    cmd.CommandText = "select * from [" + sActiveTable + "]";
                    adapter.Fill(dtData);
                    ds.Tables.Add(dtData);
                }
                dsData = ds;
            }
            catch (OleDbException oleex)
            {
                throw oleex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dsData;
        }

        public DataTable GetTablesName(string FileName)
        {
            OleDbConnection connection = new OleDbConnection();
            DataTable dtTables = new DataTable();
            connection.ConnectionString = ConectionStringManagerAccess(FileName);
            try
            {
                connection.Open();
                dtTables = connection.GetSchema("TABLES");
                for (int i = 0; i < dtTables.Rows.Count; i++)
                {
                    if (dtTables.Rows[i]["TABLE_TYPE"].ToString() != "TABLE")
                    {
                        dtTables.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (OleDbException oleex)
            {
                throw oleex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dtTables;
        }

        #endregion

        #region Method Export

        private string CommonCreateQueries(List<string> SelectTables, string FileName) 
        {
            DataSet dsAllData = new DataSet();
            StringBuilder sbConsulta = new StringBuilder();
            string sActiveTable = string.Empty;
            dsAllData = this.GetAllData(SelectTables,FileName);
            try
            {

                foreach (DataTable dtActiveTable in dsAllData.Tables)
                {
                    StringBuilder sbColumns = new StringBuilder();
                    sActiveTable = dtActiveTable.TableName.Trim();
                    string sConsultaINI = string.Empty;

                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.Append("---************************************** ");
                    sbConsulta.Append(sActiveTable);
                    sbConsulta.Append("***********************************");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();

                    int iFinalColumna = 0;
                    while (iFinalColumna < dtActiveTable.Columns.Count)
                    {
                        sbColumns.Append(dtActiveTable.Columns[iFinalColumna].ToString().Trim());
                        if ((dtActiveTable.Columns.Count - 1) != iFinalColumna)
                        {
                            sbColumns.Append(",");
                        }
                        iFinalColumna++;
                    }

                    sConsultaINI = "INSERT INTO [" + sActiveTable + "] ( " + sbConsulta.ToString() + " ) VALUES ( ";

                    foreach (DataRow drActiveRow in dtActiveTable.Rows)
                    {
                        StringBuilder sbRowValues = new StringBuilder();

                        for (int iActiveColumn = 0; iActiveColumn < dtActiveTable.Columns.Count; iActiveColumn++)
                        {
                            sbRowValues.Append("'");
                            sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                            sbRowValues.Append("'");

                            if ((dtActiveTable.Columns.Count - 1) != iActiveColumn)
                            {
                                sbRowValues.Append(",");
                            }
                        }
                        sbRowValues.Append(") ");
                        sbConsulta.Append(sConsultaINI);
                        sbConsulta.Append(sbRowValues.ToString());
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;           
            }
            return sbConsulta.ToString();
        }
        
        public string SaveOutput(List<string> SelectTables,string FileName)
        {
            DataSet dsAllData = new DataSet();
            string sTablaActiva = string.Empty;
            DataTable dtInfo = new DataTable();
            StringBuilder sbConsulta = new StringBuilder();
            StringBuilder sbMensajeFinal = new StringBuilder();
            try
            {
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();

                sbConsulta.Append(CommonCreateQueries(SelectTables,FileName));

                sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.Append(sbMensajeFinal.ToString());
                sbConsulta.AppendLine("--**************************  Fin de Query - Generated by SqlToScript ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sbConsulta.ToString();
        }

        #endregion

        #region Singleton

        public static AccessManager GetInstance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

    }
}

