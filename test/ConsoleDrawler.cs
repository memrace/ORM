
using Microsoft.EntityFrameworkCore;
using System;
using ConsoleTables;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace test
{
	public class ConsoleDrawler
	{
		private ApplicationDbContext _dbContext;
		private string _currentMigration;
		private List<string> _migrations;
		public ConsoleDrawler(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new NullReferenceException();
			if (!_dbContext.Database.CanConnect())
			{
				Console.WriteLine("Что то с базой");
			}
			

		}
		public void Draw()
		{
			TableMigrations();
			Console.WriteLine("\n Выберите версию для миграции... \n...................");
			RunMigrate(Console.ReadLine());
			Console.WriteLine("Заново? \n Y/N");
			if (Console.ReadLine().Equals("Y") || Console.ReadLine().Equals("y"))
			{
				Console.Clear();
			}
		}

		private void TableMigrations()
		{
			Update();
			var table = new ConsoleTable("Position", "Version");
			List<string> rows = new List<string> { };
			for (var i = 0; i < _migrations.Count(); i++)
			{
				table.AddRow(i+1, _migrations[i]);
			}
			table.Write();
		}
		private void RunMigrate(string position)
		{
			int _position;
			var migrateService = _dbContext.GetInfrastructure().GetService<IMigrator>();
			try
			{
				_position = Int32.Parse(position);
				// Check
				if (_currentMigration.Equals(_migrations[_position - 1]))
				{
					Console.WriteLine("Данная версия уже стоит. \n Другую версию...");
					RunMigrate(Console.ReadLine());
				}
				migrateService.Migrate(_migrations[_position - 1]);

			} catch (Exception)
			{
				Console.WriteLine("Надо циферки... )");
			}
			finally
			{
				// Update
				Update();
			}
			
		}
		private void Update()
		{
			if (!_dbContext.Database.CanConnect())
			{
				Console.WriteLine("Что то с базой");
			}
			_currentMigration = _dbContext.Database.GetAppliedMigrations().Last();
			_migrations = _dbContext.Database.GetMigrations().ToList();
			Console.WriteLine($"Текущая версия миграции: ~ {_currentMigration} ~");
		}
		
	}
}
