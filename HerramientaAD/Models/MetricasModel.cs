using HerramientaAD.com.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientaAD.Models
{
    public class MetricasModel
    {
        private List<ElementosDeGrupo.Indicadores> indicadores = new List<ElementosDeGrupo.Indicadores>();
        public List<ElementosDeGrupo.Indicadores> Indicadores
        {
            get { return indicadores; }
            set { indicadores = value; }
        }

        public MetricasModel(int UsuarioID, int AplicacionID)
        {
            String Nombreapp = ""; //MMOB - Se agregó variable
            Nombreapp = "Prueba";
            indicadores.Add(new ElementosDeGrupo.Indicadores("a", 1, 2, "10%", Nombreapp));



        }
    }
}