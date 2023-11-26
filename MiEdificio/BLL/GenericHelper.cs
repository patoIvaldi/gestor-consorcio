using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//using Newtonsoft.Json;

namespace BLL
{
    public class GenericHelper
    {

        private static GenericHelper _instance;

        //singleton para la instancia del helper
        public static GenericHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GenericHelper();
                }
                return _instance;
            }
        }

        public void AdjustRowHeight(DataGridView dataGridView)
        {
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        // Usa una celda específica para calcular la altura.
                        int rowIndex = cell.RowIndex;
                        int columnIndex = cell.ColumnIndex;
                        DataGridViewColumn column = dataGridView.Columns[columnIndex];

                        using (Graphics graphics = dataGridView.CreateGraphics())
                        {
                            SizeF size = graphics.MeasureString(cell.Value.ToString(), dataGridView.Font, column.Width);
                            int newHeight = (int)size.Height + 5; // Puedes ajustar este valor.

                            if (dataGridView.Rows[rowIndex].Height < newHeight)
                            {
                                dataGridView.Rows[rowIndex].Height = newHeight;
                            }
                        }
                    }
                }
            }
        }

        public DataSet SerializarObjetoEnXML(DataTable dt, string rutaArchivo, string nombreArchivo)
        {
            /*
                        // Crear un objeto XmlSerializer
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataGridView));

                        // Crear un StreamWriter para escribir en un archivo
                        using (StreamWriter streamWriter = new StreamWriter(rutaArchivo+nombreArchivo + ".xml"))
                        {
                            // Serializar el objeto y escribirlo en el archivo
                            xmlSerializer.Serialize(streamWriter, dgv);
                        }*/

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);

            // Escribir el DataSet como XML
            dataSet.WriteXml(rutaArchivo+nombreArchivo+".xml");


            return dataSet;
        }

        public BE.Metrica DeserializarObjetoXML(string rutaArchivo, string nombreArchivo)
        {
            // Crear un objeto XmlSerializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BE.Metrica));
            BE.Metrica metrica = null;

            // Crear un StreamReader para leer el archivo
            using (StreamReader streamReader = new StreamReader(rutaArchivo + nombreArchivo + ".xml"))
            {
                // Deserializar el objeto desde el archivo XML
                metrica = (BE.Metrica)xmlSerializer.Deserialize(streamReader);
            }

            return metrica;
        }

        public string SerializarObjetoEnJSON(BE.Metrica metrica, string rutaArchivo, string nombreArchivo)
        {
            string json = "";
            // Serializar a formato JSON
            //json = JsonConvert.SerializeObject(metrica);

            // Escribir el JSON en un archivo
            File.WriteAllText(rutaArchivo+nombreArchivo + ".json", json);

            return json;
        }
    }
}
