using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.DAO;
using RecetaSpawn.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.DAO.Tests
{
    [TestClass()]
    public class TblUsuarioDAOTests
    {

        [TestMethod()]
        public void IniciarSesion()
        {
            TblUsuarioCTRL val = new TblUsuarioCTRL();
            TblUsuariosBO dat = new TblUsuariosBO();

            bool res;

            dat.Correo = "Juanpa@gmail.com";
            dat.Contraseña = "123";

            res = val.Validar(dat);

            Assert.IsTrue(res);

        }




        //[TestMethod()] //uriel
        //public void Agregar_LlenandoTodosLosCampos()
        //{
        //    TblUsuariosBO data = new TblUsuariosBO(); // y que se usara el tblUsuario 
        //    TblUsuarioDAO metodo = new TblUsuarioDAO(); // Es el metodo que raliza la consulta ala BD

        //    bool res;// se declara una variable de tipo boleana. Las cuales son V y F 

        //    data.Nombre = "Felipe"; // se estan asignando valores a "Nombre"
        //    data.Apellido = "Carrillo P";
        //    data.Correo = "felipe@gmail.com";
        //    data.Contraseña = "123";
        //    data.Genero = "Hombre";
        //    data.Rol = "Usuario";

        //    res = metodo.Agregar(data); // Recibe el resultado del metodo "agregar" y los resultados se le pasan a "res"

        //    Assert.IsTrue(res); // Es el valor esperado que sera True
        //}



        //[TestMethod()]
        //public void Eliminar_datos()
        //{
        //    TblUsuariosBO data = new TblUsuariosBO();
        //    TblUsuarioDAO metodo = new TblUsuarioDAO();

        //    bool res;
        //    data.IDUsuario = 9;
        //    res = metodo.Eliminar(data);

        //    Assert.IsTrue(res);
        //}

        //[TestMethod()]
        //public void Editar_editandoxd()
        //{
        //    TblUsuariosBO data = new TblUsuariosBO();
        //    TblUsuarioDAO metodo = new TblUsuarioDAO();

        //    bool res;
        //    data.Nombre = "Andrew";
        //    data.Apellido = "dobabes";
        //    data.Correo = "golosa@gmail.com";
        //    data.Contraseña = "987654";
        //    data.Genero = "Hombre";
        //    data.Rol = "Usuario";
        //    data.IDUsuario = 9;

        //    res = metodo.Editar(data);

        //    Assert.IsTrue(res);
        //}



        //[TestMethod()]
        //public void Buscar_Usuario()
        //{
        //    TblUsuarioDAO metodo = new TblUsuarioDAO();
        //    TblUsuariosBO data = new TblUsuariosBO();

        //    bool res;
        //    res = metodo.BuscarUsuarios();
        //    Assert.IsTrue(res);
        //}

    }
}