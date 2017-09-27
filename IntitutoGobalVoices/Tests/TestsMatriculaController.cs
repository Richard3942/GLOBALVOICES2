using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using IntitutoGVMvc.Controllers;
using IntitutoGVMvc.ViewModels;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestsMatriculaController
    {
        [Test]
        public void TestMetodoListar()
        {
            var mock1 = new Mock<IMatricula>();
            mock1.Setup(o => o.ObtenerMatriculas("",1)).Returns(new List<MatriculaDto>());
            mock1.Setup(o => o.ObtenerNroRegistros()).Returns(6);

            
            var matriculaController = new MatriculaController();
            matriculaController.matriculaService = mock1.Object;
         

            var result = matriculaController.Listar("",1);

            mock1.Verify(o => o.ObtenerMatriculas("",1)); Times.Once();
            mock1.Verify(o => o.ObtenerNroRegistros()); Times.Once();
        }
        [Test]
        public void TestMetodoCrear()
        {

            var mock1 = new Mock<IUbigeo>();
            mock1.Setup(o => o.ObtenerTodosPaises()).Returns(new List<Pais>());

            var mock2 = new Mock<INivel>();
            mock2.Setup(o => o.ObtenerTodosNiveles()).Returns(new List<Nivel>());


            var matriculaController = new MatriculaController();
            matriculaController.ubigeoService = mock1.Object;
            matriculaController.nivelService = mock2.Object;

            var result = matriculaController.Crear();

            mock1.Verify(o => o.ObtenerTodosPaises()); Times.Once();
            mock2.Verify(o => o.ObtenerTodosNiveles()); Times.Once();

        }
        [Test]
        public void TestMetodoDetalle()
        {
            var mock1 = new Mock<IMatricula>();
            mock1.Setup(o => o.ObtenerMatriculaById(98)).Returns(new Matricula()
            {
                Persona = new Persona(){Ubigeo = new Ubigeo()},
                Horario = new Horario(){Ciclo = new Ciclo()}

            });

            var mock2 = new Mock<INivel>();
            mock2.Setup(o => o.ObtenerTodosNiveles()).Returns(new List<Nivel>());

            var mock3 = new Mock<ICiclo>();
            mock3.Setup(o => o.ObtenerCiclosPorNivelId(1)).Returns(new List<Ciclo>());

            var mock4 = new Mock<IHorario>();
            mock4.Setup(o => o.ObtenerHorariosPorCicloIdAndTurno(1,true)).Returns(new List<HorarioDto>());

            var matriculaController = new MatriculaController();
            matriculaController.matriculaService = mock1.Object;
            matriculaController.nivelService = mock2.Object;
            matriculaController.cicloService = mock3.Object;
            matriculaController.horarioService = mock4.Object;


            var result = matriculaController.Detalle(98);

            mock1.Verify(o => o.ObtenerMatriculaById(98)); Times.Once();
            mock2.Verify(o => o.ObtenerTodosNiveles()); Times.Once();
            mock3.Verify(o => o.ObtenerCiclosPorNivelId(0)); Times.Once();
            mock4.Verify(o => o.ObtenerHorariosPorCicloIdAndTurno(0, false)); Times.Once();

        }
        [Test]
        public void TestMetodoEditar()
        {
            var mock0 = new Mock<IUbigeo>();
            mock0.Setup(o => o.ObtenerTodosPaises());

            var mock1 = new Mock<IMatricula>();
            mock1.Setup(o => o.ObtenerMatriculaById(98)).Returns(new Matricula()
            {
                Persona = new Persona() { Ubigeo = new Ubigeo() },
                Horario = new Horario() { Ciclo = new Ciclo() }

            });

            var mock2 = new Mock<INivel>();
            mock2.Setup(o => o.ObtenerTodosNiveles()).Returns(new List<Nivel>());

            var mock3 = new Mock<ICiclo>();
            mock3.Setup(o => o.ObtenerCiclosPorNivelId(1)).Returns(new List<Ciclo>());

            var mock4 = new Mock<IHorario>();
            mock4.Setup(o => o.ObtenerHorariosPorCicloIdAndTurno(0, false)).Returns(new List<HorarioDto>());

            var matriculaController = new MatriculaController();
            matriculaController.ubigeoService = mock0.Object;
            matriculaController.matriculaService = mock1.Object;
            matriculaController.nivelService = mock2.Object;
            matriculaController.cicloService = mock3.Object;
            matriculaController.horarioService = mock4.Object;


            var result = matriculaController.Editar(98);

            mock0.Verify(o => o.ObtenerTodosPaises()); Times.Once();
            mock1.Verify(o => o.ObtenerMatriculaById(98)); Times.Once();
            mock2.Verify(o => o.ObtenerTodosNiveles()); Times.Once();
            mock3.Verify(o => o.ObtenerCiclosPorNivelId(0)); Times.Once();
            mock4.Verify(o => o.ObtenerHorariosPorCicloIdAndTurno(0, false)); Times.Once();

        }
        [Test]
        public void TestMetodoCargarCombos()
        {
            var mock0 = new Mock<IUbigeo>();
            mock0.Setup(o => o.ObtenerTodosPaises());

            var mock2 = new Mock<INivel>();
            mock2.Setup(o => o.ObtenerTodosNiveles()).Returns(new List<Nivel>());

            var mock3 = new Mock<ICiclo>();
            mock3.Setup(o => o.ObtenerCiclosPorNivelId(1)).Returns(new List<Ciclo>());

            var mock4 = new Mock<IHorario>();
            mock4.Setup(o => o.ObtenerHorariosPorCicloIdAndTurno(0, false)).Returns(new List<HorarioDto>());

            var matriculaController = new MatriculaController();
            matriculaController.ubigeoService = mock0.Object;
            matriculaController.nivelService = mock2.Object;
            matriculaController.cicloService = mock3.Object;
            matriculaController.horarioService = mock4.Object;

            matriculaController.CargarCombos(new MatriculaViewModel());

            mock0.Verify(o => o.ObtenerTodosPaises()); Times.Once();
            mock2.Verify(o => o.ObtenerTodosNiveles()); Times.Once();
            mock3.Verify(o => o.ObtenerCiclosPorNivelId(0)); Times.Once();
            mock4.Verify(o => o.ObtenerHorariosPorCicloIdAndTurno(0, false)); Times.Once();
        }
        [Test]
        public void TestMetodoRegistrarNuevoEstudiante()
        {

            var matriculaViewModel = new MatriculaViewModel()
            {
                CicloSeleccionadoId = 1,
                HorarioSeleccionadoId = 1,
                ModCiudad = "Cajamarca",
                UbigeoFk = 1,
                NroDocumento = "78781459",
                ModApellidoMaterno = "Paredes",
                ModApellidoPaterno = "Atencio",
                ModCelular = "976636548",
                ModDireccion = "Jr Marañon # 815",
                ModEmail = "ingersol-rand@hotmail.com",
                ModFechaNacimiento = DateTime.Now,
                ModGenero = true,
                ModNombres = "Richard",
                ModNroDocumento = "78784517",
                ModPaisSeleccionado = "Peru",
                ModTelefono = "368584",
                TurnoSeleccionadoId = true,
                ModId = 0,
                NivelSeleccionadoId = 1,
                NombresCompletos = "Richard Paredes Atencio",
                NroVoucher = "Doc- 01",
                PersonaSeleccionadaId = 1,
                TipoFk = 1,
                TipoMatricula = "Renovacion matricula",
                Action = "Guardar"
            };

            var estadoSalon = new EstadoSalon()
            {
                Estado = false,
                HorarioFk = 1,
                Id = 1,
                Salon = new Salon() { Id = 1, Capacidad = 30, Nombre = "A-201" },
                NroMatriculados = 0,
                Turno = false,
                SalonFk = 1

            };


            var mock0 = new Mock<IUbigeo>();
            mock0.Setup(o => o.RegistrarUbigeo(new Ubigeo()));

            var mock2 = new Mock<IPersona>();
            mock2.Setup(o => o.RegistrarPersona(new Persona()));
       
            var mock3 = new Mock<IMatricula>();
            mock3.Setup(o => o.RegistrarMatricula(new Matricula()));

            var mock4 = new Mock<ISalon>();
            mock4.Setup(o => o.ObtenerEstadoSalonByHorarioId(1)).Returns(estadoSalon);

            var matriculaController = new MatriculaController();
            matriculaController.ubigeoService = mock0.Object;
            matriculaController.personaService = mock2.Object;
            matriculaController.matriculaService = mock3.Object;
            matriculaController.salonService = mock4.Object;



            matriculaController.RegistrarNuevoEstudiante(matriculaViewModel);

            mock0.Verify(o => o.RegistrarUbigeo(It.IsAny<Ubigeo>())); Times.Once();
            mock2.Verify(o => o.RegistrarPersona(It.IsAny<Persona>())); Times.Once();
            mock3.Verify(o => o.RegistrarMatricula(It.IsAny<Matricula>())); Times.Once();
            mock4.Verify(o => o.ObtenerEstadoSalonByHorarioId(1)); Times.Once();

        }
        [Test]
        public void TestMetodoRegistrarMatriculaEstudianteExiste()
        {
            var matriculaViewModel = new MatriculaViewModel()
            {

                CicloSeleccionadoId = 1,
                HorarioSeleccionadoId = 1,
                ModCiudad = "Cajamarca",
                UbigeoFk = 1,
                NroDocumento = "78781459",
                ModApellidoMaterno = "Paredes",
                ModApellidoPaterno = "Atencio",
                ModCelular = "976636548",
                ModDireccion = "Jr Marañon # 815",
                ModEmail = "ingersol-rand@hotmail.com",
                ModFechaNacimiento = DateTime.Now,
                ModGenero = true,
                ModNombres = "Richard",
                ModNroDocumento = "99988888",
                ModPaisSeleccionado = "Peru",
                ModTelefono = "368584",
                TurnoSeleccionadoId = true,
                ModId = 1,
                NivelSeleccionadoId = 1,
                NombresCompletos = "Richard Paredes Atencio",
                NroVoucher = "Doc- 01",
                PersonaSeleccionadaId = 1,
                TipoFk = 1,
                TipoMatricula = "Renovacion matricula",
                Action = "EditarMatricula",


            };
            var estadoSalon = new EstadoSalon() 
            {
             Estado = false,
             HorarioFk = 1,
             Id = 1, 
             Salon = new Salon(){Id = 1, Capacidad = 30,Nombre = "A-201"},
             NroMatriculados = 0,
             Turno = false,
             SalonFk = 1

            };

            var mock = new Mock<IMatricula>();
            var mock2 = new Mock<ISalon>();

            mock.Setup(o => o.RegistrarMatricula(new Matricula()));
            mock2.Setup(o => o.ObtenerEstadoSalonByHorarioId(1)).Returns(estadoSalon);


            var matriculaController = new MatriculaController();
            matriculaController.matriculaService = mock.Object;
            matriculaController.salonService = mock2.Object;

            matriculaController.RegistrarMatriculaEstudianteExiste(matriculaViewModel);
            mock.Verify(o => o.RegistrarMatricula(It.IsAny<Matricula>())); Times.Once();
            mock2.Verify(o => o.ObtenerEstadoSalonByHorarioId(1)); Times.Once();
        }
        [Test]
        public void TestMetodoEditarMatricula()
        {


            var matriculaViewModel = new MatriculaViewModel()
            {

                CicloSeleccionadoId = 1,
                HorarioSeleccionadoId = 1,
                ModCiudad = "Cajamarca",
                UbigeoFk = 1,
                NroDocumento = "78781459",
                ModApellidoMaterno = "Paredes",
                ModApellidoPaterno = "Atencio",
                ModCelular = "976636548",
                ModDireccion = "Jr Marañon # 815",
                ModEmail = "ingersol-rand@hotmail.com",
                ModFechaNacimiento = DateTime.Now,
                ModGenero = true,
                ModNombres = "Richard",
                ModNroDocumento = "99988888",
                ModPaisSeleccionado = "Peru",
                ModTelefono = "368584",
                TurnoSeleccionadoId = true,
                ModId = 1,
                NivelSeleccionadoId = 1,
                NombresCompletos = "Richard Paredes Atencio",
                NroVoucher = "Doc- 01",
                PersonaSeleccionadaId = 1,
                TipoFk = 1,
                TipoMatricula = "Renovacion matricula",
                Action = "EditarMatricula",


            };
            var matricula = new Matricula()
            {
                Estado = true,
                FechaRegistro = DateTime.Now,
                HorarioFk = 1,
                Id = 1,
                NroMatricula = 1,
                NroVoucher = "00-12",
                PersonaFk = 1,
                TipoMatricula = "Renovacion matricula"
            };



            var mock = new Mock<IMatricula>();
            mock.Setup(o => o.ObtenerSoloMatriculaById(1)).Returns(matricula);
            mock.Setup(o => o.UpdateMatricula(matricula));

            var matriculaController = new MatriculaController();
            matriculaController.matriculaService = mock.Object;

            matriculaController.EditarMatricula(matriculaViewModel);

            mock.Verify(o => o.ObtenerSoloMatriculaById(1)); Times.Once();
            mock.Verify(o => o.UpdateMatricula(It.IsAny<Matricula>())); Times.Once();
        }
        [Test]
        public void TestMetodoGuardarEditar()
        {
            var matriculaViewModel = new MatriculaViewModel()
            {

                CicloSeleccionadoId = 1,
                HorarioSeleccionadoId = 1,
                ModCiudad = "Cajamarca",
                UbigeoFk = 1,
                NroDocumento = "78781459",
                ModApellidoMaterno = "Paredes",
                ModApellidoPaterno = "Atencio",
                ModCelular = "976636548",
                ModDireccion = "Jr Marañon # 815",
                ModEmail = "ingersol-rand@hotmail.com",
                ModFechaNacimiento = DateTime.Now,
                ModGenero = true,
                ModNombres = "Richard",
                ModNroDocumento = "99988888",
                ModPaisSeleccionado = "Peru",
                ModTelefono = "368584",
                TurnoSeleccionadoId = true,
                ModId = 0,
                NivelSeleccionadoId = 1,
                NombresCompletos = "Richard Paredes Atencio",
                NroVoucher = "Doc- 01",
                PersonaSeleccionadaId = 1,
                TipoFk = 1,
                TipoMatricula = "Renovacion matricula",
                Action = "EditarMatricula",
                
                
            };
            var mock0 = new Mock<IUbigeo>();
            mock0.Setup(o => o.ObtenerTodosPaises()).Returns(new List<Pais>());

            var mock2 = new Mock<INivel>();
            mock2.Setup(o => o.ObtenerTodosNiveles()).Returns(new List<Nivel>());

            var mock3 = new Mock<ICiclo>();
            mock3.Setup(o => o.ObtenerCiclosPorNivelId(1)).Returns(new List<Ciclo>());

            var mock4 = new Mock<IHorario>();
            mock4.Setup(o => o.ObtenerHorariosPorCicloIdAndTurno(1, true)).Returns(new List<HorarioDto>());

            var mock5 = new Mock<IMatricula>();
            mock5.Setup(o => o.ObtenerNroRegistros()).Returns(6);



            var matriculaController = new MatriculaController();

            matriculaController.ubigeoService = mock0.Object;
            matriculaController.nivelService = mock2.Object;
            matriculaController.cicloService = mock3.Object;
            matriculaController.horarioService = mock4.Object;
            matriculaController.matriculaService = mock5.Object;


            matriculaController.GuardarEditar(matriculaViewModel);


            mock0.Verify(o => o.ObtenerTodosPaises()); Times.Once();
            mock2.Verify(o => o.ObtenerTodosNiveles()); Times.Once();
            mock3.Verify(o => o.ObtenerCiclosPorNivelId(1)); Times.Once();
            mock4.Verify(o => o.ObtenerHorariosPorCicloIdAndTurno(1, true)); Times.Once();
            mock5.Verify(o => o.ObtenerNroRegistros()); Times.Once();

        }

    }
}
