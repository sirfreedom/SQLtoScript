using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScriptUtil
{
    public class OracleManager
    {
        #region Declaration

        private string _DbConectionString = string.Empty;
        private TipoMotor _MotorBaseDeDatos;
        
        private enum TipoMotor 
        { 
            Oracle = 1,
            SqlServer = 2,
            SoloInsert = 4
        }

        #endregion

        #region Constructor

        public OracleManager(string Host, string User, string Pass, bool IntegratedSecurity)
        {
            this._DbConectionString = this.ConectionStringOracle(Host, User, Pass, IntegratedSecurity);
        }

        #endregion

        #region Conection String

        private string ConectionStringOracle(string Host, string User, string Pass, bool IntegratedSecurity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Provider=OraOLEDB.Oracle.1;");
            builder.Append("Data Source=");
            builder.Append(Host);
            builder.Append(";user id=");
            builder.Append(User);
            builder.Append(";password=");
            builder.Append(Pass);
            if (IntegratedSecurity)
            {
                builder.Append(";Integrated Security=SSPI;");
            }
            return builder.ToString();
        }

        #endregion

        #region Methods Get

        private DataSet GetAllData(List<string> SelectTables)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataSet dsDatos = new DataSet("dsDatos");
            DataTable dtInfo = new DataTable("dtINFO");
            StringBuilder sbTablas = new StringBuilder();
            try
            {
                connection.ConnectionString = this._DbConectionString;
                connection.Open();
                cmd.Connection = connection;
                for (int i = 0; i < SelectTables.Count; i++)
                {
                    sbTablas.Append("'");
                    sbTablas.Append(SelectTables[i].ToString());
                    sbTablas.Append("'");
                    if ((SelectTables.Count - 1) != i)
                    {
                        sbTablas.Append(",");
                    }
                }
                cmd.CommandText = "SELECT t.Table_name, t.column_name, t.data_type from all_tab_columns t where t.table_name in ( " + sbTablas.ToString() + " ) AND t.data_type in ('NUMBER','VARCHAR','VARCHAR2','DATE','CHAR','LONG','DECIMAL','FLOAT','INT','INTEGER','NCHAR','NUMERIC','NVARCHAR2','SMALLINT','DEC','CHARACTER')";
                adapter.Fill(dtInfo);
                ds.Tables.Add(dtInfo);

                foreach (string sTabla in SelectTables)
                {
                    DataTable dtData = new DataTable(sTabla);
                    cmd.CommandText = "SELECT * FROM  " + sTabla + " where ROWNUM <= 500000";
                    adapter.Fill(dtData);
                    ds.Tables.Add(dtData);
                }
                dsDatos = ds;
            }
            catch (OleDbException oledbex)
            {
                throw oledbex;
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
            return dsDatos;
        }

        public DataTable GetTablesName()
        {
            OleDbConnection connection = new OleDbConnection();
            DataTable dtTables = new DataTable();
            connection.ConnectionString = this._DbConectionString;
            try
            {
                connection.Open();
                dtTables = connection.GetSchema("TABLES");
            }
            catch (OleDbException oledbex)
            {
                throw oledbex;
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

        #region Convert

        private string ConvertSQL_Datetime(string fecha)
        {
            StringBuilder sbFecha = new StringBuilder();

            if (fecha.IndexOf("a.m.") != 0 || fecha.IndexOf("AM") != 0)
            {
                fecha = fecha.Replace("a.m.", "");
                fecha = fecha.Replace("AM", "");
                fecha = fecha.Replace("12:", "00:");
            }
            if (fecha.IndexOf("p.m.") != 0 || fecha.IndexOf("PM") != 0)
            {
                fecha = fecha.Replace("p.m.", "");
                fecha = fecha.Replace("PM", "");
                fecha = fecha.Replace(" 1:", "13:");
                fecha = fecha.Replace(" 2:", "14:");
                fecha = fecha.Replace(" 3:", "15:");
                fecha = fecha.Replace(" 4:", "16:");
                fecha = fecha.Replace(" 5:", "17:");
                fecha = fecha.Replace(" 6:", "18:");
                fecha = fecha.Replace(" 7:", "19:");
                fecha = fecha.Replace(" 8:", "20:");
                fecha = fecha.Replace(" 9:", "21:");
                fecha = fecha.Replace("10:", "22:");
                fecha = fecha.Replace("11:", "23:");
            }

            sbFecha.Append("convert(datetime,");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(")");

            return sbFecha.ToString();
        }

        private string ConvertORACLE_Datetime(string fecha)
        {
            StringBuilder sbReturn = new StringBuilder();
            sbReturn.Append("to_date('");
            sbReturn.Append(fecha);
            sbReturn.Append("'");
            sbReturn.Append(",'DD/MM/YYYY HH24:MI:SS')");
            return sbReturn.ToString();
        }

        private string ConvertORACLE_Boolean(string value)
        {
            StringBuilder sbReturn = new StringBuilder();
            value.ToLower().Replace("true", "1");
            value.ToLower().Replace("false", "0");
            return sbReturn.ToString();
        }

        private string ConvertSQL_Boolean(string value)
        {
            StringBuilder sbReturn = new StringBuilder();
            sbReturn.Append("convert(bit,");
            sbReturn.Append("'");
            sbReturn.Append(value);
            sbReturn.Append("'");
            sbReturn.Append(")");
            return sbReturn.ToString();
        }

        #endregion

        #region Method Export

        private string CommonCreateQueries(List<string> SelectTables)
        {
            DataSet dsAllData = new DataSet();
            string sActiveTable = string.Empty;
            DataTable dtInfo = new DataTable();
            StringBuilder sbConsulta = new StringBuilder();
            try
            {
                dsAllData = this.GetAllData(SelectTables);
                dsAllData = this.GetAllData(SelectTables);
                dtInfo = dsAllData.Tables["dtINFO"];
                dsAllData.Tables.Remove("dtINFO");
                 
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

                    sConsultaINI = "INSERT INTO dbo.[" + sActiveTable + "] ( " + sbConsulta.ToString() + " ) VALUES ( ";

                    foreach (DataRow drActiveRow in dtActiveTable.Rows)
                    {
                        StringBuilder sbRowValues = new StringBuilder();

                        for (int iActiveColumn = 0; iActiveColumn < dtActiveTable.Columns.Count; iActiveColumn++)
                        {
                            string sType = string.Empty;
                            DataRow[] drTypes = dtInfo.Select("TABLE_NAME =  '" + sActiveTable + "' and COLUMN_NAME = '" + dtActiveTable.Columns[iActiveColumn].ColumnName.ToString() + "'");
                            foreach (DataRow drType in drTypes)
                            {
                                sType = drType[2].ToString();
                            }
                            switch (sType.ToLower())
                            {
                                case "varchar2":
                                case "char":
                                case "varchar":
                                case "character":
                                    sbRowValues.Append("'");
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    sbRowValues.Append("'");
                                    break;
                                case "int":
                                case "float":
                                case "integer":
                                case "numeric":
                                case "dec":
                                case "long":
                                case "decimal":
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    break;
                                case "date":
                                    if (_MotorBaseDeDatos == TipoMotor.Oracle)
                                    {
                                        sbRowValues.Append(ConvertORACLE_Datetime(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SqlServer)
                                    {
                                        sbRowValues.Append(ConvertSQL_Datetime(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SoloInsert) 
                                    {
                                        sbRowValues.Append("'");
                                        sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                        sbRowValues.Append("'");
                                    }
                                    break;
                                case "boolean":
                                case "bool":
                                case "bit":
                                    if (_MotorBaseDeDatos == TipoMotor.Oracle) 
                                    {
                                        sbRowValues.Append(ConvertORACLE_Boolean(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SqlServer) 
                                    {
                                        sbRowValues.Append(ConvertSQL_Boolean(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SoloInsert) 
                                    {
                                        sbRowValues.Append("'");
                                        sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                        sbRowValues.Append("'");
                                    }
                                    break;
                                default:
                                    sbRowValues.Append("'");
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    sbRowValues.Append("'");
                                    break;
                            }

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
                sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sbConsulta.ToString();
        }
             
        public string SaveOutputScript_Oracle(List<string> SelectTables)
        {
            string sTablaActiva = string.Empty;
            StringBuilder sbConsulta = new StringBuilder();
            try
            {
                sbConsulta.AppendLine("SET SERVEROUTPUT ON");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.Append("BEGIN ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();

                _MotorBaseDeDatos = TipoMotor.Oracle;
                sbConsulta.AppendLine(CommonCreateQueries(SelectTables));
     
                sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine("COMMIT;");
                sbConsulta.AppendLine("EXCEPTION WHEN OTHERS THEN ");
                sbConsulta.AppendLine("dbms_output.put_line( SQLCODE || '   ********    ' || SQLERRM ); ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine("dbms_output.put_line('*************************************************************************' ); ");
                sbConsulta.AppendLine("dbms_output.put_line('OCURRIO UN ERROR EN EL PROCESAMIENTO DE LOS DATOS, NO SE HA INSERTADO NADA'); ");
                sbConsulta.AppendLine("dbms_output.put_line('*************************************************************************'); ");
                sbConsulta.AppendLine("ROLLBACK;");
                sbConsulta.AppendLine("END;");
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

        public string SaveOutputScript_SQL2000(List<string> SelectTables)
        {
            string sActiveTable = string.Empty;
            StringBuilder sbConsulta = new StringBuilder();
            try
            {
                sbConsulta.AppendLine("SET QUOTED_IDENTIFIER ON ");
                sbConsulta.AppendLine("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE ");
                sbConsulta.AppendLine("SET ARITHABORT ON ");
                sbConsulta.AppendLine("SET NUMERIC_ROUNDABORT OFF ");
                sbConsulta.AppendLine("SET CONCAT_NULL_YIELDS_NULL ON ");
                sbConsulta.AppendLine("SET ANSI_NULLS ON ");
                sbConsulta.AppendLine("SET ANSI_PADDING ON ");
                sbConsulta.AppendLine("SET ANSI_WARNINGS ON ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine("GO ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.Append("BEGIN TRANSACTION ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();

                _MotorBaseDeDatos = TipoMotor.SqlServer;
                sbConsulta.AppendLine(CommonCreateQueries(SelectTables));


                sbConsulta.AppendLine();
                sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();

                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine("COMMIT TRANSACTION  ");
                sbConsulta.AppendLine();
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

        public string SaveOutputScript_SQL2005(List<string> SelectTables)
        {
            DataSet dsAllData = new DataSet();
            string sActiveTable = string.Empty;
            DataTable dtInfo = new DataTable();
            StringBuilder sbConsulta = new StringBuilder();
            try
            {
                dsAllData = this.GetAllData(SelectTables);

                dsAllData = this.GetAllData(SelectTables);
                dtInfo = dsAllData.Tables["dtINFO"];
                dsAllData.Tables.Remove("dtINFO");

                sbConsulta.AppendLine("SET QUOTED_IDENTIFIER ON ");
                sbConsulta.AppendLine("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE ");
                sbConsulta.AppendLine("SET ARITHABORT ON ");
                sbConsulta.AppendLine("SET NUMERIC_ROUNDABORT OFF ");
                sbConsulta.AppendLine("SET CONCAT_NULL_YIELDS_NULL ON ");
                sbConsulta.AppendLine("SET ANSI_NULLS ON ");
                sbConsulta.AppendLine("SET ANSI_PADDING ON ");
                sbConsulta.AppendLine("SET ANSI_WARNINGS ON ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine("GO ");
                sbConsulta.AppendLine();
                sbConsulta.Append("BEGIN TRANSACTION ");
                sbConsulta.AppendLine("BEGIN TRY");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                foreach (DataTable dtActiveTable in dsAllData.Tables)
                {
                    StringBuilder sbColumns = new StringBuilder();
                    sActiveTable = dtActiveTable.TableName.Trim();
                    string sConsultaINI = string.Empty;

                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine("---************************************** ");
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

                    sConsultaINI = "INSERT INTO dbo.[" + sActiveTable + "] ( " + sbConsulta.ToString() + " ) VALUES ( ";

                    foreach (DataRow drActiveRow in dtActiveTable.Rows)
                    {
                        StringBuilder sbRowValues = new StringBuilder();

                        for (int iActiveColumn = 0; iActiveColumn < dtActiveTable.Columns.Count; iActiveColumn++)
                        {
                            string sType = string.Empty;
                            DataRow[] drTypes = dtInfo.Select("TABLE_NAME =  '" + sActiveTable + "' and COLUMN_NAME = '" + dtActiveTable.Columns[iActiveColumn].ColumnName.ToString() + "'");
                            foreach (DataRow drType in drTypes)
                            {
                                sType = drType[2].ToString();
                            }
                            switch (sType.ToLower())
                            {
                                case "varchar2":
                                case "char":
                                case "varchar":
                                case "character":
                                    sbRowValues.Append("'");
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    sbRowValues.Append("'");
                                    break;
                                case "int":
                                case "float":
                                case "integer":
                                case "numeric":
                                case "dec":
                                case "long":
                                case "decimal":
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    break;
                                case "date":
                                    sbRowValues.Append("to_date('");
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    sbRowValues.Append(",'DD/MM/YYYY HH24:MI:SS')");
                                    break;
                                default:
                                    sbRowValues.Append("'");
                                    sbRowValues.Append(drActiveRow[dtActiveTable.Columns[iActiveColumn].ColumnName].ToString());
                                    sbRowValues.Append("'");
                                    break;
                            }

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
                sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine("COMMIT TRANSACTION ");
                sbConsulta.AppendLine("PRINT '*************************************************************************' ");
                sbConsulta.AppendLine("PRINT 'Datos insertados Correctamente' ");
                sbConsulta.AppendLine("PRINT '*************************************************************************' ");
                sbConsulta.AppendLine("END TRY");
                sbConsulta.AppendLine("BEGIN CATCH");
                sbConsulta.AppendLine("PRINT '*************************************************************************' ");
                sbConsulta.AppendLine("PRINT 'OCURRIO UN ERROR EN EL PROCESAMIENTO DE LOS DATOS, NO SE HA INSERTADO NADA' ");
                sbConsulta.AppendLine("PRINT '*************************************************************************' ");
                sbConsulta.AppendLine("ROLLBACK TRANSACTION  ");
                sbConsulta.AppendLine("END CATCH");
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

    }
}

