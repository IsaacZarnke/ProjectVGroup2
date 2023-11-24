using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;


public static class DatabaseLib
{
    public static void Shell()
    {
        using var context = DataContext.Instance;
        context.SaveChanges();
    }

// function that takes an array and fills it with each row in monthly stats
// [0, 1, 2, 3, 4, 5]
// [month1clicks, month2conversions, month2clicks, month2conversions, month3clicks, month3conversions]
    public static int[] GetMonthlyStats()
    {
        using var context = DataContext.Instance;

        var statsList = context.MonthlyStats.ToList();

        int[] resultArray = new int[statsList.Count * 2];

        for (int i = 0; i < statsList.Count; i++)
        {
            resultArray[i * 2] = statsList[i].Clicks;
            resultArray[i * 2 + 1] = statsList[i].Conversions;
        }

        return resultArray;
    }

    public static Product GetProductById(int productId)
    {
        using var context = DataContext.Instance;

        var product = context.Products.FirstOrDefault(p => p.Pid == productId);

        return product;
    }

    public static string GetProductImageById(int productId)
    {
        using var context = DataContext.Instance;

        var product = context.Products.FirstOrDefault(p => p.Pid == productId);
        if (product != null)
        {
            return product.Image;
        }
        else
        {
            return null;
        }
    }

    public static string GetProductImageByName(string productName)
    {
        using var context = DataContext.Instance;

        var product = context.Products.FirstOrDefault(p => string.Equals(p.Name, productName));
        if (product != null)
        {
            return product.Image;
        }
        else
        {
            return null;
        }
    }


}


