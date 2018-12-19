using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AppEvaMovil.Views.AsignaturaAnterior;
using AppEvaMovil.Views.Asignaturas;
using AppEvaMovil.Views.Reticulas;
using AppEvaMovil.Views.ReticulasAsignaturas;




namespace AppEvaMovil.Views.Navegacion
{
    public class FicMasterPageMenuItem
    {
        public FicMasterPageMenuItem()
        {
            TargetType = typeof(FicMasterPageDetail);
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }

        public string FicPageName { get; set; }

    }


    }
