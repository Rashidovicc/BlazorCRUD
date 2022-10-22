using AutoMapper;
using Game.Web.Data.Domain;
using Game.Web.Data.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Game.Web.Data.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;
        public EmployeeService(DataContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public async Task CreateEmployee(Employee game)
        {
            game.Password = game.Password.Encrypt();
            _context.employees.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("employees");
        }

        public async Task DeleteEmployee(int id)
        {
            var dbGame = await _context.employees.FindAsync(id);

            _context.employees.Remove(dbGame);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("employees");
            await LoadEmployees();
        }

        public async Task<Employee> GetSingleEmployee(int id)
        {
            var game = await _context.employees.FindAsync(id);
            if (game == null)
                throw new Exception("No game here. :/");
            return game;
        }

        public async Task LoadEmployees()
        {
            Employees = await _context.employees.ToListAsync();
        }
        public async Task UpdateEmployee(Employee game, int id)
        {
            var dbGame = await _context.employees.FindAsync(id);
            if (dbGame == null)
                throw new Exception("No game here. :/");
            dbGame.FirstName = game.FirstName;
            dbGame.LastName = game.LastName;
            dbGame.PhoneNumber = game.PhoneNumber;
            dbGame.Gmail = game.Gmail;
            dbGame.Login = game.Login;
            dbGame.Password = game.Password;
            _context.Update(dbGame);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("employees");
        }
    }
}
