//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        public static ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }
        public static double TotAll { get; set; }
        public static double TotProduct { get; set;}
        public static double TotEquipement { get; set;}

        public void AddStep(Step step)
        {
            Recipe.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            Recipe.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in Recipe.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Total: {Recipe.GetProductionCost() }");
        }

        public static double GetProductionCost()
        {
            foreach (Step step in Recipe.steps)
            {
                TotProduct += step.Quantity *  step.Input.UnitCost ;
                TotEquipement += step.Time * step.Equipment.HourlyCost ;
                TotAll = TotEquipement + TotProduct;
                
            }
            
            return TotAll;
        }
    }
}