﻿using Microsoft.EntityFrameworkCore;
using RefugioAnimalesApp.Data;
using RefugioAnimalesApp.Model;
using RefugioAnimalesApp.Reposotories;

public class Program
{
    static async Task Main()
    {
        using var context = new ShelterContext();
        //si hay migraciones pendients las detecta y si las hay las ejecuta
        await context.Database.MigrateAsync();

        var animalRepo = new RepositoryEF<Animal>(context);
        var adopterRepo = new RepositoryEF<Adopter>(context);
        var adoptionRepo= new RepositoryEF<Adoption>(context);

        Console.WriteLine("Datos inicialescargados con exito..");

        //Mostrar nombre de animales adoptados y adoptadores
        var adoptions = await context.Adoption
            .Include(a => a.Animal)
            .Include(a => a.Adopter)
            .Select(a => new
            {
                Animal = a.Animal.Name,
                Especie = a.Animal.Species,
                Adopter = a.Adopter.FullName,
                F_Adop = a.AdoptionDate
            }).ToListAsync();

        foreach (var item in adoptions)
            Console.WriteLine($"{item.Animal} ({item.Especie})" +
                $"adoptado por {item.Adopter}" +
                $"el {Convert.ToDateTime(item.F_Adop).ToShortDateString()}");

        //Mostrar animales sin adoptar
        var adoptedAnimals = adoptions.Select(a => a.Animal).ToList();

        var notAdopted = await animalRepo.FindAsync(a => !adoptedAnimals.Contains(a.Name));

        Console.WriteLine("Animales no adoptados");
        foreach (var a in notAdopted)
            Console.WriteLine($"{a.Name} ({a.Species}), {a.Age} años");
    }
}
