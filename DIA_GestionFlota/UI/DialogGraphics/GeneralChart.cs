namespace DIA_GestionFlota
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>Demoes painting a chart.</summary>
    public class GeneralChart : Form
    {
        /// <summary>
        /// Initializes a new <see cref="T:WinForms.DemoChart"/>.
        /// </summary>
        public GeneralChart()
        {
            this.Build();

            this.Chart.LegendY = "";
            this.Chart.LegendX = "";
			this.Chart.Values = new[]{1};
            this.Chart.Draw();
        }
        
		/// <summary>
        /// Inicializa un nuevo gráfico de barras por meses o años.
        /// </summary>
        public GeneralChart(int i, int[] data)
		{
			this.Build();
            if(i == 0)
			{
				this.Chart.LegendX = "Meses";
			}
			else
			{
				this.Chart.LegendX = "Años";
			}
            this.Chart.Values = data;
            this.Chart.Draw();
		}

        private void Build()
        {
			Panel panel = new Panel();
            panel.Parent = this;
            panel.Dock = DockStyle.Fill;
            
			this.Chart = new Chart(width: ChartCanvasSize,
								   height: ChartCanvasSize);         
            
            panel.Controls.Add(this.Chart);
            this.MinimumSize = new Size(ChartCanvasSize, ChartCanvasSize);
            this.Text = this.GetType().Name;
        }

        /// <summary>
        /// Gets the <see cref="Chart"/>.
        /// </summary>
        /// <value>The chart.</value>
		public const int ChartCanvasSize = 512;
		public ComboBox comboMeses { get; set; }
		public Button btnGenerar { get; set; }
        public Button btnAños { get; set; }
        public Button btnSalir { get; set; }
        public Chart Chart { get; private set; }
    }
}