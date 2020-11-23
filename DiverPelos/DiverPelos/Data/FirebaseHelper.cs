using DiverPelos.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiverPelos.Data
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://diverpelos-fafe1.firebaseio.com/");

        public async Task<List<Empleado>> GetAllUsers()
        {

            return (await firebase
              .Child("Empleados")
              .OnceAsync<Empleado>()).Select(item => new Empleado
              {

                  Nombre = item.Object.Nombre,
                  Id = item.Object.Id,
                  Telefono = item.Object.Telefono,
                  Email = item.Object.Email,
                  Password = item.Object.Password,
                  Creation_Date = item.Object.Creation_Date
              }).ToList();
        }

        public async Task AddEmpleado(string cedula, string nombre, string telefono, string email, string password, DateTime creation_date)
        {

            await firebase
              .Child("Empleados")
              .PostAsync(new Empleado() { Id = cedula, Nombre = nombre, Telefono = telefono, Email = email, Password = password, Creation_Date = creation_date });
        }

        public async Task<FirebaseObject<Empleado>> EmailUser(string email)
        {
            var emailUser = (await firebase
              .Child("Empleados")
              .OnceAsync<Empleado>()).Where(a => a.Object.Email == email).FirstOrDefault();

            return emailUser;
        }

        public async Task AddCliente(string cedula, string nombre, string telefono, string direccion, string email, DateTime creation_date)
        {

            await firebase
              .Child("Clientes")
              .PostAsync(new Cliente() { Id = cedula, Nombre = nombre, Telefono = telefono, Direccion = direccion, Email = email, Creation_Date = creation_date });
        }

        public async Task AddServicio(string nombre, string duraccion, string descripccion, string valor)
        {
            await firebase
             .Child("Servicios")
             .PostAsync(new Servicio() { Nombre = nombre, Duraccion = duraccion, Descripcion = descripccion, Valor = valor });
        }



        public async Task<List<Cliente>> GetClienteModel()
        {
            return (await firebase
               .Child("Clientes")
               .OnceAsync<Cliente>()).Select(item => new Cliente
               {
                   Id = item.Object.Id,
                   Nombre = item.Object.Nombre,
                   Telefono = item.Object.Telefono,
                   Direccion = item.Object.Direccion,
                   Email = item.Object.Email,
                   Creation_Date = item.Object.Creation_Date

               }).ToList();
        }

        public async Task<List<Servicio>> GetAllServicio()
        {
            return (await firebase
               .Child("Servicios")
               .OnceAsync<Servicio>()).Select(item => new Servicio
               {

                   Nombre = item.Object.Nombre,
                   Descripcion = item.Object.Descripcion,
                   Duraccion = item.Object.Duraccion,
                   Valor = item.Object.Valor

               }).ToList();
        }

        public async Task<List<Turno>> GetAllTurno()
        {

            return (await firebase
              .Child("Turnos")
              .OnceAsync<Turno>()).Select(item => new Turno
              {
                  Cliente = item.Object.Cliente,
                  Servicio = item.Object.Servicio,
                  Fecha = item.Object.Fecha,
                  Hora = item.Object.Hora,
                  Estado = item.Object.Estado

              }).ToList();
        }

        public async Task AddTurno(string cliente, string servicio, DateTime fecha, TimeSpan hora, bool estado)
        {

            await firebase
              .Child("Turnos")
              .PostAsync(new Turno() { Cliente = cliente, Servicio = servicio, Fecha = fecha, Hora = hora, Estado = estado });
        }

    }
}
