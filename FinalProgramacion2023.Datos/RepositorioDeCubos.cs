using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Datos
{
    public class RepositorioDeCubos
    {
        private readonly string _archivo = Environment.CurrentDirectory + "//Cubos.txt";
        private readonly string _archivoCopia = Environment.CurrentDirectory + "//Cubos.bak";

        private List<Cubo> listaCubo;
        public RepositorioDeCubos()
        {
            listaCubo = new List<Cubo>();
            LeerDatos();
        }
        private void LeerDatos()
        {
            listaCubo.Clear();
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Cubo cubo = ConstruirCubo(lineaLeida);
                    listaCubo.Add(cubo);
                }
                lector.Close();
            }
        }
        private Cubo ConstruirCubo(string lineaLeida)
        {

            var campos = lineaLeida.Split('|');
            int lado = int.Parse(campos[0]);
            Cubo cubo = new Cubo(lado);
            return cubo;
        }
        public void Agregar(Cubo cubo)
        {
            using (var escritor = new StreamWriter(_archivo, true))
            {
                string lineaEscribir = ConstruirLinea(cubo);
                escritor.WriteLine(lineaEscribir);
            }
            listaCubo.Add(cubo);
        }
        private string ConstruirLinea(Cubo cubo)
        {
            return $"{cubo.GetLado()}|";
                   
        }

        public bool Existe(Cubo cubo)
        {
            listaCubo.Clear();
            LeerDatos();
            bool existe = false;
            foreach (var itemCubo in listaCubo)
            {
                if (itemCubo.GetLado() == cubo.GetLado())
                   
                {
                    return true;
                }
            }
            return false;
        }
    }
}
