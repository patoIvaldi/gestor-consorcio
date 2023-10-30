using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
