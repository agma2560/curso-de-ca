using System.Diagnostics;

namespace Async03
{
    public partial class FrmAsync : Form
    {
        public FrmAsync()
        {
            InitializeComponent();
        }

        // Aquí es valido async void, por ser método de evento
        private async void btnPrueba_Click(object sender, EventArgs e)
        {
            pbImagen.Visible = true;
            var Clock = new Stopwatch();
            Clock.Start();

            //await Proceso();
            //await Proceso();
            //await Proceso();

            var task = new List<Task>()
            {
                Proceso(),
                Proceso(),
                Proceso()
            };

            await Task.WhenAll(task);

            Clock.Stop();
            pbImagen.Visible = false;
            MessageBox.Show($"Tardó {Clock.ElapsedMilliseconds/1000} segundos");
        }

        private async Task Proceso()
        {
            //Thread.Sleep(2000);
            await Task.Delay(2000);
        }
    }
}
