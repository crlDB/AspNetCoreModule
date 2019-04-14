﻿using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using DB_Db2;

namespace M002
{
    public class CM002 : IM002
    {
        private IServiceProvider _serviceProvider;

        public CM002(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        public FromM002 Get(ToM002 toM002)
        {
            // add records
            var scope = _serviceProvider.CreateScope();
            var dbx = scope.ServiceProvider.GetService<Db2Ctx>();

            Table1 t = new Table1 { Num1 = 2, String1 = $"MOD2" };
            dbx.Table1.Add(t);
            dbx.SaveChanges();

            // get data module1
            //            IM001 m001 = _serviceProvider.GetService<IM001>();
            //            m001.Get(new ToM001());

            return new FromM002 { Nbr1 = 10 };
        }
    }
}
