using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Windows
{
    public partial class frmPrincipal : Form
    {
        private RepositorioDeCubos repo;
        private List<Cubo> lista;
        int valorFiltro;
        bool filterOn = false;
        public frmPrincipal()
        {
            InitializeComponent();
            InitializeComponent();
            repo = new RepositorioDeCubos();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTrianguloAE Form = new frmTrianguloAE() { Text = "Agregar Lado" };
            DialogResult dr = Form.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            Cubo cubo = Form.GetCubo();
            if (!repo.Existe(cubo))
            {
                repo.Agregar(cubo);
                
                DataGridViewRow l = ConstruirFila();
                SetearFila(l, cubo);
                AgregarFila(l);

                MessageBox.Show("Fila añadida con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AgregarFila(DataGridViewRow l)
        {
            dgvDatos.Rows.Add(l);
        }
        private void SetearFila(DataGridViewRow l, Cubo cubo)
        {
            l.Cells[colLado.Index].Value = cubo.GetLado();
            
            l.Tag = cubo;
        }
        private DataGridViewRow ConstruirFila()
        {
            var l = new DataGridViewRow();
            l.CreateCells(dgvDatos);
            return l;
        }
    }
}
