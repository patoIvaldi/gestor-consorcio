using BE;
using BLL;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormReporteInteligente : Form
    {
        public FormReporteInteligente()
        {
            InitializeComponent();
        }

        public void TraducirComponentes()
        {
            IDictionary<string, string> traducciones = BLL.IdiomaBLL.INSTANCE.diccionario;

            if (traducciones is not null && traducciones.Count > 0)
            {
                this.Text = traducciones.ContainsKey(this.Name) ? traducciones[this.Name] : this.Text;

                foreach (Control c in this.Controls)
                {
                    //traduzco el texto del componente
                    c.Text = traducciones.ContainsKey(c.Name + "_" + this.Name) ? traducciones[c.Name + "_" + this.Name] : c.Text;

                    //si es un groupbox, recorro todos los componentes que tenga en su interior
                    if (c is GroupBox)
                    {
                        foreach (Control controlChild in ((GroupBox)c).Controls)
                        {
                            if (controlChild is UC_tb_numerico)
                            {
                                ((UC_tb_numerico)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_tb_numerico)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_tb_password)
                            {
                                ((UC_tb_password)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_tb_password)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_textbox)
                            {
                                ((UC_textbox)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_textbox)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_dttmPicker)
                            {
                                ((UC_dttmPicker)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_dttmPicker)controlChild).ETIQUETA;
                            }
                            else
                            {
                                controlChild.Text = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : controlChild.Text;
                            }
                        }
                    }
                }
            }
        }

        private void FormReporteInteligente_Load(object sender, EventArgs e)
        {

            TraducirComponentes();

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó al reporte inteligente.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Insertar.ToString();
            evento.MODULO = Enumerador.Modulo.Reportes.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            enlazarAnios();

            var p2 = fp_grafico.Plot;

            // Crear datos de ganancias por mes (reemplaza esto con tus datos reales)
            //double[] gananciasPorMes = ObtenerDatosGanancias();
            //double[] gananciasPorMes = { -10, 25, 15, 35, 50, 60, 45, 50, 35, 20, 15, 10 };
            //double[] meses = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            List<BE.Ganancia> ganancias = recuperarGanancias(DateTime.Now.Year);
            List<double> mesesList = new List<double>();
            List<double> gananciasPorMesList = new List<double>();

            foreach (BE.Ganancia g in ganancias)
            {
                mesesList.Add(double.Parse(g.MES.ToString()));
                gananciasPorMesList.Add(double.Parse(g.GANANCIA.ToString()));
            }

            double[] meses = mesesList.ToArray();
            double[] gananciasPorMes = gananciasPorMesList.ToArray();

            // create a histogram with a fixed number of bins
            ScottPlot.Statistics.Histogram hist = new(min: 1, max: 12, binCount: 12);
            p2.PlotBar(meses, gananciasPorMes);

            p2.SetAxisLimits(xMin: 1, xMax: 12);
            // Personalizar el grafico
            p2.Title("Flujo de ganancias por mes");
            p2.XLabel("Mes");
            p2.YLabel("Ganancias");

            p2.SaveFig("stats_histogram.png");

            fp_grafico.Refresh();

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            enlazarGrafico();
        }

        private void enlazarAnios()
        {
            cb_anios.DataSource = null;
            cb_anios.Items.Clear();
            cb_anios.Items.AddRange(BLL.GananciaBLL.Instance.ListarAnios().ToArray());
        }

        //recuperamos las ganancias de todos los anios
        private List<BE.Ganancia> recuperarGanancias(int anio)
        {
            return BLL.GananciaBLL.Instance.ListarGanancias(anio);
        }

        private void cb_anios_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void enlazarGrafico()
        {

            if (cb_anios.SelectedItem is not null)
            {
                fp_grafico.Reset();
                var p2 = fp_grafico.Plot;

                List<BE.Ganancia> ganancias = recuperarGanancias(int.Parse(cb_anios.SelectedItem.ToString()));
                List<double> mesesList = new List<double>();
                List<double> gananciasPorMesList = new List<double>();

                foreach (BE.Ganancia g in ganancias)
                {
                    mesesList.Add(double.Parse(g.MES.ToString()));
                    gananciasPorMesList.Add(double.Parse(g.GANANCIA.ToString()));
                }

                double[] meses = mesesList.ToArray();
                double[] gananciasPorMes = gananciasPorMesList.ToArray();

                // create a histogram with a fixed number of bins
                ScottPlot.Statistics.Histogram hist = new(min: 1, max: 12, binCount: 12);
                p2.PlotBar(meses, gananciasPorMes);

                p2.SetAxisLimits(xMin: 1, xMax: 12);
                // Personalizar el grafico
                p2.Title("Flujo de ganancias por mes");
                p2.XLabel("Mes");
                p2.YLabel("Ganancias");

                p2.SaveFig("stats_histogram.png");

                fp_grafico.Refresh();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un año del combobox.");
            }
        }
    }
}
