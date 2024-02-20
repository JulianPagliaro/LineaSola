namespace FinalProgramacion2023.Entidades
{
    public class Cubo
    {
        public int Lado { get; set; }
        public Cubo()
        {
        }

        public Cubo(int lado)
        {
            Lado = lado;
        }

        public double GetLado() => Lado;
        public void SetLado(int medida)
        {
            if (medida > 0)
            {
                Lado = medida;
            }
        }
    }
    
}
