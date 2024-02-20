using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Windows
{
    public partial class frmTrianguloAE : Form
    {
        public frmTrianguloAE()
        {
            InitializeComponent();
        }
        private Cubo cubo;
        public Cubo GetCubo()
        { return cubo; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cubo != null)
            {
                txtLadoA.Text = cubo.Lado.ToString();
            }
        }
        public void SetCubo(Cubo cubo)
        {
            this.cubo = cubo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cubo == null)
                {
                    cubo = new Cubo();
                }
                cubo.SetLado(int.Parse(txtLadoA.Text));
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (!int.TryParse(txtLadoA.Text, out int lado) || lado <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoA, "Número no válido");
            }

            return valido;
        }
    }
}
