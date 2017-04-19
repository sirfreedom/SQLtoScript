using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Xml;

namespace ScriptUtil
{
    public class XMLManager
    {

        #region Declaration 

        private static readonly XMLManager _instance = new XMLManager();

        #endregion

        #region Constructor

        private XMLManager() 
        {
        }

        #endregion

        #region Method

        public void GetData(string file_path) 
        {
            Hashtable tabla = new Hashtable();
            XmlTextReader reader = new XmlTextReader(file_path);
            String atributo, nombre;
            atributo = String.Empty;
            nombre = String.Empty;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    nombre = reader.Name;
                }
                else
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        atributo = reader.Value.Replace("\r\n", String.Empty).Trim();
                    }
                }
                if (atributo != String.Empty && nombre != String.Empty)
                {
                    tabla.Add(nombre, atributo);
                    atributo = String.Empty;
                    nombre = String.Empty;
                }
            }
            reader.Close();
            //return tabla;
        }

        #endregion



        #region Singleton

        /// <summary>
        /// Solo una instancia del archivo debe estar abierta por vez.
        /// </summary>
        public static XMLManager GetInstance
        {
            get
            {
                return _instance;
            }
        }

        #endregion



    }
}
