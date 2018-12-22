using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace AppEvaMovil.Models
{
    public class eva_cat_especialidades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public Int16 IdEspecialidad { get; set; }
        [StringLength(100)]
        public string DesEspecialidad { get; set; }
        
        public bool Activo { get; set; }
       
        public bool Borrado { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
    }


    public class cat_tipo_generales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTipoGeneral { get; set; }
       
        [StringLength(100)]
        public string DesTipo { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
       
        public bool Activo { get; set; }
     
        public bool Borrado { get; set; }
    }
    public class cat_generales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGeneral { get; set; }
        public int IdTipoGeneral { get; set; }
        public cat_tipo_generales cat_tipo_generales { get; set; }
        public string Clave { get; set; }
        public string DesGeneral { get; set; }
        public string IdLlaveClasifica { get; set; }
        public string Referencia { get; set; }

        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
       
        public bool Activo { get; set; }
        
        public bool Borrado { get; set; }
    }

    public class eva_cat_carreras
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCarrera { get; set; }
        [StringLength(20)]
        public string ClaveCarrera { get; set; }
        [StringLength(20)]
        public string ClaveOficial { get; set; }
        [StringLength(100)]
        public string DesCarrera { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        // public Int16 IdAreaDepto { get; set; }
        //  public rh_cat_areas_deptos rh_cat_areas_deptos { get; set; }
        [ForeignKey("cat_tipo_generales")]
        public Int16 IdTipoGenGradoEscolar { get; set; }
        [ForeignKey("cat_generales")]
        public Int16 IdGenGradoEscolar { get; set; }

        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        [StringLength(20)]
        public string NombreCorto { get; set; }
        public int Creditos { get; set; }

        public Int16 IdTipoGenModalidad { get; set; }
        // public cat_tipos_generales cat_tipos_generales_modalidad { get; set; }
        public Int16 IdGenModalidad { get; set; }
        // public cat_generales cat_generales_modalidad { get; set; }

        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
    }//class eva_cat_carreras

    public class eva_carreras_reticulas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int IdCarreraRiticula { get; set; }
        public int IdReticula { get; set; }
        public int IdCarrera { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
    }

    public class eva_carreras_especialidades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int IdCarreraEspecilidad { get; set; }
        public int IdEspecialidad { get; set; }
        public eva_cat_especialidades eva_cat_especialidades { get; set; }
        public int IdCarrera { get; set; }
        public eva_cat_carreras eva_cat_carreras { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
    }



    /*AYUDANTE */

    public class eva_cat_carreras_consulta
    {

        public int IdConsulta { get; set; }
        public int IdCarrera { get; set; }
        [StringLength(20)]
        public string ClaveCarrera { get; set; }
        [StringLength(20)]
        public string ClaveOficial { get; set; }
        [StringLength(100)]
        public string DesCarrera { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        // public Int16 IdAreaDepto { get; set; }
        //  public rh_cat_areas_deptos rh_cat_areas_deptos { get; set; }
        public int IdTipoGenGradoEscolar { get; set; }
        public cat_tipo_generales cat_tipo_generales { get; set; }
        public int IdGenGradoEscolar { get; set; }
        public cat_generales cat_generales { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        [StringLength(20)]
        public string NombreCorto { get; set; }
        public int Creditos { get; set; }
        public Int16 IdTipoGenModalidad { get; set; }
        // public cat_tipos_generales cat_tipos_generales_modalidad { get; set; }
        public Int16 IdGenModalidad { get; set; }
        // public cat_generales cat_generales_modalidad { get; set; }
        public Nullable<DateTime> FechaIni { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
    }//class eva_cat_carreras OK

    public class cat_carreras_agregar
    {
        public eva_cat_carreras eva_cat_carreras { get; set; }
        public List<cat_generales> cat_generales { get; set; }
        public List<eva_cat_carreras> eva_cat_carreraslist { get; set; }
    }

    public class cat_exportar_importar
    {
        public List<cat_tipo_generales> cat_tipo_generales { get; set; }
        public List<cat_generales> cat_generales { get; set; }
        public List<eva_cat_carreras> eva_cat_carreras { get; set; }
        public List<eva_cat_especialidades> eva_cat_especialidades { get; set; }
        public List<eva_carreras_especialidades> eva_carreras_especialidades { get; set; }

        public List<eva_cat_reticulas> eva_cat_reticulas { get; set; }
        public List<eva_carreras_reticulas> eva_carreras_reticulas { get; set; }
        public List<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
        public List<eva_reticulas_asignaturas> eva_reticulas_asignatiras { get; set; }
        public List<eva_reticula_asignatura_ant> eva_reticula_asignatura_ant { get; set; }

    }

    public class eva_cat_reticulas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ForeignKey("cat_tipo_generales")]
        public int IdTipoGenPlanEstudios { get; set; }
        public cat_tipo_generales cat_tipo_generales { get; set; }
        //[ForeignKey("cat_generales")]
        public int IdGenPlanEstudios { get; set; }
        public cat_generales cat_generales { get; set; }
        //[Key, Required]
        public int IdReticula { get; set; }
        [StringLength(100)]
        public String Clave { get; set; }
        [StringLength(100)]
        public String DesReticula { get; set; }
        
        public bool Actual { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaReg { get; set; }
        [StringLength(100)]
        public String UsuarioReg { get; set; }
        public DateTime? FechaUltMod { get; set; }
        [StringLength(100)]
        public String UsuarioMod { get; set; }
      
        public bool Activo { get; set; }
        
        public bool Borrado { get; set; }
    }


    public class eva_cat_asignaturas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ForeignKey("cat_tipo_generales"), Required]
        public int IdTipoGeneralAsignatura { get; set; }
        public cat_tipo_generales cat_tipo_generalesAs { get; set; }
        //[ForeignKey("cat_tipo_generales"), Required]
        public int IdTipoGeneralNivelEscolar { get; set; }
        public cat_tipo_generales cat_tipo_generales { get; set; }
        //[ForeignKey("cat_generales"), Required]
        public int IdGeneralAsignatura { get; set; }
        public cat_generales cat_generalesAs { get; set; }
        //[ForeignKey("cat_generales"), Required]
        public int IdGeneralNivelEscolar { get; set; }
        public cat_generales cat_generales { get; set; }
        //[Key, Required]
        public int IdAsignatura { get; set; }
        [StringLength(100)]
        public String ClaveAsignatura { get; set; }
        [StringLength(100)]
        public String DesAsignatura { get; set; }
        [StringLength(100)]
        public String Matricula { get; set; }
        
        public bool Actual { get; set; }
        public DateTime? FechaPlanEstudios { get; set; }
        [StringLength(100)]
        public String NombreCorto { get; set; }
        [StringLength(100)]
        public String Creditos { get; set; }
        public DateTime? FachaReg { get; set; }
        [StringLength(100)]
        public String UsuarioReg { get; set; }
        public DateTime? FechaUltMod { get; set; }
        [StringLength(100)]
        public String UsuarioMod { get; set; }
       
        public bool Activo { get; set; }
        
        public bool Borrar { get; set; }
    }

    public class cat_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ForeignKey("cat_tipo_estatus"), Required]
        public int IdTipoEstatus { get; set; }
        public cat_tipo_estatus cat_tipo_estatus { get; set; }
        //[Key, Required]
        public int IdEstatus { get; set; }
        [StringLength(100)]
        public String Clave { get; set; }
        [StringLength(100)]
        public String DesEstatus { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(200)]
        public String UsuarioReg { get; set; }
        [StringLength(200)]
        public String UsuarioMod { get; set; }
       
        public bool Activo { get; set; }
        
        public bool Borrado { get; set; }
    }

    public class cat_tipo_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key, Required]
        public int IdTipoEstatus { get; set; }
        [StringLength(100)]
        public String DesTipo { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(100)]
        public String UsuarioReg { get; set; }
        [StringLength(100)]
        public String UsuarioMod { get; set; }
        
        public bool Activo { get; set; }
       
        public bool Borrado { get; set; }
    }




    public class eva_reticulas_asignaturas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdReticula { get; set; }
        public eva_cat_reticulas eva_cat_reticulas { get; set; }
        public int IdAsignatura { get; set; }
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public int IdReticulaAsignatura { get; set; }
        public Int16 Creditos { get; set; }
        public int HorasTeoria { get; set; }
        public Int16 HorasPractica { get; set; }
        public int Semestre { get; set; }
        public int OrderCertificado { get; set; }
        public int CreditosPrerequisito { get; set; }
        public int IdTipoEstatus { get; set; }
        public cat_tipo_estatus cat_tipo_estatus { get; set; }
        public int IdEstatus { get; set; }
        public cat_estatus cat_estatus { get; set; }
        [StringLength(20)]
        public string Especialidad { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
    }



    public class eva_reticula_asignatura_ant
    {
        //[ForeignKey("eva_cat_reticulas"), Required]
        public int IdReticula { get; set; }
        public eva_cat_reticulas eva_cat_reticulas { get; set; }
        //[ForeignKey("eva_cat_asignaturas"), Required]
        public int IdAsignaturaAnterior { get; set; }
        public eva_cat_asignaturas eva_cat_asignatura_anterior { get; set; }
        //[ForeignKey("eva_cat_asignaturas"), Required]
        public int IdAsignatura { get; set; }
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        //[Key, Required]
        public int IdAnterior { get; set; }
        public DateTime? FechaReg { get; set; }
        [StringLength(100)]
        public String UsuarioReg { get; set; }
        public DateTime? FechaUltMod { get; set; }
        [StringLength(100)] 
        public String UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
    }



}
