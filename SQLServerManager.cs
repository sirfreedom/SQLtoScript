/*
Hecho por Alejandro Millan 
OpenSource 
Finalidad: 
poder generar sentencias SQL INSERT basicas para poder implemtar algun sistema.

*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ScriptUtil
{

    public class SQLServerManager 
    {
        
        #region Declaration

        private string DbConectionString = string.Empty;
        private string _Schema = string.Empty;
        DataSet _dsAllData = new DataSet();
        DataSet _dsTablesInfo = new DataSet();
        private TipoMotor _MotorBaseDeDatos;
        private LenguajePuntoComa _Lenguaje;

        private enum TipoMotor
        {
            Oracle = 1,
            SqlServer = 2,
            SoloInsert = 4
        }

        public enum LenguajePuntoComa 
        { 
            Punto = 1,
            Coma = 2
        }

        public LenguajePuntoComa Lenguaje 
        {
            set {
                _Lenguaje = value;
            }
        }

        #endregion

        #region Constructor / Destructor / Dispose

        public SQLServerManager(string BaseName, string ServerName, string User, string Pass, string Schema,bool IntegrateSecurity)
        {
            _Schema = Schema;
            this.DbConectionString = this.ConectionStringManagerSql(BaseName, ServerName, User, Pass,IntegrateSecurity);
        }

        ~SQLServerManager() 
        {
            //mueren los recursos pero es mas limpio quitarlos de la memoria.
            _dsAllData = null;
            _dsTablesInfo = null;
        }
        
        #endregion

        #region Conection String

        private string ConectionStringManagerSql(string BaseName, string ServerName, string User, string Pass, bool IntegrateSegurity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Initial Catalog=");
            builder.Append(BaseName);
            builder.Append(";");
            builder.Append("Initial Catalog=");
            builder.Append(BaseName);
            builder.Append(";");
            builder.Append("Data Source=");
            builder.Append(ServerName);
            builder.Append(";");
            if (User.Length != 0 && Pass.Length != 0)
            {
                builder.Append("UID=");
                builder.Append(User);
                builder.Append(";");
                builder.Append("PASSWORD=");
                builder.Append(Pass);
                builder.Append(";");
            }

            if (IntegrateSegurity) 
            {
                builder.Append("Integrated Security=SSPI;");
            }
            return builder.ToString();
        }

        #endregion

        #region Method Get Data

        private void GetAllData(List<string> SelectTables)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dtConsultas = new DataTable();
            StringBuilder sbTablasFilter = new StringBuilder();
            StringBuilder sbConsultaIni = new StringBuilder();
            string sConsulta = string.Empty;
            string ConsultaRelacion = "select * from &tabla& where isnull(&idpadre&,0) &igualdad& 0";
            string ConsultaIni = "SELECT top 500000 * from "; //no mas de cien mil registros
            string Schema = string.Empty;
            try
            {
                connection.ConnectionString = this.DbConectionString;
                connection.Open();
                cmd.Connection = connection;

                int iFinal = 0;
                while (iFinal < SelectTables.Count)
                {
                    sbTablasFilter.Append("'");
                    sbTablasFilter.Append(SelectTables[iFinal]);
                    sbTablasFilter.Append("'");
                    if ((SelectTables.Count - 1) != iFinal)
                    {
                        sbTablasFilter.Append(",");
                    }
                    iFinal++;
                }

                sbConsultaIni.Append(ConsultaIni);

                //inteligentemente genera el schema en caso de que exista.
                if (_Schema.Length != 0)
                {
                    Schema = "[" + _Schema + "].";
                }

                //nos trae las tablas que mayor relaciones tienen para insertarlas primero.
                sConsulta = "select so.name as nombre, count(*) relaciones FROM SYSOBJECTS so left join sysforeignkeys sfk on sfk.rkeyid = so.id WHERE TYPE = 'U' AND NAME != 'dtproperties' and so.name in ( " + sbTablasFilter.ToString() + " )  group by so.name order by relaciones desc";
                cmd.CommandText = sConsulta;
                da.Fill(dtConsultas);
            
                //va llenando un dataset con datos uno a uno.
                foreach (DataRow drConsulta in dtConsultas.Rows)
                {
                    DataTable dtActiveTable = new DataTable();
                    string nombretabla = string.Empty;
                    nombretabla = drConsulta["nombre"].ToString();
                    bool bTieneRelacion = false;

                    // este for sirve para que en el caso de que exista una tabla que esta relacionada consigo misma y este entre nuestra seleccion de tablas no nos traiga problemas
                    foreach (DataRow drConRelaciones in _dsTablesInfo.Tables["tablarelacionunivoca"].Rows) 
                    { 
                        if(nombretabla.Equals(drConRelaciones["TableName"].ToString()))
                        {
                            bTieneRelacion = true;
                            string ColumnaRelacion = string.Empty;
                            DataTable dtAdional = new DataTable();
                            ColumnaRelacion = drConRelaciones["ColumnName"].ToString();

                            //hacemos una consulta sobre los items que el idpadre es null 
                            cmd.CommandText = ConsultaRelacion.Replace("&tabla&", Schema + nombretabla).Replace("&idpadre&", ColumnaRelacion).Replace("&igualdad&", "=");
                            da.Fill(dtActiveTable);
                            //hacemos una consulta sobre los items que el idpadre es un numero y tiene relacion directa con la pk para evitar errores.
                            cmd.CommandText = ConsultaRelacion.Replace("&tabla&", Schema + nombretabla).Replace("&idpadre&", ColumnaRelacion).Replace("&igualdad&", "!=");
                            da.Fill(dtAdional);

                           //es un union manual, para que primero inserte los registros ordenados
                            dtActiveTable.Merge(dtAdional);
                        }
                    }
                    
                    if(bTieneRelacion == false)
                    {
                        cmd.CommandText = sbConsultaIni.ToString() + Schema + nombretabla;
                        da.Fill(dtActiveTable);    
                    }

                    dtActiveTable.TableName = nombretabla;
                    ds.Tables.Add(dtActiveTable);
                }

                _dsAllData = ds;
            }
            catch (OleDbException oleex)
            {
                throw new Exception("Verifique el Schema", oleex);
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
        }

        public DataSet GetTables()
        {
            SqlConnection connection = new SqlConnection();
            DataSet dsTables = new DataSet("dsTables");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            StringBuilder sbConsultas = new StringBuilder();
            try
            {
                sbConsultas.AppendLine("SELECT id,name FROM SYSOBJECTS WHERE TYPE = 'U' AND NAME != 'dtproperties'  ");
                sbConsultas.AppendLine();
                sbConsultas.AppendLine("select sfk.rkeyid as id,so.name, count(*) relaciones from sysforeignkeys sfk inner join sysobjects so on so.id = sfk.rkeyid group by sfk.rkeyid, so.name having count(*) > 1 order by relaciones desc  ");
                connection.ConnectionString = this.DbConectionString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                da.SelectCommand = cmd;
                cmd.CommandText = sbConsultas.ToString();
                connection.Open();
                da.Fill(dsTables);
                dsTables.Tables[0].TableName = "tablanombres";
                dsTables.Tables[1].TableName = "tablarelaciones";
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsTables;
        }

        private void GetTablesInfo(List<string> lTables)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            StringBuilder sbConsultas = new StringBuilder();
            StringBuilder sbTablasFilter = new StringBuilder();
            try
            {
                int iFinal = 0;
                while (iFinal < lTables.Count)
                {
                    sbTablasFilter.Append("'");
                    sbTablasFilter.Append(lTables[iFinal]);
                    sbTablasFilter.Append("'");
                    if ((lTables.Count - 1) != iFinal)
                    {
                        sbTablasFilter.Append(",");
                    }
                    iFinal++;
                }
                //Consulta de Tablas 
                sbConsultas.AppendLine("SELECT so.id, so.name, count(*) relaciones FROM SYSOBJECTS so left join sysforeignkeys sfk 	on sfk.rkeyid = so.id WHERE TYPE = 'U' AND NAME != 'dtproperties' and so.name in ( " + sbTablasFilter.ToString() + " )  group by so.id , so.name order by relaciones desc ");
                sbConsultas.AppendLine();
                //Consulta de Columnas
                sbConsultas.AppendLine("select so.id, sc.name nombrecolumna, st.name tipo,st.length tamanodato from syscolumns sc inner join systypes st on st.xtype = sc.xtype inner join SYSOBJECTS so on sc.id = so.id WHERE so.TYPE = 'U' and sc.name not in ( select ic.name from sys.identity_columns ic inner join sysobjects so on so.id = ic.object_id where is_identity = 1 and so.TYPE = 'U' and so.NAME != 'dtproperties' and IDENT_INCR(OBJECT_NAME(id)) > 0 ) and so.NAME != 'dtproperties' and so.name in ( " + sbTablasFilter.ToString() + " )  order by so.id desc ");
                sbConsultas.AppendLine();
                //consulta de tablas con mayores relaciones
                sbConsultas.AppendLine("select sfk.rkeyid as id,so.name, count(*) relaciones from sysforeignkeys sfk inner join sysobjects so on so.id = sfk.rkeyid group by sfk.rkeyid, so.name having count(*) > 1 order by relaciones desc  ");
                sbConsultas.AppendLine();
                //Consulta de tablas relacionadas consigo mismas, para obtener un ordenamiento por su PrimaryKey y que no de error de insercion.
                sbConsultas.AppendLine("SELECT OBJECT_NAME(f.parent_object_id) AS TableName, COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName, OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName, COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName FROM sys.foreign_keys AS f INNER JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id where f.parent_object_id in (select fkeyid from sysforeignkeys sfk where fkeyid = rkeyid) and OBJECT_NAME(f.parent_object_id) in ( " + sbTablasFilter.ToString() + " ) ");
                sbConsultas.AppendLine();
                //Estas tablas son las que necesitamos agregarle el item set identity para poder insertar su pk correctamente.
                sbConsultas.AppendLine("select so.name from sys.identity_columns ic inner join sysobjects so on so.id = ic.object_id where is_identity = 1 and so.TYPE = 'U' and so.NAME != 'dtproperties' ");
                sbConsultas.AppendLine();

                connection.ConnectionString = this.DbConectionString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                da.SelectCommand = cmd;
                cmd.CommandText = sbConsultas.ToString();
                connection.Open();
                da.Fill(_dsTablesInfo);

                _dsTablesInfo.Tables[0].TableName = "tablanombres";
                _dsTablesInfo.Tables[1].TableName = "tablacolumna";
                _dsTablesInfo.Tables[2].TableName = "tablarelaciones";
                _dsTablesInfo.Tables[3].TableName = "tablarelacionunivoca";
                _dsTablesInfo.Tables[4].TableName = "tablasetidentity";
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Convert

        private string ConvertSQL_Datetime(string fecha) 
        {
            StringBuilder sbFecha = new StringBuilder();

            if (fecha.IndexOf("a.m.") != 0 || fecha.IndexOf("AM") != 0) 
            {
               fecha = fecha.Replace("a.m.","");
               fecha = fecha.Replace("AM", "");
               fecha = fecha.Replace("12:", "00:");
            }
            if (fecha.IndexOf("p.m.") != 0 || fecha.IndexOf("PM") != 0  ) 
            {
                fecha = fecha.Replace("p.m.","");
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


            sbFecha.Append("convert(datetime,(substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 7, 4) + '/' + substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 4, 2) + '/' + substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 1, 2) + ' ' + substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 11, 16)))");

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

        private string ConvertSQL_Int(string value) 
        {
            StringBuilder sbReturn = new StringBuilder();

            if (value.Length == 0)
            {
                sbReturn.Append("null");
            }
            else 
            {
                sbReturn.Append(value);
            }
            
            return sbReturn.ToString();
        }

        private string ConvertSQL_Decimal(string value) 
        {
            StringBuilder sbReturn = new StringBuilder();

            if (_Lenguaje == LenguajePuntoComa.Punto)
            {
                value = value.Replace(",", ".");
            }
            if (_Lenguaje == LenguajePuntoComa.Coma)
            {
                value = value.Replace(".", ",");
            }
            sbReturn.Append("convert(decimal,'");
            sbReturn.Append(value);
            sbReturn.Append("')");
            return sbReturn.ToString();
        }
        
        #endregion

        #region Method Export

        private string CommonCreateQueries(List<string> SelectTables)
        {
            string sActiveTable = string.Empty;
            string sActiveIdTable = string.Empty;
            StringBuilder sbConsulta = new StringBuilder();
            string Schema = string.Empty;
            try
            {
                GetAllData(SelectTables);
                
                if (_Schema.Length != 0)
                {
                    Schema = "[" + _Schema + "].";
                }

                foreach (DataRow drTablaActiva in _dsTablesInfo.Tables["tablanombres"].Rows)
                {
                    sActiveTable = drTablaActiva["name"].ToString();
                    sActiveIdTable = drTablaActiva["id"].ToString();
                    StringBuilder sbColumns = new StringBuilder();
                    DataRow[] drColumns = _dsTablesInfo.Tables["tablacolumna"].Select("id = " + sActiveIdTable);
                    StringBuilder sbConsultaIni = new StringBuilder();

                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.Append("---************************************** ");
                    sbConsulta.Append(sActiveTable);
                    sbConsulta.Append("***********************************");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();

                    if (_dsTablesInfo.Tables["tablasetidentity"].Select("name = '" + sActiveTable + "'").Length == 1  && _MotorBaseDeDatos == TipoMotor.SqlServer ) 
                    {
                        sbConsulta.AppendLine();
                        sbConsulta.Append("SET IDENTITY_INSERT ");
                        sbConsulta.Append(Schema);
                        sbConsulta.Append(sActiveTable);
                        sbConsulta.Append(" ON");
                    }

                    sbConsulta.AppendLine();

                    int iFinalColumna = 0;
                    foreach (DataRow drColumn in drColumns)
                    {
                        sbColumns.Append(drColumn["nombrecolumna"].ToString());

                        if ((drColumns.Length - 1) != iFinalColumna)
                        {
                            sbColumns.Append(",");
                        }
                        iFinalColumna++;
                    }

                    sbConsultaIni.Append("INSERT INTO ");

                    sbConsultaIni.Append(Schema);

                    sbConsultaIni.Append("");
                    sbConsultaIni.Append(sActiveTable);
                    sbConsultaIni.Append("");
                    sbConsultaIni.Append(" ( ");
                    sbConsultaIni.Append(sbColumns.ToString());
                    sbConsultaIni.Append(" ) VALUES ( ");

                    foreach (DataRow drdato in _dsAllData.Tables[sActiveTable].Rows)
                    {
                        iFinalColumna = 0;
                        StringBuilder sbValores = new StringBuilder();
                        foreach (DataRow drColumn in drColumns)
                        {
                            string stipo = drColumn["tipo"].ToString();
                            string scolumna = drColumn["nombrecolumna"].ToString();

                            switch (stipo)
                            {
                                case "char":
                                case "text":
                                case "varchar":
                                case "nchar":
                                case "nvarchar":
                                    sbValores.Append("'");
                                    sbValores.Append(drdato[scolumna].ToString().Trim());
                                    sbValores.Append("'");
                                    break;
                                case "tinyint":
                                case "int":
                                case "smallint":
                                case "bigint":
                                    sbValores.Append(ConvertSQL_Int(drdato[scolumna].ToString().Trim()));
                                    break;
                                case "numeric":
                                case "decimal":
                                case "money":
                                case "smallmoney":
                                case "real":
                                case "float":
                                    sbValores.Append(ConvertSQL_Decimal(drdato[scolumna].ToString().Trim()));
                                    break;
                                case "bit":
                                    if (_MotorBaseDeDatos == TipoMotor.SqlServer)
                                    {
                                        sbValores.Append(ConvertSQL_Boolean(drdato[scolumna].ToString().Trim()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.Oracle) 
                                    {
                                        sbValores.Append(ConvertORACLE_Boolean(drdato[scolumna].ToString().Trim()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SoloInsert)
                                    {
                                        sbValores.Append("'");
                                        sbValores.Append(drdato[scolumna].ToString().Trim());
                                        sbValores.Append("'");
                                    }
                                    break;
                                case "datetime":
                                case "date":
                                case "time":
                                case "smalldatetime":
                                    if (_MotorBaseDeDatos == TipoMotor.Oracle)
                                    {
                                        sbValores.Append(ConvertORACLE_Datetime(drdato[scolumna].ToString().Trim()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SqlServer) 
                                    {
                                        sbValores.Append(ConvertSQL_Datetime(drdato[scolumna].ToString().Trim()));
                                    }
                                    if (_MotorBaseDeDatos == TipoMotor.SoloInsert) 
                                    {
                                        sbValores.Append("'");
                                        sbValores.Append(drdato[scolumna].ToString().Trim());
                                        sbValores.Append("'");
                                    }
                                    break;
                                default:
                                    sbValores.Append("null");
                                    break;
                            }

                            if ((drColumns.Length - 1) != iFinalColumna)
                            {
                                sbValores.Append(",");
                            }
                            iFinalColumna++;
                        }
                        sbValores.Append(")");
                        sbConsulta.AppendLine();
                        sbConsulta.Append(sbConsultaIni.ToString());
                        sbConsulta.Append(sbValores.ToString());
                    }

                    if (_dsTablesInfo.Tables["tablasetidentity"].Select("name = '" + sActiveTable + "'").Length == 1 && _MotorBaseDeDatos == TipoMotor.SqlServer)
                    {
                        sbConsulta.AppendLine();
                        sbConsulta.AppendLine();
                        sbConsulta.AppendLine();
                        sbConsulta.Append("SET IDENTITY_INSERT ");
                        sbConsulta.Append(Schema);
                        sbConsulta.Append(sActiveTable);
                        sbConsulta.Append(" OFF");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sbConsulta.ToString();
        }

        public string SaveOutputScript_SQL2000(List<string> SelectTables)
        {
            StringBuilder sbConsulta = new StringBuilder();
            StringBuilder sbSChema = new StringBuilder();
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

                GetTablesInfo(SelectTables);
  
                sbConsulta.Append(CommonCreateQueries(SelectTables));

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
            DataSet dsTablesInfo = new DataSet();
            string sActiveTable = string.Empty;
            StringBuilder sbConsulta = new StringBuilder();
            StringBuilder sbSChema = new StringBuilder();
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
                sbConsulta.AppendLine("BEGIN TRANSACTION ");
                sbConsulta.AppendLine("BEGIN TRY");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                
                _MotorBaseDeDatos = TipoMotor.SqlServer;
                GetTablesInfo(SelectTables);
   
                sbConsulta.Append(CommonCreateQueries(SelectTables));

                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
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
                throw new Exception("Verifique el Schema" + ex.Message);
            }
            return sbConsulta.ToString();
        }

        public string SaveOutputScript_Oracle(List<string> SelectTables)
        {
            DataSet dsAllData = new DataSet();
            DataSet dsTablesInfo = new DataSet();
            string sTablaActiva = string.Empty;
            StringBuilder sbConsulta = new StringBuilder();
            StringBuilder sbMensajeFinal = new StringBuilder();
            try
            {
                sbConsulta.AppendLine("SET SERVEROUTPUT ON");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.Append("BEGIN ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();

                _MotorBaseDeDatos = TipoMotor.Oracle;
                GetTablesInfo(SelectTables);

                sbConsulta.Append(CommonCreateQueries(SelectTables));

                sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.Append(sbMensajeFinal.ToString());
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

        #endregion


      

    }
}

