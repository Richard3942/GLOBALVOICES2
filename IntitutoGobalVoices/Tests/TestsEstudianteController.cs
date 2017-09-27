using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entidades;
using Interfaces;
using IntitutoGVMvc.Controllers;
using IntitutoGVMvc.ViewModels;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestsEstudianteController
    {
        [Test]
        public void TestMetodoListar()
        {
            var mock1 = new Mock<IUbigeo>();
            mock1.Setup(o => o.ObtenerTodosPaises()).Returns(new List<Pais>());

            var mock2 = new Mock<IPersona>();
            mock2.Setup(o => o.ObtenerPersonas("",1)).Returns(new List<Persona>());
            mock2.Setup(o => o.ObtenerNroRegistros()).Returns(1);

            var estudianteController = new EstudianteController();
            estudianteController.ubigeoService = mock1.Object;
            estudianteController.personaService = mock2.Object;

            var result = estudianteController.Listar("");

            mock1.Verify(o => o.ObtenerTodosPaises()); Times.Once();
            mock2.Verify(o => o.ObtenerPersonas("", 1)); Times.Once();
            mock2.Verify(o => o.ObtenerNroRegistros()); Times.Once();

        }

        [Test]
        public void TestMetodoCrear()
        {
            var mock1 = new Mock<IUbigeo>();
            mock1.Setup(o => o.ObtenerTodosPaises()).Returns(new List<Pais>());

            var estudianteController = new EstudianteController();
            estudianteController.ubigeoService = mock1.Object;
            var result = estudianteController.Crear();
            mock1.Verify(o => o.ObtenerTodosPaises()); Times.Once();
        }

        [Test]
        public void TestMetodoEditar()
        {
            var mock1 = new Mock<IUbigeo>();
            mock1.Setup(o => o.ObtenerTodosPaises()).Returns(new List<Pais>());
            var mock2 = new Mock<IPersona>();
            mock2.Setup(o => o.ObtenerPersonaById(110)).Returns(new Persona{Ubigeo = new Ubigeo()});
            
            var estudianteController = new EstudianteController();
            estudianteController.ubigeoService = mock1.Object;
            estudianteController.personaService = mock2.Object;   
            
             var result =estudianteController.Editar(110);
             mock1.Verify(o => o.ObtenerTodosPaises()); Times.Once();
             mock2.Verify(o => o.ObtenerPersonaById(110)); Times.Once();
        }

        [Test]
        public void TestMetodoDetalle()
        {
          
            var mock = new Mock<IPersona>();
            mock.Setup(o => o.ObtenerPersonaById(7)).Returns(new Persona{Ubigeo = new Ubigeo()});
            var estudianteController = new EstudianteController();

            estudianteController.personaService = mock.Object;

            var result = estudianteController.Detalle(7);
            
            mock.Verify(o => o.ObtenerPersonaById(7)); Times.Once();
        }

        [Test]
        public void TestMetodoEliminar()
        {
            var mock1 = new Mock<IMatricula>();
            mock1.Setup(o => o.EstaMatriculado(110)).Returns(false);
            var mock2 = new Mock<IPersona>();
            mock2.Setup(o => o.EliminarPersona(110));
           
            var mock3 = new Mock<IUbigeo>();
            mock3.Setup(o => o.ObtenerTodosPaises()).Returns(new List<Pais>());
    
            var estudianteController = new EstudianteController();
            estudianteController.matriculaService = mock1.Object;
            estudianteController.personaService = mock2.Object;
            estudianteController.ubigeoService = mock3.Object;

            var result = estudianteController.Eliminar(110);

            mock1.Verify(o => o.EstaMatriculado(110)); Times.Once();
            mock2.Verify(o => o.EliminarPersona(110)); Times.Once();
            mock3.Verify(o => o.ObtenerTodosPaises()); Times.Once();
        }

        [Test]
       public void TestMetodoGuardar()
        {
            var personaViewMosel = new PersonaViewModel()
            {
               Action = "GuardarEstudiante",
               ModApellidoMaterno = "paredes",
               ModApellidoPaterno =  "Atencio",
               ModCelular = "987789748",
               ModCiudad = "Cajamarca",
               ModDireccion = "Jr Marañon # 815",
               ModEmail = "ingersol-rand@hotmail.com",
               ModFechaNacimiento = DateTime.Parse("12/12/97") ,
               ModGenero = true,
               ModNombres = "Richard Manuel",
               ModNroDocumento = "78787814",
               ModPaisSeleccionado = "Peru",
               ModTelefono = "368594",
               ModUbigeoFk = 1,
               TipoFk = 1,
               criterioBusqueda = "",           
            };


            var ubigeo = new Ubigeo() { Ciudad = personaViewMosel.ModCiudad, Pais = personaViewMosel.ModPaisSeleccionado };
            var persona = new Persona() {Id = 2,Telefono = "adf"};
            var mock1 = new Mock<IUbigeo>();

            mock1.Setup(o => o.RegistrarUbigeo(ubigeo));

            var mock2 = new Mock<IPersona>();
            mock2.Setup(o => o.RegistrarPersona(persona));
          

            var estudianteController = new EstudianteController();
            estudianteController.personaService = mock2.Object;
            estudianteController.ubigeoService = mock1.Object;

            var result = estudianteController.Guardar(personaViewMosel);
            mock1.Verify(o => o.RegistrarUbigeo(It.IsAny<Ubigeo>())); Times.Once();      
            mock2.Verify(o => o.RegistrarPersona(It.IsAny<Persona>())); Times.Once();
           
  

        }
    }
}
